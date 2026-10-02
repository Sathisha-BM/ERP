using DocumentFormat.OpenXml.Bibliography;
using FastReport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.IProductionSummaryService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService;

using V.SMART.Shared.ViewModels.ReportViewModel.ProductionSummaryVM;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService;
using V.SMART.Shared.ViewModels;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using SqlParameter = Microsoft.Data.SqlClient.SqlParameter;

namespace V.SMART.Shared.BusinessLayer.BusinessService.ReportService.ProductionSummaryService
{
	public class OperatorSummaryService : IOperatorSummaryService
	{

		private readonly IReportExecutor _report;

		private readonly ICommonService _commonService;

		public OperatorSummaryService(IReportExecutor report, ICommonService commonService)
		{
			_report = report;

			_commonService = commonService;
		}
		public async Task<List<OperationSummaryVM>> GetOperatorSummary(DateTime fromDate, DateTime toDate)
		{

			var parameters = new[]
			{
			new SqlParameter("@FromDate", fromDate),
			new SqlParameter("@ToDate", toDate)
			};
			var result = await _report.ExecuteAsync<OperationSummaryVM>("Sp_GetProductionOperatorSummary", parameters);
			return result ?? new List<OperationSummaryVM>(); ;	
		}

	
	}
}
