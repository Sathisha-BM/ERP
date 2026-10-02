using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.HumanResourceViewModel.ProcessEmployeeAssignVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IProductionService.IProductionAttendancelogService
{
	public interface IProductionAttendancelogService
	{

        Task<List<ProductionAttendancelogVM>> GetAssignedEmployeesAsync(int weekNo, int processId);

        Task<List<ProcessEmployeeAssignVM>> GetAllWeeks();

        Task<int> SaveAttendanceAsync(List<ProductionAttendancelogVM> attendance);

        Task<List<ProductionAttendancelogVM>> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int weekNo, int processId);

        Task<(List<ProductionAttendancelogVM> Attendance, int TotalCount)> SearchAttendanceAsync(int pageNumber, int pageSize, Dictionary<string, object>? filters);


        Task<List<ProcessEmployeeAssignVM>> GetAllExistsWeeks();

    }
}
