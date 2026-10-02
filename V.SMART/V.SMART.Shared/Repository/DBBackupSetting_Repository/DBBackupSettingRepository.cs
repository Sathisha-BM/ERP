using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data;
using V.SMART.Shared.Data.BackupSetting;
using V.SMART.Shared.Repository.IRepository.IDBBackupSetting_Repository;
using V.SMART.Shared.Services;

namespace V.SMART.Shared.Repository.DBBackupSetting_Repository
{
    public class DBBackupSettingRepository:Repository<DBBackupSetting>, IDBBackupSettingRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILoggingService _loggingService;
        private readonly CurrentUserService _currentUserService;

        public DBBackupSettingRepository(ApplicationDbContext db, ILoggingService loggingService, CurrentUserService currentUserService) : base(db, loggingService)
        {
            _db = db;
            _loggingService = loggingService;
            _currentUserService = currentUserService;
        }

        public async Task<DBBackupSetting?> GetBySystemIdAsync(int systemId)
        {
            return await _db.Set<DBBackupSetting>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.SystemId == systemId);
        }

        public async Task<DBBackupSetting?> GetByIdAsync(int id)
        {
            return await _db.Set<DBBackupSetting>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
