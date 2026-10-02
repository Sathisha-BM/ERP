using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.Master.MasterScreeenManagement_Module;
using V.SMART.Shared.ViewModels.CustomScreenViewModel;

namespace V.SMART.Shared.Mappings.CustomScreenSettingProfile
{
    public class CustomScreenSetting_Profile : Profile
    {
        public CustomScreenSetting_Profile()
        {
            //CreateMap<CustomScreenSetting, CustomScreenSettingVM>()
            //    .ForMember(dest => dest.ScreenName,
            //        opt => opt.MapFrom(src => src.Screen != null ? src.Screen.ScreenName : string.Empty))
            //    .ForMember(dest => dest.Navigation,
            //        opt => opt.MapFrom(src => src.Screen != null ? src.Screen.Navigation : string.Empty));

            //CreateMap<CustomScreenSettingVM, CustomScreenSetting>()
            //    .ForMember(dest => dest.Screen, opt => opt.Ignore());

            CreateMap<CustomScreenSetting, CustomScreenSettingVM>()
            .ReverseMap();
        }
    }
}
