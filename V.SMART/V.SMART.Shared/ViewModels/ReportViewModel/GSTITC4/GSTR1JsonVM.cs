using System.Collections.Generic;

namespace V.SMART.Shared.ViewModels.ReportViewModel.GSTITCVM
{
    public class GSTR1JsonVM
    {
        public string gstin { get; set; } = "";

        public string fp { get; set; } = "";

        public string version { get; set; } = "";

        public string hash { get; set; } = "";

        public List<B2BJsonVM> b2b { get; set; } = new();

        // We will add these later
        public object? b2cl { get; set; }

        public object? b2cs { get; set; }

        public object? hsn { get; set; }

        public object? cdnr { get; set; }
    }
}