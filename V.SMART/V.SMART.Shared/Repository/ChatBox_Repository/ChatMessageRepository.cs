using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data;
using V.SMART.Shared.Data.Master.ChatBox_Module;
using V.SMART.Shared.Repository.IRepository.IMasterRepository.IChatBox;
using V.SMART.Shared.Services;

namespace V.SMART.Shared.Repository.MasterRepository.ChatBox
{
	public class ChatMessageRepository: Repository<ChatMessage>,IChatMessageRepository
	{

		private readonly ApplicationDbContext _db;
		private readonly ILoggingService _loggingService;
		private readonly CurrentUserService _currentUserService;
		public ChatMessageRepository(ApplicationDbContext db,
			ILoggingService loggingService,
			CurrentUserService currentUserService)
			: base(db, loggingService)
		{

			_db = db;
			_loggingService = loggingService;
			_currentUserService = currentUserService;

		}

	}
}
