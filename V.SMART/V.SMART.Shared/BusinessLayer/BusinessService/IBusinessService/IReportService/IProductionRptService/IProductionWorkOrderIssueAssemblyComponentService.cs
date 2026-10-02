using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.MasterViewModel.GeneralViewModel;
using V.SMART.Shared.ViewModels.ReportViewModel.ProductionWorkOrder;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService
{
    public interface IProductionWorkOrderIssueAssemblyComponentService
    {

        Task<List<CustomerVM>> GetAllCustomerAsync(
         string SelectedType,
         DateTime fromdate,
         DateTime todate);

        Task<List<ProductionWorkOrderVM>> GetProductionWorkOrderIssueAsync(bool? detailsView, string? selectedType,
                                                              string? selectedParty, DateTime? fromDate, DateTime? toDate);
    }

}
