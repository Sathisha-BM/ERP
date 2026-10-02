using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.Master.HumanResourceMaster_Module.V.SMART.Shared.Data.Master.HumanResourceMaster_Module;
using V.SMART.Shared.Data.Master.Inventory;

namespace V.SMART.Shared.Data.HumanResource.ProcessEmployeeAssign
{
    public class ProcessEmployeeAssign
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public int WeekNo { get; set; }

        [Required]
        public DateOnly fromDate { get; set; }= DateOnly.FromDateTime(DateTime.Now);

        [Required]
        public DateOnly toDate { get; set; }= DateOnly.FromDateTime(DateTime.Now.AddDays(7));

        [Required]
        public int ProcessId { get; set; }
        [ForeignKey(nameof(ProcessId))]
        public virtual Process Process { get; set; }

        [Required]
        public int StaffId { get; set; }
        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [Required]
        [StringLength(50)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;


        [StringLength(50)]
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
