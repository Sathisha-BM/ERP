using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.ViewModels.MasterViewModel.ChatBoxViewModel
{
	public class ChatConversationVM
	{
		public int Id { get; set; }

		public int User1Id { get; set; }

		public int User2Id { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime? LastMessageDate { get; set; }
	}
}
