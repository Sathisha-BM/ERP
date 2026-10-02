
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels;
using V.SMART.Shared.ViewModels.ReportViewModel.SummaryViewModel;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.IMatIssueNoteSumService
{
    public interface IMaterialIssueNoteSummaryService
    {
       // Task<IEnumerable<CustomerVM>> SearchCustomersAsync(string searchText);
        Task<int> GetScreenCodeByScreenNameAsync(string screenName);
        Task<IEnumerable<ItemVM>> SearchItemsAsync(string searchText);
        //Task<List<Customer>> GetSalesCustomersAsync();

        Task<List<MaterialIssueReportVM>> GetMINSummaryReportAsync(DateTime? fromDate,DateTime? toDate,string? toWhom);
    }
}
