using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.GSTITCVM
{
    public class GSTR1VM
    {
        // Common Invoice Details
        public int InvId { get; set; }

        public string? Prefix { get; set; }

        public string? InvNo { get; set; }

        public string? Suffix { get; set; }

        public DateTime? InvDate { get; set; }

        public int? CustId { get; set; }

        public string? CustName { get; set; }

        public string? GSTNo { get; set; }

        public int? StateId { get; set; }

        public string? StateName { get; set; }

        // Item Details
        public string? ItemCode { get; set; }

        public string? ItemName { get; set; }

        public string? HSNCode { get; set; }

        public string? MeasureUnit { get; set; }

        public decimal Qty { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineGross { get; set; }

        public decimal LineDiscountAmount { get; set; }

        public decimal LineBasicAmount { get; set; }

        // Tax Rates
        public decimal LineCGSTRate { get; set; }

        public decimal LineSGSTRate { get; set; }

        public decimal LineIGSTRate { get; set; }

        // Tax Amounts
        public decimal TotalCGSTAmount { get; set; }

        public decimal TotalSGSTAmount { get; set; }

        public decimal TotalIGSTAmount { get; set; }

        public decimal TotalTaxable { get; set; }

        public decimal GrandTotal { get; set; }

        // EXEMP (Nil-rated / Exempted / Non-GST breakdown - currently unused,
        // kept for future use if you split these out in the SP)
        public decimal NilRated { get; set; }

        public decimal Exempted { get; set; }

        public decimal NonGST { get; set; }

        // CDNR
        public string? DocumentType { get; set; }      // Credit Note / Debit Note

        public string? NoteType { get; set; }          // C / D

        public string? NoteNumber { get; set; }

        public DateTime? NoteDate { get; set; }

        public string? OriginalInvoiceNo { get; set; }

        public DateTime? OriginalInvoiceDate { get; set; }

        public string? PreGST { get; set; }            // Y / N

        public string? Reason { get; set; }

        public decimal TaxRate { get; set; }

        public decimal CessAmount { get; set; }

        // Additional CDNR Fields (GST Offline Utility)
        public string? PlaceOfSupply { get; set; }

        public string? ReverseCharge { get; set; }

        public string? NoteSupplyType { get; set; }

        public decimal NoteValue { get; set; }

        public string? Type { get; set; }

        public string? ApplicableTaxRate { get; set; }

        public string? ECommerceGSTIN { get; set; }

        public string NatureOfDocument { get; set; } = "";

        public string SrNoFrom { get; set; } = "";

        public string SrNoTo { get; set; } = "";

        public int TotalNumber { get; set; }

        public int Cancelled { get; set; }

        public int NetIssued { get; set; }

        // EXEMP/EXP - Export invoice fields (@Section = 'EXEMP' actually reads
        // from the ExpInv table in the stored procedure, i.e. Exports, not
        // true nil-rated/exempt supplies). Needed by GSTR1Service.FillExempt.
        // NOTE: the stored procedure currently returns these as empty
        // placeholders - update USP_GSTR1 to select the real ExpInv columns
        // once you confirm their names.
        public string? ExportType { get; set; }

        public string? PortCode { get; set; }

        public string? ShippingBillNumber { get; set; }

        public DateTime? ShippingBillDate { get; set; }
    }
}