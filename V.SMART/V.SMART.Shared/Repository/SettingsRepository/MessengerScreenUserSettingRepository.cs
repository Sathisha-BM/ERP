using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data;
using V.SMART.Shared.Data.Master.MasterScreeenManagement_Module;
using V.SMART.Shared.Repository.IRepository.IMasterRepository.IMasterSettings;
using V.SMART.Shared.Services;

namespace V.SMART.Shared.Repository.MasterRepository.MasterSettings
{
	public class MessengerScreenUserSettingRepository : Repository<MessengerScreenUserSetting>, IMessengerScreenUserSettingRepository
	{

		private readonly ApplicationDbContext _db;
		private readonly ILoggingService _loggingService;
		private readonly CurrentUserService _currentUserService;

		public MessengerScreenUserSettingRepository(ApplicationDbContext db, ILoggingService loggingService, CurrentUserService currentUserService) : base(db, loggingService)
		{

			_db = db;
			_loggingService = loggingService;
			_currentUserService = currentUserService;
		}
	}

	
}
