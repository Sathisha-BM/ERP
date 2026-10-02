using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.ReportViewModel.AnalysisViewModel;
using V.SMART.Shared.ViewModels.ReportViewModel.IssueSummaryVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.IIssueSummaryService
{
    public interface IStoreAddService
    {
        Task<List<StoreAddVM>> GetStoreAddDetails(DateTime Fromdate, DateTime Todate);
    }
}
