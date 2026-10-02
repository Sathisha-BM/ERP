using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.Master.HumanResourceMaster_Module.V.SMART.Shared.Data.Master.HumanResourceMaster_Module;
using V.SMART.Shared.ViewModels.HumanResourceViewModel.ProcessEmployeeAssignVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IHumanResourceService.IProcessEmployeeAssignService
{

    public interface IProcessEmployeeAssignService
    {
        Task<List<Staff>> GetAllStaffAsync();
        Task<int> GetNextWeekNo();

        Task<int> UpsertprocessEmployee(ProcessEmployeeAssignVM model);

        Task<bool> IsEmployeeAssignedToProcessAsync(ProcessEmployeeAssignVM model);

        Task<(List<ProcessEmployeeAssignVM> processes, int TotalCount)> SearchWithDynamicFilterAsync(int pageNumber, int pageSize, Dictionary<string, object>? filters);

        Task<(bool CanDelete, string Message)> CanDeleteProcessAsync(int processId);

        Task<ProcessEmployeeAssignVM> GetProcessEmployeeAssignByIdAsync(int assignmentId);

        Task<bool> DeleteAsync(int weekNo, int processId);
    }
}
