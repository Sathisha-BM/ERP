
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService;
using V.SMART.Shared.ViewModels.ReportViewModel.ProdAssStatusVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.ReportService.TrackReportService
{
    public class ProductionReportService : IProductionReportService
    {
        private readonly IReportExecutor _report;

        public ProductionReportService(IReportExecutor report)
        {
            _report = report;
        }

        public async Task<List<ProductionReportVM>> GetProductionReport(DateTime? fromDate,DateTime? toDate,string reportType)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@FromDate",
                    fromDate.HasValue
                        ? fromDate.Value
                        : (object)DBNull.Value),

                new SqlParameter("@ToDate",
                    toDate.HasValue
                        ? toDate.Value
                        : (object)DBNull.Value),

                new SqlParameter("@ReportType",
                    string.IsNullOrWhiteSpace(reportType)
                        ? "DAILY"
                        : reportType)
            };

            var result = await _report.ExecuteAsync<ProductionReportVM>("SP_DailyProductionSummaryReport",parameters);

            return result ?? new List<ProductionReportVM>();
        }
    }
}

