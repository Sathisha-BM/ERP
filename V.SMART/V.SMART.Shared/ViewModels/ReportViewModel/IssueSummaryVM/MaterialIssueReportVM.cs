using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.SummaryViewModel
{
    public class MaterialIssueReportVM
    {
        public int SlNo { get; set; }
        public string? IssueNo { get; set; }
        public string? Suffix { get; set; }

        public DateTime? IssueDate { get; set; }
        public string? Type { get; set; }

        public string? ToWhom { get; set; }

        public string? MainRemark { get; set; }

        public int? NoOfItems { get; set; }

        public string? StoreName { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? AssemblyName { get; set; }

        public string? SubAssemblyName { get; set; }

        public string? SubAssemblyName2 { get; set; }
        public string? SubAssemblyName3 { get; set; }
        public string? ItemCode { get; set; }

        public string? ItemName { get; set; }

        public decimal? IssueQty { get; set; }

        public decimal? Rate { get; set; }

        public decimal? Amount { get; set; }
    }
}
