using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.MasterViewModel.ChatBoxViewModel
{
	public  class ChatUserVM
	{
		public int UserId { get; set; }

		public string UserName { get; set; } = string.Empty;

		public bool IsOnline { get; set; }

		public int UnreadCount { get; set; }

		public string? LastMessage { get; set; }

		public DateTime? LastMessageDate { get; set; }
	}
}
