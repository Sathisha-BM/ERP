using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.HumanResourceViewModel.ProcessEmployeeAssignVM
{
    public class ProcessEmployeeAssignVM
    {
            public int AssignmentId { get; set; }


            [Required(ErrorMessage = "Week number is required.")]
            public int WeekNo { get; set; }

            public string? WeekName { get; set; } = null;


             [Required(ErrorMessage = "From date is required.")]
            public DateOnly fromDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);


            [Required(ErrorMessage = "To date is required.")]
            public DateOnly toDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(7));


            [Required(ErrorMessage = "Process is required.")]
            public int ProcessId { get; set; }
            
             public string? ProcessName { get; set; } = null;

            [Required(ErrorMessage = "Staff is required.")]
            public int StaffId { get; set; }
           

            [StringLength(50)]
            public string? CreatedBy { get; set; }

            [Required]
            public DateTime? CreatedDate { get; set; } = DateTime.Now;


            [StringLength(50)]
            public string? ModifiedBy { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public List<int> SelectedStaffIds { get; set; } = new();


    }
}
