using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.MasterViewModel.GeneralViewModel;
using V.SMART.Shared.ViewModels.ReportViewModel.VendorRatingVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService
{
    public interface IVenderratingService
    {
        Task<List<VendorVM>> GetAllVendorsAsync(
          string SelectedType,
          DateTime fromdate,
          DateTime todate);

        Task<List<VendorRatingVM>> GetRatings(
            string SelectedType,
            string partyId,
            DateTime? fromDate,
            DateTime? toDate);
    }
}
