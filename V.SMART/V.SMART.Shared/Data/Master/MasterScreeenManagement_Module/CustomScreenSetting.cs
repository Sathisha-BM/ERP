using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using V.SMART.Shared.Data.Master.MasterScreeenManagement;

namespace V.SMART.Shared.Data.Master.MasterScreeenManagement_Module
{
    public  class CustomScreenSetting
    {
        [Key]
        public int CustomId { get; set; }

        [Required]
        public string Header { get; set; }

        [Required]
        public int CustomChildId { get; set; }

        [Required]
        public int ScreenId { get; set; }

        //[ForeignKey(nameof(ScreenId))]
        //public Screens? Screen { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string Icon { get; set; } = "bi-folder";

        public string? Color { get; set; }

        public string? Description { get; set; }

    }
}
