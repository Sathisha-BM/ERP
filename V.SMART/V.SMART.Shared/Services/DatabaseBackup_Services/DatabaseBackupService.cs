using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data;
using V.SMART.Shared.ViewModels.BackupSettingVM;

namespace V.SMART.Shared.Services.Database_Backup
{
    public sealed class DatabaseBackupService : IDatabaseBackupService
    {
        private readonly string _connectionString;
        private readonly IOptions<DatabaseBackupOptions> _options;
        private readonly IServiceScopeFactory _scopeFactory;
        public DatabaseBackupService(IConfiguration configuration,IOptions<DatabaseBackupOptions> options, IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _options = options;
        }

        public async Task<DatabaseBackupResult> BackupAsync(CancellationToken cancellationToken = default)
        {
            var completedAt = DateTime.Now;

            try
            {
                if (!_options.Value.Enabled)
                {
                    return new DatabaseBackupResult
                    {
                        Success = true,
                        Message = "Database backup is disabled.",
                        CompletedAt = completedAt
                    };
                }
                using var scope = _scopeFactory.CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var connectionString =context.Database.GetConnectionString();

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException(
                        "Database connection string is missing.");
                }

                var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

                var databaseName =connectionStringBuilder.InitialCatalog;

                if (string.IsNullOrWhiteSpace(databaseName))
                {
                    throw new InvalidOperationException("Database name is missing from the connection string.");
                }

                var backupFolder = GetBackupFolder();

                Directory.CreateDirectory(backupFolder);

                var safeDatabaseName =MakeSafeFileName(databaseName);

                var fileName =$"{safeDatabaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                var backupFile = Path.Combine(backupFolder,fileName);

                await BackupDatabaseAsync(databaseName,backupFile,cancellationToken, connectionString);

                if (_options.Value.DeleteOldBackups)
                {
                    CleanupOldBackups(backupFolder,safeDatabaseName,5);
                }

             

                return new DatabaseBackupResult
                {
                    Success = true,
                    Message = $"Database backup completed successfully.",
                    BackupFile = backupFile,
                    CompletedAt = DateTime.Now
                };
            }
            catch (OperationCanceledException)
            {
                return new DatabaseBackupResult
                {
                    Success = false,
                    Message = "Database backup was cancelled.",
                    CompletedAt = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                return new DatabaseBackupResult
                {
                    Success = false,
                    Message =
                        $"Database backup failed: {ex.Message}",
                    CompletedAt = DateTime.Now
                };
            }
        }
        private async Task BackupDatabaseAsync(string databaseName,string backupFile,CancellationToken cancellationToken,string connectionString)
        {
            try
            {
                await using var connection = new SqlConnection(connectionString);

                await connection.OpenAsync(cancellationToken);

                var backupCommandText = $""" BACKUP DATABASE [{databaseName}] TO DISK = @BackupFile WITH INIT, FORMAT, CHECKSUM, STATS = 10; """;

                await using var backupCommand = new SqlCommand(backupCommandText, connection);

                backupCommand.CommandTimeout = 0;

                backupCommand.Parameters.Add("@BackupFile",SqlDbType.NVarChar,4000).Value = backupFile;

                try
                {
                    Debug.WriteLine("3. BEFORE ExecuteNonQueryAsync");

                    var task = backupCommand.ExecuteNonQueryAsync(CancellationToken.None);
                    await task;
                }
                catch (SqlException sqlEx)
                {
                    throw;
                }

                if (!File.Exists(backupFile))
                {
                    throw new FileNotFoundException("SQL backup completed but backup file was not found.",backupFile);
                }

                const string settingsSql = """
                                            SELECT TOP 1 Id,BackupPath,IsEnabled,RetentionDays
                                            FROM DBBackupSetting
                                            WHERE IsEnabled = 1
                                            ORDER BY Id;
                                            """;

                DBBackupSettingVM? result = null;

                await using (var settingsCommand =new SqlCommand(settingsSql, connection))
                {
                    await using var reader =
                        await settingsCommand.ExecuteReaderAsync(cancellationToken);

                    if (await reader.ReadAsync(cancellationToken))
                    {
                        result = new DBBackupSettingVM
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),

                            BackupPath = reader.IsDBNull(reader.GetOrdinal("BackupPath")) ? null
                                : reader.GetString(reader.GetOrdinal("BackupPath")),

                            IsEnabled = reader.GetBoolean(reader.GetOrdinal("IsEnabled")),

                            RetentionDays = reader.GetInt32(reader.GetOrdinal("RetentionDays"))
                        };
                    }
                }

                if (result == null)
                {
                    Debug.WriteLine("6. No enabled backup setting.");
                    return;
                }
                if (!string.IsNullOrWhiteSpace(result.BackupPath))
                {
                    await BackupDatabaseToClientPathsAsync(GetBackupFolder(), result.BackupPath,result.RetentionDays);
                }

            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine( $"BACKUP ERROR: {ex}");
                return;
            }
        }
       
        private string GetBackupFolder()
        {
            if (!string.IsNullOrWhiteSpace(_options.Value.BackupFolder))
            {
                return Environment.ExpandEnvironmentVariables(_options.Value.BackupFolder);
            }

            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"VSMART","DatabaseBackups");
        }

        private static string MakeSafeFileName(string value)
        {
            foreach (var invalidChar in Path.GetInvalidFileNameChars())
            {
                value = value.Replace(invalidChar,'_');
            }

            return value;
        }

        private static void CleanupOldBackups(string backupFolder,string databaseName, int keepLastBackups)
        {
            if (keepLastBackups <= 0)
                return;

            var files = Directory.EnumerateFiles(backupFolder, $"{databaseName}_*.bak", SearchOption.TopDirectoryOnly)
                .Select(x => new FileInfo(x))
                .OrderByDescending(x => x.CreationTimeUtc)
                .ToList();

            foreach (var file in files.Skip(keepLastBackups))
            {
                try
                {
                    file.Delete();
                }
                catch(Exception ex)
                {
                    throw;
                   
                }
            }
        }

        public async Task BackupDatabaseToClientPathsAsync(string sourceBackupPath, string backupPaths, int retentionDays)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceBackupPath))
                    throw new Exception("Source backup path is not configured.");

                if (!Directory.Exists(sourceBackupPath))
                    throw new DirectoryNotFoundException(
                        $"Source backup folder not found: {sourceBackupPath}");

                if (string.IsNullOrWhiteSpace(backupPaths))
                    return;

                var latestBackupFile = Directory
                    .GetFiles(sourceBackupPath, "*.bak")
                    .Select(x => new FileInfo(x))
                    .OrderByDescending(x => x.CreationTime)
                    .FirstOrDefault();

                if (latestBackupFile == null)
                    throw new Exception(
                        $"No .bak backup file found in: {sourceBackupPath}");

                var clientPaths = backupPaths
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                var thresholdDate =
                    DateTime.Now.AddDays(-retentionDays);

                foreach (var clientPath in clientPaths)
                {
                    try
                    {
                        // IMPORTANT:
                        // If E:\ / D:\ / F:\ does not exist,
                        // don't create it and don't fail logout.
                        if (!Directory.Exists(clientPath))
                        {
                            Console.WriteLine(
                                $"Backup path does not exist. Skipping: {clientPath}");

                            continue;
                        }

                        var destinationPath = Path.Combine(clientPath, "ERP_DB_BackUp");

                        Directory.CreateDirectory(destinationPath);

                        var destinationFile = Path.Combine(
                            destinationPath,
                            latestBackupFile.Name);

                        File.Copy(
                            latestBackupFile.FullName,
                            destinationFile,
                            true);

                        // Delete old backups
                        if (retentionDays > 0)
                        {
                            var oldFiles = Directory
                                .GetFiles(destinationPath, "*.bak")
                                .Select(x => new FileInfo(x))
                                .Where(x => x.CreationTime < thresholdDate)
                                .ToList();

                            foreach (var oldFile in oldFiles)
                            {
                                try
                                {
                                    oldFile.Delete();
                                }
                                catch
                                {
                                    // Ignore individual delete failure
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Backup failed for '{clientPath}': {ex.Message}");
                    }
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
