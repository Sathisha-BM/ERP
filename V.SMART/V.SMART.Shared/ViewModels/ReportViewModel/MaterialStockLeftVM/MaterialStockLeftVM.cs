using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.MaterialStockLeftVM
{
    public class MaterialStockLeftVM
    {
        public int? SlNo { get; set; }
        public long? PartyId { get; set; }
        public string? CustName { get; set; }
        public long? POId { get; set; }
        public string? PONo { get; set; }
        public DateTime? PODate { get; set; }

        public string? LPONo { get; set; }
        public DateTime? LPODate { get; set; }

        public string? DcNo { get; set; }
        public DateTime? DCDate { get; set; }
        public string? GRNNo { get; set; }
        public DateTime? GRNDate { get; set; }
        public long? DCItemId { get; set; }
        public string? DCItemCode { get; set; }
        public string? DCItemName { get; set; }
        public long? GRNItemId { get; set; }
        public string? GRNItemCode { get; set; }
        public string? GRNItemName { get; set; }
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public decimal? POQty { get; set; }
        public decimal? DcQty { get; set; }
        public decimal? GRNQty { get; set; }
        public decimal? BalQty { get; set; }
        public decimal? BQty { get; set; }
        public decimal? RCQty { get; set; }
        public decimal? AccQty { get; set; }
        public decimal? RejQty { get; set; }

        public decimal? ReturnQty { get; set; }

        public decimal? RewQty { get; set; }
        public decimal? Qty { get; set; }
        public decimal? UtilQty { get; set; }
        public decimal? ReqQty { get; set; }
        public string? IssueNo { get; set; }
        public string? IssueDate { get; set; }
        public string? JobNo { get; set; }
        public string? JobDate { get; set; }
        public string? JobType { get; set; }
        public decimal? JobOrderQty { get; set; }
        public decimal? JobBalQty { get; set; }
        public long? CustId { get; set; }
        public long? ItemId { get; set; }
        public long? RefPoSubId { get; set; }
        public long? RcSubId { get; set; }
        public long? AssyId { get; set; }
        public string? AssyItemCode { get; set; }
        public string? AssyItemName { get; set; }
        public string? LogNo { get; set; }
        public string? LogDate { get; set; }
        public string? RCNo { get; set; }
        public string? RCDate { get; set; }
        public string? ProcessName { get; set; }
        public string? MachineName { get; set; }
        public string? IOSItemCode { get; set; }
        public string? IOSItemName { get; set; }
        public string? AddStore { get; set; }
        public string? ReturnNo { get; set; }
        public string? ReturnDate { get; set; }
        public string? RefPoNo { get; set; }
        public string? RefRcNo { get; set; }
        public string? RefIssNo { get; set; }
        public string? FROMSTORE { get; set; }
        public string? SCNNo { get; set; }
        public string? RefGrnNo { get; set; }
        public string TOSTORE { get; set; }
        public string? RefIssueNo { get; set; }
        public string? ReturnBy { get; set; }
        public string? TransType { get; set; }
        public string? BatchNo { get; set; }

        public long RCId { get; set; }
    }
}
