using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.ProductionWorkOrder
{
    public class ProductionWorkOrderVM
    {

        public int SlNo { get; set; }

        public string? JobNo { get; set; }
        public string? JobDate { get; set; }

        public string? CustName { get; set; }

        public string? PONo { get; set; }
        public string? PODate { get; set; }

        public string? JobType { get; set; }

        public decimal JobOrderQty { get; set; }
        public decimal JobBalQty { get; set; }

        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }

        public string? AssyItemCode { get; set; }
        public string? AssyItemName { get; set; }

        public decimal UtilQty { get; set; }
        public decimal ReqQty { get; set; }
        public decimal BalQty { get; set; }

        public string? IssueNo { get; set; }
        public string? IssueDate { get; set; }

        public int CustId { get; set; }
        public int ItemId { get; set; }

        public decimal Qty { get; set; }

        public int RefPoSubId { get; set; }
        public int RcSubId { get; set; }

        public int AssyId { get; set; }

        public string? AddStore { get; set; }
        public string? ReturnNo { get; set; }
        public string? ReturnDate { get; set; }

        public string? RefPoNo { get; set; }
        public string? RefRcNo { get; set; }
        public string? RefIssNo { get; set; }

        public string? FROMSTORE { get; set; }
        public string? SCNNo { get; set; }
        public string? RefGrnNo { get; set; }
        public string? TOSTORE { get; set; }

        public decimal RejQty { get; set; }

        public string? RefIssueNo { get; set; }
        public string? ReturnBy { get; set; }

        public string? TransType { get; set; }
        public string? BatchNo { get; set; }


        public string? IssueToWhom { get; set; }

        public decimal? NoOfItems { get; set; }

        public string? CreatedBy { get; set; }

        public string? CreatedDate { get; set; }


        public string? RCDATE { get; set; }

        public string? ProcessName { get; set; }

        public string? MachineName { get; set; }
    }
}
