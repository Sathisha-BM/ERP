using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Data.BackupSetting
{
    public class DBBackupSetting
    {
        [Key]
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

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
