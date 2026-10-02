using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.BackupSettingVM
{
    public class DBBackupSettingVM
    {

        public int Id { get; set; }

        public int? SystemId { get; set; }

        public string DatabaseName { get; set; } = string.Empty;

        public string BackupPath { get; set; } = string.Empty;

        public string BackupType { get; set; } = "FULL";

        public string Frequency { get; set; } = "DAILY";

        public TimeOnly? BackupTime { get; set; }
        public int RetentionDays { get; set; } = 30;

        public bool IsEnabled { get; set; } = true;

        public DateTime? LastBackupDate { get; set; }

        public string? LastBackupFile { get; set; }

        public string? LastBackupStatus { get; set; }

        public string? LastBackupMessage { get; set; }

        // Multiple backup paths
       

    }
}
