using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.HumanResource.ProcessEmployeeAssign;
using V.SMART.Shared.ViewModels.HumanResourceViewModel.ProcessEmployeeAssignVM;

namespace V.SMART.Shared.Mappings.HumanResource.ProcessEmployeeAssignProfile
{
    public class ProcessAssignEmployeeProfile : AutoMapper.Profile
    {
        public ProcessAssignEmployeeProfile()
        {
            // ========================Entity → VM========================
            CreateMap<ProcessEmployeeAssign, ProcessEmployeeAssignVM>()
                .ForMember(dest => dest.WeekName, opt => opt.MapFrom(src => src.WeekNo))
                .ForMember(dest => dest.ProcessName, opt => opt.MapFrom(src => src.Process.ProcessName));


            // ========================VM → Entity========================
            CreateMap<ProcessEmployeeAssignVM, ProcessEmployeeAssign>()
                .ForMember(dest => dest.Process, opt => opt.Ignore())
                .ForMember(dest => dest.Staff, opt => opt.Ignore());

         
                
        }
    }
}
