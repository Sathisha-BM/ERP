
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels;
using V.SMART.Shared.ViewModels.ReportViewModel.InspectionViewModel;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.IIncomingInspectionService
{
    public interface IIncomInspectionService
    {
        Task<int> GetScreenCodeByScreenNameAsync(string screenName);
        Task<IEnumerable<ItemVM>> SearchItemsAsync(string searchText);
        Task<List<InspectionVM>> GetInspectionReportAsync(DateTime? fromDate, DateTime? toDate, string? toWhom);
    }
}
