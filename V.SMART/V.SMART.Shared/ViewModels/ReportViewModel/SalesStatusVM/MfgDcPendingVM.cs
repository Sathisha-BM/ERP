using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.DcPendingModel
{
    public class MfgDcPendingVM
    {
        public long SlNo { get; set; }
        public string? Customer { get; set; }
        public string? Prefix { get; set; }
        public string? DcNo { get; set; }
        public DateTime? DcDate { get; set; }
        public string? PONo { get; set; }
        public DateTime? PODate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? MainRemark { get; set; }
        //public string? Type { get; set; }
        public string? DcStatus { get; set; }
        //public string? PayTerms { get; set; }
        //public string? DeliveryTems { get; set; }
        public int? ModeofTrasnport { get; set; }
        public string? VehicleNo { get; set; }
        public string? CancelReason { get; set; }
        public string? TransFrom { get; set; }
        public string? TransTo { get; set; }
        public string? TransName { get; set; }
        //public DateTime? Canceldate { get; set; }
        //public string? CancelBy { get; set; }
        //public string? RejectReason { get; set; }

        //itemDeatails
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? Specification { get; set; }
        public string? MeasureUnit { get; set; }
        public string? HSNCode { get; set; }

        //subtable
        public decimal? Qty { get; set; }
        public decimal? UnitPrice { get; set; }
        //public decimal? LineBasicAmount { get; set; }
        public decimal? BalQty { get; set; }
        public decimal? RejectedQty { get; set; }
        public decimal? RewQty { get; set; }
        public string? ItemStatus { get; set; }
        public string? ItemCancelReason { get; set; }
        public string? ItemRemarks { get; set; }
        //
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
