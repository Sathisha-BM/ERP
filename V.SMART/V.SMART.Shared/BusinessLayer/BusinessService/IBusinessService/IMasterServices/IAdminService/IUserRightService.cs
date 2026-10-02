using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.Master.Admin;
using V.SMART.Shared.ViewModels.MasterViewModel.AdminViewmodel;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IMasterServices.IAdminService
{
    public interface IUserRightService
    {
        Task SyncRightsForUserAsync(int userId);

        Task<List<UserRight>> GetUserRightsByUserIdAsync(int userId);

        Task<UserVM?> GetLoggedUserDetailsAsync(int userId);
    }
}
