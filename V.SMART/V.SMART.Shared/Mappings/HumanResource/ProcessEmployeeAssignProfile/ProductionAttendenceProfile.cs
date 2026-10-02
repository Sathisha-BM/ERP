using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.HumanResource.ProcessEmployeeAssign;
using V.SMART.Shared.ViewModels.HumanResourceViewModel.ProcessEmployeeAssignVM;

namespace V.SMART.Shared.Mappings.HumanResource.ProcessEmployeeAssignProfile
{
    public class ProductionAttendenceProfile : AutoMapper.Profile
    {
        public ProductionAttendenceProfile()
        {
            // ========================Entity → VM========================
            CreateMap<ProductionAttendancelog, ProductionAttendancelogVM>()
                .ForMember(dest => dest.WeekName, opt => opt.MapFrom(src => src.WeekNo))
                .ForMember(dest => dest.ProcessName, opt => opt.MapFrom(src => src.Process.ProcessName));


            // ========================VM → Entity========================
            CreateMap<ProductionAttendancelogVM, ProductionAttendancelog>()
                .ForMember(dest => dest.Process, opt => opt.Ignore())
                .ForMember(dest => dest.Staff, opt => opt.Ignore());

        }
    }
}
