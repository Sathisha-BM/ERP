using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using V.SMART.Shared.ViewModels.ReportViewModel.ProdAssStatusVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService
{
    public interface IProductionReportService
    {
        Task<List<ProductionReportVM>> GetProductionReport(DateTime? fromDate, DateTime? toDate, string reportType);
       
    }
}