
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.ReportViewModel.MaterialStockLeftVM;
using V.SMART.Shared.ViewModels.ReportViewModel.RatingsVM;
using PartyVM = V.SMART.Shared.ViewModels.ReportViewModel.RatingsVM.PartyVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService
{
    public interface IMaterialstockLeftService
    {
       
        Task<List<MaterialStockLeftVM>> GetPartyPendingAsync(string partyType,string? partyId, DateTime? FromDate,
            DateTime? ToDate);

        Task<List<PartyVM>> GetPartiesAsync(
        string selectedType,
        DateTime? fromDate,
        DateTime? toDate);
    }
}
