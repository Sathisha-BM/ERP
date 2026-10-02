using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.Master.ChatBox_Module;

namespace V.SMART.Shared.ViewModels.MasterViewModel.ChatBoxViewModel
{
	public  class ChatMessageVM
	{


		public long Id { get; set; }

		public int ConversationId { get; set; }

		public int SenderId { get; set; }

		public int ReceiverId { get; set; }

		[Required(ErrorMessage = "Message is required.")]
		public string Message { get; set; } = string.Empty;

		public DateTime SentDate { get; set; }

		public bool IsRead { get; set; }

		public DateTime? ReadDate { get; set; }

		public bool IsMine { get; set; }

		public List<ChatMessageAttachment> Attachments { get; set; } = new();
	}
}
