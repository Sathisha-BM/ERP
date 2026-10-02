using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Services.Database_Backup
{
    public sealed class DatabaseBackupOptions
    {
        public bool Enabled { get; set; } = true;

        public string BackupFolder { get; set; } = string.Empty;

        public bool OnlyWhenDatabaseChanged { get; set; } = true;

        public bool DeleteOldBackups { get; set; } = true;

        public int KeepLastBackups { get; set; } = 5;
    }
}
