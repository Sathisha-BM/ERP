using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels;
using V.SMART.Shared.ViewModels.CustomScreenViewModel;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.ISettingsService
{
    public interface ICustomScreenSettingService
    {
        Task<CustomScreenSettingVM> UpsertCustomScreenAsync(CustomScreenSettingVM CustomScreenSettingVMs, int screenCode);
        Task<int> GetScreenCodeByScreenNameAsync(string screenName);

        Task<List<CustomScreenSettingVM>> GetAllCustomScreenAsync();

        Task DeleteAndResequenceAsync(CustomScreenSettingVM subitem, int screenCode);

        Task<List<CustomScreenSettingVM>> GetAllHeadersAsync();
        Task<List<ScreensVM>> GetAllScreensAsync();

        Task DeleteHeaderAsync(int CustomId, int screenCode);


        Task<List<CustomScreenSettingVM>> GetNavigationMenuAsync();

        Task<bool> IsCustomNavigationRequiredAsync();

    }
}
