using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.HumanResourceViewModel.ProcessEmployeeAssignVM
{

    public class ProductionAttendancelogVM
    {
        // ===============================
        // MASTER FIELDS
        // ===============================
        public int Id { get; set; }

        public int Year { get; set; }
        [Required(ErrorMessage = "MonthName is Required...")]
        [Range(1, 12, ErrorMessage = "Please Select a MonthName")]

        public int? WeekNo { get; set; }

        public string? WeekName { get; set; }
        
        public int ProcessId { get; set; }

        public string ProcessName { get; set; } = string.Empty;

        public int MonthId { get; set; }
        public string MonthName
        {
            get
            {
                return MonthId > 0
                    ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MonthId)
                    : "N/A";
            }
        }

        public int StaffId { get; set; }
        public string StaffRefId { get; set; }

        // 🔥 FIXED StaffName (computed)
        public string? StaffName { get; set; } = null;

        public int Day { get; set; }
        public string? Ldetail { get; set; }
        public string? OtDetail { get; set; }

        //[Required(ErrorMessage ="InTime is Required...")]
        [Column(TypeName = "nvarchar(max)")]
        public string? InTime { get; set; }

        //[Required(ErrorMessage ="OutTime is Required...")]
        [Column(TypeName = "nvarchar(max)")]
        public string? OutTime { get; set; }
        public decimal OT { get; set; }

        public bool AttendanceCancel { get; set; } = false;

        //22/12/25
        public DateTime? InTimeDT
        {
            get => ParseTime(InTime);
            set => InTime = value?.ToString("HH:mm");
        }

        public DateTime? OutTimeDT
        {
            get => ParseTime(OutTime);
            set => OutTime = value?.ToString("HH:mm");
        }


        // 🔥 ADD THIS METHOD (THIS FIXES YOUR ERROR)
        private static DateTime? ParseTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time))
                return null;

            if (DateTime.TryParseExact(
                    time,
                    "HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var result))
            {
                return DateTime.Today.Add(result.TimeOfDay);
            }

            return null;
        }
        //22/12/25


        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string? BioMetricId { get; set; }
        public string? AttendanceSource { get; set; }
        public string? Reporting { get; set; }
        public string WorkingHrs { get; set; }

        public int TotalDays { get; set; } = 7;

        public List<AttendanceDayVM> Days { get; set; } = new();
    }
    public class AttendanceDayVM
    {
        public int AttendanceDate { get; set; }

        public string Status { get; set; } = "";

        public string InTime { get; set; } = "";

        public string OutTime { get; set; } = "";

        public string OT { get; set; } = "";
    }
}
