using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.GSTITCVM
{
    public class B2BItemJsonVM
    {
        // Item Serial Number
        public int num { get; set; }

        // Item Details
        public B2BItemDetailJsonVM itm_det { get; set; } = new();
    }
}
