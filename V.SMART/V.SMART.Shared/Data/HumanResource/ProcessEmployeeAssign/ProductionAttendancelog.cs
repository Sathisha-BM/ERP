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
	public class ProductionAttendancelog
	{
		[Key]
		public int Id { get; set; }


		[Required]
		public int? WeekNo { get; set; }


		[Required]
		public int ProcessId { get; set; }


		[ForeignKey(nameof(ProcessId))]
		public virtual Process Process { get; set; }

		[Required]
		public int StaffId { get; set; }

		[ForeignKey(nameof(StaffId))]

		public Staff Staff { get; set; }

		
		[Column(TypeName = "nvarchar(max)")]
		public string? Ldetail { get; set; }

		[Column(TypeName = "nvarchar(max)")]
		public string? OtDetail { get; set; }

		public string? CreatedBy { get; set; }

		//public DateTime? CreatedDate { get; set; }
		public DateTime? CreatedDate { get; set; } = DateTime.Now;

		public string? ModifiedBy { get; set; }

		public DateTime? ModifiedDate { get; set; }

		[Column(TypeName = "nvarchar(max)")]
		public string? InTime { get; set; }

		[Column(TypeName = "nvarchar(max)")]
		public string? OutTime { get; set; }


	}
}
