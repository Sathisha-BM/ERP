using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.ProductionSummaryVM
{
	public class OperationSummaryVM
	{
		public long SlNo { get; set; }

		public string Operator { get; set; }

		public decimal TotalTargetQty { get; set; }

		public string OperatorEfficiency { get; set; }

		public decimal TotalQtyProduced { get; set; }

		public decimal TotalQtyRejected { get; set; }

		public string OperatorProdForActualMcHrs { get; set; }

		//public string FinalEfficiency { get; set; }

	}
}
