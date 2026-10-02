using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data;
using V.SMART.Shared.Data.Master.MasterScreeenManagement_Module;
using V.SMART.Shared.Repository.IRepository.ISettingsRepository;
using V.SMART.Shared.Services;

namespace V.SMART.Shared.Repository.SettingsRepository
{
    public class CustomScreenSettingRepository : Repository<CustomScreenSetting>, ICustomScreenSettingRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILoggingService _logs;
        private readonly CurrentUserService _currentUserService;

        public CustomScreenSettingRepository(ApplicationDbContext db, ILoggingService logs, CurrentUserService currentUserService) : base(db, logs)
        {
            _db = db;
            _logs = logs;
            _currentUserService = currentUserService;
        }
        
    }
}
