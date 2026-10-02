using System.Collections.Generic;

namespace V.SMART.Shared.ViewModels.ReportViewModel.GSTITCVM
{
    public class B2BInvoiceJsonVM
    {
        public string inum { get; set; } = "";

        public string idt { get; set; } = "";

        public decimal val { get; set; }

        public string pos { get; set; } = "";

        public string rchrg { get; set; } = "N";

        public string inv_typ { get; set; } = "R";

        public List<B2BItemJsonVM> itms { get; set; } = new();
    }
}