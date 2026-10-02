using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using V.SMART.Shared.ViewModels.ReportViewModel.ProductionSummaryVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.IProductionSummaryService
{
	public interface IOperatorSummaryService
	{

		Task<List<OperationSummaryVM>> GetOperatorSummary(DateTime fromDate, DateTime toDate);

	}
}
