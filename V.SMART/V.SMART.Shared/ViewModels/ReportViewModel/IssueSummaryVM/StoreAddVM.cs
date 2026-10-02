using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.IssueSummaryVM
{
    public class StoreAddVM
    {
        public int? SlNo { get; set; }
        public string? StoreAddNo { get; set; }
        public DateTime? StoreAddDate { get; set; }
        public string? StoreName { get; set; }
        public string? Type { get; set; }

        public string? AssemblyName { get; set; }
        public string? SubAssemblyName { get; set; }
        public string? SubAssemblyName2 { get; set; }
        public string? SubAssemblyName3 { get; set; }
        public decimal? ReqQty { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }

        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UtlQty { get; set; }
        public string? ItemWiseRemark { get; set; }
    }
}
