using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.BackupSettingVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IDBBackupSetting_Service
{
    public interface IDBBackupSettingService
    {
        Task<DBBackupSettingVM?> GetBySystemIdAsync(int systemId);

        Task<DBBackupSettingVM?> GetByIdAsync(int id);

        Task<DBBackupSettingVM> SaveAsync(DBBackupSettingVM model);

        Task<bool> DeleteAsync(int id);

        Task BackupDatabaseToClientPathsAsync(string sourceBackupPath, string backupPaths, int retentionDays);
       
        Task<DBBackupSettingVM?> GetEnabledSettingAsync();
    }
}
