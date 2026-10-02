using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.InspectionViewModel
{
    public class InspectionVM
    {
        public int InspectId { get; set; }
        public int? SlNo { get; set; }
        public string? CustName { get; set; }
        public string? InspectionNo { get; set; }
        public string? Suffix { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? GRNNo { get; set; }
        public string? DCNo { get; set; }
        public DateTime? DCDate { get; set; }
        public decimal? Qty { get; set; }
        public decimal? AcceptQty { get; set; }
        public decimal? ReWorkQty { get; set; }
        public decimal? RejectQty { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
