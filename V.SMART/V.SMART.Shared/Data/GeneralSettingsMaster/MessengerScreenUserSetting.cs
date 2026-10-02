
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using V.SMART.Shared.Data.Master.Admin;
using V.SMART.Shared.Data.Master.MasterScreeenManagement;

namespace V.SMART.Shared.Data.Master.MasterScreeenManagement_Module
{
	public class MessengerScreenUserSetting
	{
		public int Id { get; set; }

		[Required]
		public int? ScreenCode { get; set; }

		[ForeignKey(nameof(ScreenCode))]
		public virtual Screens? Screens { get; set; }

		// WHO IS ALLOWED TO SEND / TRIGGER
		[Required]
		public int? FromUserId { get; set; }

		[Required]
		public int? UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual User? User { get; set; }

		public bool IsActive { get; set; }

		public string? CreatedBy { get; set; }

		public DateTime? CreatedDate { get; set; }

		public string? ModifiedBy { get; set; }

		public DateTime? ModifiedDate { get; set; }
	}
}