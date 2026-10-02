using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.Master.MasterScreeenManagement_Module;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IMasterServices
{
	public interface IMessengerScreenUserSettingService
	{
		Task<List<MessengerScreenUserSetting>> GetByScreenIdAsync(int screenId);

		//Task SaveAsync(int screenId, List<int> userIds);
		Task SaveAsync(int screenId,int fromUserId,List<int> userIds);



		Task DeleteByScreenIdAsync(int screenId);
	}
}
