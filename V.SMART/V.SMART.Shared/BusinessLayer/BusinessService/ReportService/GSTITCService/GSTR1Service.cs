using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.IGSTITC;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IReportService.ITrackReportService;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.ReportViewModel.GSTITCVM;

namespace V.SMART.Shared.BusinessLayer.BusinessService.ReportService.GSTITCService
{
    public class GSTR1Service : IGSTR1Service
    {
        private readonly IReportExecutor _report;
        private readonly IPathProvider _pathProvider;
        private readonly IUnitOfWork _unitOfWork;

        public GSTR1Service(IReportExecutor report, IPathProvider pathProvider, IUnitOfWork unitOfWork)
        {
            _report = report;
            _pathProvider = pathProvider;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GSTR1VM>> GetGSTR1Async(DateTime fromDate, DateTime toDate, string section)
        {
            var parameters = new[]
            {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate),
                new SqlParameter("@Section", section)
            };

            var result = await _report.ExecuteAsync<GSTR1VM>("USP_GSTR1", parameters);

            return result ?? new List<GSTR1VM>();
        }

        public async Task<byte[]> ExportGSTR1JsonAsync(DateTime fromDate, DateTime toDate, string section)
        {
            var data = await GetGSTR1Async(fromDate, toDate, section);

            var gstJson = new GSTR1JsonVM
            {
                gstin = await _unitOfWork.Companies
                    .GetQueryable()
                    .Where(x => x.GSTIN != null)
                    .Select(x => x.GSTIN)
                    .FirstOrDefaultAsync() ?? "",

                fp = fromDate.ToString("MMyyyy"),

                version = "GST3.1.7",

                hash = "hash"
            };

            // =========================
            // B2B
            // =========================
            if (section.Equals("B2B", StringComparison.OrdinalIgnoreCase))
            {
                var customerGroups = data
                    .Where(x => !string.IsNullOrWhiteSpace(x.GSTNo))
                    .GroupBy(x => x.GSTNo);

                foreach (var customerGroup in customerGroups)
                {
                    var customer = new B2BJsonVM
                    {
                        ctin = customerGroup.Key ?? ""
                    };

                    // Group invoice-wise
                    var invoiceGroups = customerGroup
                        .GroupBy(x => x.InvId);

                    foreach (var invoiceGroup in invoiceGroups)
                    {
                        var first = invoiceGroup.First();

                        var invoice = new B2BInvoiceJsonVM
                        {
                            inum = $"{first.Prefix}{first.InvNo}{first.Suffix}",

                            idt = first.InvDate?.ToString("dd-MM-yyyy") ?? "",

                            val = first.GrandTotal,

                            pos = first.StateId?.ToString() ?? "",

                            rchrg = "N",

                            inv_typ = "R"
                        };

                        int itemNo = 1;

                        foreach (var item in invoiceGroup)
                        {
                            var taxRate = item.TaxRate > 0
                                ? item.TaxRate
                                : item.LineIGSTRate > 0
                                    ? item.LineIGSTRate
                                    : item.LineCGSTRate + item.LineSGSTRate;

                            invoice.itms.Add(new B2BItemJsonVM
                            {
                                num = itemNo++,

                                itm_det = new B2BItemDetailJsonVM
                                {
                                    txval = item.LineBasicAmount,

                                    rt = taxRate,

                                    iamt = item.TotalIGSTAmount,

                                    camt = item.TotalCGSTAmount,

                                    samt = item.TotalSGSTAmount,

                                    csamt = item.CessAmount
                                }
                            });
                        }

                        customer.inv.Add(invoice);
                    }

                    gstJson.b2b.Add(customer);
                }
            }

            // =========================
            // JSON SERIALIZATION
            // =========================
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,

                DefaultIgnoreCondition =
                    JsonIgnoreCondition.WhenWritingNull
            };

            var json = System.Text.Json.JsonSerializer.Serialize(
                gstJson,
                options);

            return Encoding.UTF8.GetBytes(json);
        }

        public async Task<byte[]> ExportExcelAsync(DateTime fromDate, DateTime toDate, List<string> sections)
        {
            ExcelPackage.License.SetNonCommercialOrganization("Bhargavi Soft Tech");

            string templatePath = Path.Combine(_pathProvider.GetReportTemplatePath(), "GSTR1_Excel_Workbook_Template_V2.0.xlsx");

            using var package = new ExcelPackage(new FileInfo(templatePath));

            foreach (var section in sections)
            {
                var data = await GetGSTR1Async(fromDate, toDate, section);

                switch (section)
                {
                    case "B2B":
                        FillB2B(package, data);
                        break;

                    case "B2CL":
                        FillB2CL(package, data);
                        break;

                    case "B2CS":
                        FillB2CS(package, data);
                        break;

                    case "HSN":
                        FillHSN(package, data);
                        break;

                    case "EXEMP":
                        // NOTE: 'EXEMP' actually returns Export-invoice (ExpInv) data
                        // from the stored procedure, so it's filled into the "exp" sheet.
                        FillExempt(package, data);
                        break;

                    case "CDNRC":
                        FillCDNR(package, data);
                        break;

                    case "DOCS":
                        FillDOCS(package, data);
                        break;
                }
            }

            return package.GetAsByteArray();
        }

        private void FillB2B(ExcelPackage package, List<GSTR1VM> data)
        {
            var ws = package.Workbook.Worksheets["b2b,sez,de"];

            if (ws == null)
                throw new Exception("Worksheet 'b2b,sez,de' not found.");

            int row = 5;

            foreach (var item in data)
            {
                ws.Cells[row, 1].Value = item.GSTNo;                                // A
                ws.Cells[row, 2].Value = item.CustName;                             // B
                ws.Cells[row, 3].Value = $"{item.Prefix}{item.InvNo}{item.Suffix}"; // C
                ws.Cells[row, 4].Value = item.InvDate;
                ws.Cells[row, 4].Style.Numberformat.Format = "dd-MM-yyyy";          // D

                ws.Cells[row, 5].Value = item.GrandTotal;                           // E
                ws.Cells[row, 6].Value = item.StateName;                            // F
                ws.Cells[row, 7].Value = "N";                                       // G
                ws.Cells[row, 8].Value = "";                                        // H
                ws.Cells[row, 9].Value = "Regular";                                 // I
                ws.Cells[row, 10].Value = "";                                       // J

                decimal rate = item.LineIGSTRate > 0
                    ? item.LineIGSTRate
                    : item.LineCGSTRate + item.LineSGSTRate;

                ws.Cells[row, 11].Value = rate;                                     // K
                ws.Cells[row, 12].Value = item.TotalTaxable;                        // L
                ws.Cells[row, 13].Value = 0;                                        // M

                row++;
            }

            // Summary
            ws.Cells["A2"].Value = data.Select(x => x.GSTNo).Distinct().Count();
            ws.Cells["C2"].Value = data.Count;
            ws.Cells["E2"].Value = data.Sum(x => x.GrandTotal);
            ws.Cells["L2"].Value = data.Sum(x => x.TotalTaxable);
            ws.Cells["M2"].Value = 0;
        }

        private void FillB2CL(ExcelPackage package, List<GSTR1VM> data)
        {
            var ws = package.Workbook.Worksheets["b2cl"];

            if (ws == null)
                throw new Exception("Worksheet 'b2cl' not found.");

            // Data starts from row 5
            int row = 5;

            foreach (var item in data)
            {
                // A - Invoice Number
                ws.Cells[row, 1].Value =
                    $"{item.Prefix}{item.InvNo}{item.Suffix}";

                // B - Invoice Date
                if (item.InvDate.HasValue)
                {
                    ws.Cells[row, 2].Value = item.InvDate.Value;
                    ws.Cells[row, 2].Style.Numberformat.Format = "dd-MM-yyyy";
                }

                // C - Invoice Value
                ws.Cells[row, 3].Value = item.GrandTotal;

                // D - Applicable % of Tax Rate
                ws.Cells[row, 4].Value =
                    string.IsNullOrWhiteSpace(item.ApplicableTaxRate)
                        ? ""
                        : item.ApplicableTaxRate;

                // E - Place of Supply
                ws.Cells[row, 5].Value = item.PlaceOfSupply;

                // F - Rate
                ws.Cells[row, 6].Value = item.TaxRate;

                // G - Taxable Value
                ws.Cells[row, 7].Value = item.TotalTaxable;

                // H - Cess Amount
                ws.Cells[row, 8].Value = item.CessAmount;

                // I - E-Commerce GSTIN
                ws.Cells[row, 9].Value = item.ECommerceGSTIN;

                row++;
            }

            // =====================================================
            // SUMMARY
            // =====================================================

            ws.Cells["C3"].Value = data.Sum(x => x.GrandTotal);
            ws.Cells["G3"].Value = data.Sum(x => x.TotalTaxable);
            ws.Cells["H3"].Value = data.Sum(x => x.CessAmount);

            ws.Cells["C3"].Style.Numberformat.Format = "0.00";
            ws.Cells["G3"].Style.Numberformat.Format = "0.00";
            ws.Cells["H3"].Style.Numberformat.Format = "0.00";

            if (row > 5)
            {
                ws.Cells[5, 3, row - 1, 3]
                    .Style.Numberformat.Format = "0.00";

                ws.Cells[5, 6, row - 1, 8]
                    .Style.Numberformat.Format = "0.00";
            }
        }

        private void FillB2CS(ExcelPackage package, List<GSTR1VM> data)
        {
            var ws = package.Workbook.Worksheets["b2cs"];

            if (ws == null)
                throw new Exception("Worksheet 'b2cs' not found.");

            int row = 5;

            foreach (var item in data)
            {
                ws.Cells[row, 1].Value = item.Type;               // A - Type
                ws.Cells[row, 2].Value = item.PlaceOfSupply;       // B - Place Of Supply
                ws.Cells[row, 3].Value = item.ApplicableTaxRate;   // C - Applicable % of Tax Rate
                ws.Cells[row, 4].Value = item.TaxRate;             // D - Rate
                ws.Cells[row, 5].Value = item.TotalTaxable;        // E - Taxable Value
                ws.Cells[row, 6].Value = item.CessAmount;          // F - Cess Amount
                ws.Cells[row, 7].Value = item.ECommerceGSTIN;      // G - E-Commerce GSTIN

                row++;
            }

            ws.Cells["E3"].Value = data.Sum(x => x.TotalTaxable);
            ws.Cells["F3"].Value = data.Sum(x => x.CessAmount);

            ws.Cells["E3"].Style.Numberformat.Format = "0.00";
            ws.Cells["F3"].Style.Numberformat.Format = "0.00";

            if (row > 5)
            {
                ws.Cells[5, 4, row - 1, 6]
                    .Style.Numberformat.Format = "0.00";
            }
        }

        private void FillHSN(ExcelPackage package, List<GSTR1VM> data)
        {
            var ws = package.Workbook.Worksheets["hsn"];

            if (ws == null)
                throw new Exception("Worksheet 'hsn' not found.");

            int row = 5;

            foreach (var item in data)
            {
                ws.Cells[row, 1].Value = item.HSNCode;      // A - HSN
                ws.Cells[row, 2].Value = item.ItemName;     // B - Description
                ws.Cells[row, 3].Value = item.MeasureUnit;  // C - UQC
                ws.Cells[row, 4].Value = item.Qty;          // D - Total Quantity
                ws.Cells[row, 5].Value = item.GrandTotal;   // E - Total Value

                // F - Rate
                ws.Cells[row, 6].Value =
                    item.LineCGSTRate +
                    item.LineSGSTRate +
                    item.LineIGSTRate;

                ws.Cells[row, 7].Value = item.TotalTaxable;     // G - Taxable Value
                ws.Cells[row, 8].Value = item.TotalIGSTAmount;  // H - Integrated Tax
                ws.Cells[row, 9].Value = item.TotalCGSTAmount;  // I - Central Tax
                ws.Cells[row, 10].Value = item.TotalSGSTAmount; // J - State/UT Tax
                ws.Cells[row, 11].Value = item.CessAmount;      // K - Cess

                row++;
            }

            // Summary
            ws.Cells["A3"].Value = data
                .Where(x => !string.IsNullOrWhiteSpace(x.HSNCode))
                .Select(x => x.HSNCode)
                .Distinct()
                .Count();

            ws.Cells["E3"].Value = data.Sum(x => x.GrandTotal);
            ws.Cells["G3"].Value = data.Sum(x => x.TotalTaxable);
            ws.Cells["H3"].Value = data.Sum(x => x.TotalIGSTAmount);
            ws.Cells["I3"].Value = data.Sum(x => x.TotalCGSTAmount);
            ws.Cells["J3"].Value = data.Sum(x => x.TotalSGSTAmount);
            ws.Cells["K3"].Value = data.Sum(x => x.CessAmount);

            if (row > 5)
            {
                ws.Cells[5, 4, row - 1, 11]
                    .Style.Numberformat.Format = "0.00";
            }

            ws.Cells["E3:K3"].Style.Numberformat.Format = "0.00";
        }

        // Renamed from FillEXP -> FillExempt to match the switch statement
        // ("EXEMP" case) and use fields that actually exist on GSTR1VM.
        // NOTE: the stored procedure's 'EXEMP' branch currently returns this
        // data from the ExpInv (Export Invoice) table with placeholder values
        // for ExportType / PortCode / ShippingBillNumber / ShippingBillDate.
        // Update the SP once you confirm the real ExpInv column names.
        private void FillExempt(ExcelPackage package, List<GSTR1VM> data)
        {
            var ws = package.Workbook.Worksheets["exp"];

            if (ws == null)
                throw new Exception("Worksheet 'exp' not found.");

            int row = 5;

            foreach (var item in data)
            {
                // A - Export Type
                ws.Cells[row, 1].Value = item.ExportType;

                // B - Invoice Number
                ws.Cells[row, 2].Value =
                    $"{item.Prefix}{item.InvNo}{item.Suffix}";

                // C - Invoice Date
                if (item.InvDate.HasValue)
                {
                    ws.Cells[row, 3].Value = item.InvDate.Value;
                    ws.Cells[row, 3].Style.Numberformat.Format = "dd-MM-yyyy";
                }

                // D - Invoice Value
                ws.Cells[row, 4].Value = item.GrandTotal;

                // E - Port Code
                ws.Cells[row, 5].Value = item.PortCode;

                // F - Shipping Bill Number
                ws.Cells[row, 6].Value = item.ShippingBillNumber;

                // G - Shipping Bill Date
                if (item.ShippingBillDate.HasValue)
                {
                    ws.Cells[row, 7].Value = item.ShippingBillDate.Value;
                    ws.Cells[row, 7].Style.Numberformat.Format = "dd-MM-yyyy";
                }

                // H - Rate
                decimal rate = item.TaxRate > 0
                    ? item.TaxRate
                    : item.LineIGSTRate;

                ws.Cells[row, 8].Value = rate;

                // I - Taxable Value
                ws.Cells[row, 9].Value = item.TotalTaxable;

                // J - Cess Amount
                ws.Cells[row, 10].Value = item.CessAmount;

                row++;
            }

            // =====================================================
            // SUMMARY
            // =====================================================

            ws.Cells["B3"].Value = data
                .Select(x => x.InvId)
                .Distinct()
                .Count();

            ws.Cells["D3"].Value = data
                .GroupBy(x => x.InvId)
                .Sum(g => g.First().GrandTotal);

            ws.Cells["F3"].Value = data
                .Where(x => !string.IsNullOrWhiteSpace(x.ShippingBillNumber))
                .Select(x => x.ShippingBillNumber)
                .Distinct()
                .Count();

            ws.Cells["I3"].Value = data.Sum(x => x.TotalTaxable);

            ws.Cells["D3"].Style.Numberformat.Format = "0.00";
            ws.Cells["I3"].Style.Numberformat.Format = "0.00";
            ws.Cells["J3"].Style.Numberformat.Format = "0.00";

            if (row > 5)
            {
                ws.Cells[5, 4, row - 1, 4]
                    .Style.Numberformat.Format = "0.00";

                ws.Cells[5, 8, row - 1, 8]
                    .Style.Numberformat.Format = "0.00";

                ws.Cells[5, 9, row - 1, 9]
                    .Style.Numberformat.Format = "0.00";

                ws.Cells[5, 10, row - 1, 10]
                    .Style.Numberformat.Format = "0.00";
            }
        }

        private void FillCDNR(ExcelPackage package, List<GSTR1VM> data)
        {
            var ws = package.Workbook.Worksheets["cdnr"];

            if (ws == null)
                throw new Exception("Worksheet 'cdnr' not found.");

            int row = 5;

            foreach (var item in data)
            {
                ws.Cells[row, 1].Value = item.GSTNo;         // A - GSTIN/UIN of Recipient
                ws.Cells[row, 2].Value = item.CustName;      // B - Receiver Name
                ws.Cells[row, 3].Value = item.NoteNumber;    // C - Note Number

                // D - Note Date
                if (item.NoteDate.HasValue)
                {
                    ws.Cells[row, 4].Value = item.NoteDate.Value;
                    ws.Cells[row, 4].Style.Numberformat.Format = "dd-MM-yyyy";
                }

                ws.Cells[row, 5].Value = item.NoteType;          // E - Note Type
                ws.Cells[row, 6].Value = item.PlaceOfSupply;     // F - Place Of Supply
                ws.Cells[row, 7].Value = item.ReverseCharge;     // G - Reverse Charge
                ws.Cells[row, 8].Value = item.NoteSupplyType;    // H - Note Supply Type
                ws.Cells[row, 9].Value = item.NoteValue;         // I - Note Value
                ws.Cells[row, 10].Value = 100;                   // J - Applicable % of Tax Rate
                ws.Cells[row, 11].Value = item.TaxRate;          // K - Rate
                ws.Cells[row, 12].Value = item.TotalTaxable;     // L - Taxable Value
                ws.Cells[row, 13].Value = item.CessAmount;       // M - Cess Amount

                row++;
            }

            // Summary
            ws.Cells["A3"].Value = data
                .Where(x => !string.IsNullOrWhiteSpace(x.GSTNo))
                .Select(x => x.GSTNo)
                .Distinct()
                .Count();

            ws.Cells["C3"].Value = data
                .Where(x => !string.IsNullOrWhiteSpace(x.NoteNumber))
                .Select(x => x.NoteNumber)
                .Distinct()
                .Count();

            ws.Cells["I3"].Value = data.Sum(x => x.NoteValue);
            ws.Cells["L3"].Value = data.Sum(x => x.TotalTaxable);
            ws.Cells["M3"].Value = data.Sum(x => x.CessAmount);

            ws.Cells["I3"].Style.Numberformat.Format = "0.00";
            ws.Cells["L3"].Style.Numberformat.Format = "0.00";
            ws.Cells["M3"].Style.Numberformat.Format = "0.00";

            if (row > 5)
            {
                ws.Cells[5, 9, row - 1, 13].Style.Numberformat.Format = "0.00";
            }
        }

        private void FillDOCS(ExcelPackage package, List<GSTR1VM> data)
        {
            var ws = package.Workbook.Worksheets["docs"];

            if (ws == null)
                throw new Exception("Worksheet 'docs' not found.");

            int row = 5;

            foreach (var item in data)
            {
                ws.Cells[row, 1].Value = item.NatureOfDocument;
                ws.Cells[row, 2].Value = item.SrNoFrom;
                ws.Cells[row, 3].Value = item.SrNoTo;
                ws.Cells[row, 4].Value = item.TotalNumber;
                ws.Cells[row, 5].Value = item.Cancelled;
               // ws.Cells[row, 6].Value = item.NetIssued;

                row++;
            }
        }
    }
}