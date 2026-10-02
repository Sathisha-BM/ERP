using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.CustomScreenViewModel
{
    public class CustomScreenSettingVM
    {
        public int CustomId { get; set; }

        public string Header { get; set; }

        public int CustomChildId { get; set; }

      
        public int ScreenId { get; set; }

        public string ScreenName { get; set; }

        public string Navigation { get; set; }


        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public List<CustomScreenSettingVM> Children { get; set; } = new();

        public string Icon { get; set; } = "bi-folder";

        public string? Color { get; set; }

    }
}
