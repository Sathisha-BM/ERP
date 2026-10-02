using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Data.Master.ChatBox_Module
{
	public  class ChatMessage
	{
		[Key]
		public long Id { get; set; }

		public int ConversationId { get; set; }

		public int SenderId { get; set; }

		[Required]
		public string Message { get; set; } = string.Empty;

		public DateTime SentDate { get; set; } = DateTime.Now;

		public bool IsRead { get; set; } = false;

		public DateTime? ReadDate { get; set; }

		public ChatConversation? Conversation { get; set; }

		public ICollection<ChatMessageAttachment> Attachments { get; set; }= new List<ChatMessageAttachment>();

	}
}
