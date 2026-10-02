using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Services.Database_Backup
{
    public sealed class DatabaseBackupResult
    {
        public bool Success { get; init; }

        public string Message { get; init; } = string.Empty;

        public string? BackupFile { get; init; }

        public DateTime CompletedAt { get; init; }
    }
}
