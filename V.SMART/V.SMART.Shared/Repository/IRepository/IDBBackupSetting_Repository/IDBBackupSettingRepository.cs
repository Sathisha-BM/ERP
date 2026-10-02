using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.BackupSetting;

namespace V.SMART.Shared.Repository.IRepository.IDBBackupSetting_Repository
{
    public interface IDBBackupSettingRepository: IRepository<DBBackupSetting>
    {
        Task<DBBackupSetting?> GetBySystemIdAsync(int systemId);

        Task<DBBackupSetting?> GetByIdAsync(int id);
    }
}
