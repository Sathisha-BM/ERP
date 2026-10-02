using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.ReportViewModel.InspectionViewModel
{
    public class InspectionReportState
    {
        public List<InspectionVM> InspectionData { get; set; } = new();
        public List<InspectionVM> PartyNames { get; set; } = new();
        public List<InspectionVM> FilteredInspectionData { get; set; } = new();

        public string SelectedTopic { get; set; } = "";
        public string SelectedParty { get; set; } = "ALL";
        public string PartySearch { get; set; } = "";

        // IMPORTANT: nullable because your report uses DateTime?
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        // IMPORTANT: this was missing
        public bool HasData { get; set; } = false;
    }
}
