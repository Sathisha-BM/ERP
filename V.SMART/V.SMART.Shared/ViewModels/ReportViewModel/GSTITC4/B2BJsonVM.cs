using System.Collections.Generic;

namespace V.SMART.Shared.ViewModels.ReportViewModel.GSTITCVM
{
    public class B2BJsonVM
    {
        public string ctin { get; set; } = "";

        //public string? cfs { get; set; } = "Y";

        public List<B2BInvoiceJsonVM> inv { get; set; } = new();
    }
}