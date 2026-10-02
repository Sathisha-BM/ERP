using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IDBBackupSetting_Service;
using V.SMART.Shared.Data.BackupSetting;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.BackupSettingVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.DBBackupSetting_Service
{
    public class DBBackupSettingService : IDBBackupSettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CurrentUserService _currentUserService;

        public DBBackupSettingService(IUnitOfWork unitOfWork,IMapper mapper,CurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<DBBackupSettingVM?> GetBySystemIdAsync(int systemId)
        {
            try
            {
                var entity = await _unitOfWork.DBBackupSettings
                       .GetQueryable()
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.SystemId == systemId);

                if (entity == null)
                    return null;

                return _mapper.Map<DBBackupSettingVM>(entity);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<DBBackupSettingVM?> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _unitOfWork.DBBackupSettings
                        .GetQueryable()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                    return null;

                return _mapper.Map<DBBackupSettingVM>(entity);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<DBBackupSettingVM> SaveAsync(DBBackupSettingVM model)
        {
            try
            {
                var existing = await _unitOfWork.DBBackupSettings
                        .GetQueryable()
                        .FirstOrDefaultAsync(x => x.Id == model.Id);

                if (existing == null)
                {
                    var entity = _mapper.Map<DBBackupSetting>(model);

                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = await _currentUserService.GetUsernameAsync();

                    await _unitOfWork.DBBackupSettings.CreateAsync(entity);
                }
                else
                {
                    existing.SystemId = model.SystemId;
                    existing.DatabaseName = model.DatabaseName;
                    existing.BackupPath = model.BackupPath;
                    existing.BackupType = model.BackupType;
                    existing.Frequency = model.Frequency;
                    existing.BackupTime = model.BackupTime;
                    existing.RetentionDays = model.RetentionDays;
                    existing.IsEnabled = model.IsEnabled;

                    existing.ModifiedDate = DateTime.Now;
                    existing.ModifiedBy = await _currentUserService.GetUsernameAsync();
                }

                await _unitOfWork.SaveAsync();

                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _unitOfWork.DBBackupSettings
                        .GetQueryable()
                        .FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                    return false;

               await _unitOfWork.DBBackupSettings.DeleteAsync(entity);

                await _unitOfWork.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task BackupDatabaseToClientPathsAsync(string sourceBackupPath,string backupPaths,int retentionDays)
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

                        var destinationPath = Path.Combine(clientPath,"ERP_DB_BackUp");

                        // Create ERP_DB_BackUp only when
                        // the configured client path exists.
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
                        // One client path failure must not stop logout.
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

        public async Task<DBBackupSettingVM?> GetEnabledSettingAsync()
        {

            Debug.WriteLine("GetEnabledSettingAsync START");

            var entity = await _unitOfWork.DBBackupSettings
                .GetQueryable()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IsEnabled);

            Debug.WriteLine(
                $"GetEnabledSettingAsync RESULT: {entity != null}");

            if (entity == null)
                return null;

            return _mapper.Map<DBBackupSettingVM>(entity);
        }

    }

}
