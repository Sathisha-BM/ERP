using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Data.Master.ChatBox_Module
{
	public  class ChatMessageAttachment
	{
		[Key]
		public long Id { get; set; }

		[Required]
		public long MessageId { get; set; }

		[Required]
		[MaxLength(255)]
		public string FileName { get; set; }

		[MaxLength(500)]
		public string FilePath { get; set; }

		[MaxLength(100)]
		public string ContentType { get; set; }

		public long? FileSize { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.Now;

		[ForeignKey(nameof(MessageId))]
		public virtual ChatMessage ChatMessage { get; set; }

		public byte[]? Image { get; set; } = null;
	}
}
