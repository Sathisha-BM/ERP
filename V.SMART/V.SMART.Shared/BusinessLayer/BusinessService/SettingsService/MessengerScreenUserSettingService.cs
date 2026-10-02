using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IMasterServices;
using V.SMART.Shared.Data.Master.MasterScreeenManagement_Module;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;

namespace V.SMART.Shared.BusinessLayer.BusinessService.MasterService
{
	public class MessengerScreenUserSettingService: IMessengerScreenUserSettingService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly ILoggingService _logs;
		private readonly CurrentUserService _userService;
		private readonly ICommonService _commonService;
		private readonly ForeignKeyUsageChecker _fkChecker;

		public MessengerScreenUserSettingService(IUnitOfWork unitOfWork, IMapper mapper, ILoggingService loggingService,
							CurrentUserService userService, ICommonService commonService,
							ForeignKeyUsageChecker foreignKeyUsageChecker)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_logs = loggingService;
			_userService = userService;
			_commonService = commonService;
			_fkChecker = foreignKeyUsageChecker;
		}

		public async Task DeleteByScreenIdAsync(int screenId)
		{
			var existing = (await _unitOfWork.MessengerScreenUserSettings.GetAllAsync())
	   .Where(x => x.ScreenCode == screenId && x.IsActive)
	   .ToList();

			foreach (var item in existing)
			{
				item.IsActive = false;
				item.ModifiedDate = DateTime.Now;

				_unitOfWork.MessengerScreenUserSettings.UpdateAsync(item);
			}

			await _unitOfWork.SaveAsync();
		}

		public async Task<List<MessengerScreenUserSetting>> GetByScreenIdAsync(int screenId)
		{
			return (await _unitOfWork.MessengerScreenUserSettings.GetAllAsync())
	  .Where(x => x.ScreenCode == screenId && x.IsActive)
	  .ToList();
		}



		//public async Task SaveAsync(int screenId, int fromUserId, List<int> userIds)
		//{

		//	var existing =(await _unitOfWork.MessengerScreenUserSettings.GetAllAsync())
		//   .Where(x =>x.ScreenCode == screenId &&   x.FromUserId == fromUserId).ToList();
		//	var currentUsername =await _userService.GetUsernameAsync();
		//	var selectedIds = userIds.Distinct().ToList();

		//	//// Deactivate old settings
		//	//foreach (var item in existing)
		//	//{
		//	//	item.IsActive = false;
		//	//	item.ModifiedDate = DateTime.Now;
		//	//	item.ModifiedBy = currentUsername;

		//	//	await _unitOfWork.MessengerScreenUserSettings
		//	//		.UpdateAsync(item);
		//	//}

		//	await _unitOfWork.MessengerScreenUserSettings.DeleteAsync(item);

		//	foreach (var item in existing)
		//	{
		//		if (item.UserId.HasValue &&
		//			selectedIds.Contains(item.UserId.Value))
		//		{
		//			// User is still selected
		//			item.IsActive = true;
		//		}
		//		else
		//		{
		//			// User was removed
		//			item.IsActive = false;
		//		}

		//		item.ModifiedDate = DateTime.Now;
		//		item.ModifiedBy = currentUsername;

		//		await _unitOfWork.MessengerScreenUserSettings.UpdateAsync(item);
		//	}


		//	//	// Create new settings
		//	//	foreach (var userId1 in userIds.Distinct())
		//	//{
		//	//	// Don't allow From User as Receiver
		//	//	if (userId1 == fromUserId)
		//	//		continue;

		//	//	var entity = new MessengerScreenUserSetting
		//	//	{
		//	//		ScreenCode = screenId,

		//	//		// Who is sending / triggering
		//	//		FromUserId = fromUserId,

		//	//		// Who receives
		//	//		UserId = userId1,

		//	//		IsActive = true,

		//	//		CreatedDate = DateTime.Now,
		//	//		CreatedBy = currentUsername
		//	//	};

		//	//	await _unitOfWork.MessengerScreenUserSettings
		//	//		.CreateAsync(entity);
		//	//}

		//	//await _unitOfWork.SaveAsync();
		//	foreach (var AssiuserId in selectedIds)
		//	{
		//		var existing1 = existing
		//			.FirstOrDefault(x =>
		//				x.UserId == AssiuserId);

		//		if (existing1 != null)
		//			continue;

		//		var newSetting = new MessengerScreenUserSetting
		//		{
		//			ScreenCode = screenId,
		//			FromUserId = fromUserId,
		//			UserId = AssiuserId,
		//			IsActive = true,
		//			CreatedDate = DateTime.Now,
		//			CreatedBy = currentUsername
		//		};

		//		await _unitOfWork.MessengerScreenUserSettings.CreateAsync(newSetting);
		//	}

		//	await _unitOfWork.SaveAsync();
		//}

		public async Task SaveAsync(int screenId, int fromUserId, List<int> userIds)
		{
			var currentUsername = await _userService.GetUsernameAsync();

			var selectedIds = userIds.Distinct()
				.Where(x => x != fromUserId)   // Don't assign FromUser to himself
				.ToList();

			// Get existing assignments
			var existing = (await _unitOfWork.MessengerScreenUserSettings.GetAllAsync())
				.Where(x =>
					x.ScreenCode == screenId &&
					x.FromUserId == fromUserId)
				.ToList();

			// Delete all old assignments
			foreach (var item in existing)
			{
				await _unitOfWork.MessengerScreenUserSettings.DeleteAsync(item);
			}

			// Create the current assignments
			foreach (var userId in selectedIds)
			{
				var newSetting = new MessengerScreenUserSetting
				{
					ScreenCode = screenId,
					FromUserId = fromUserId,
					UserId = userId,
					IsActive = true,
					CreatedDate = DateTime.Now,
					CreatedBy = currentUsername
				};

				await _unitOfWork.MessengerScreenUserSettings.CreateAsync(newSetting);
			}

			// Actually save all deletes + inserts
			await _unitOfWork.SaveAsync();
		}
	}
}
