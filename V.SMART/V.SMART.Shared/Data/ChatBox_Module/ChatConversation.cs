using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.SMART.Shared.Data.Master.ChatBox_Module
{
	public  class ChatConversation
	{

		[Key]
		public int Id { get; set; }

		public int User1Id { get; set; }

		public int User2Id { get; set; }

		public DateTime CreatedDate { get; set; } = DateTime.Now;

		public DateTime? LastMessageDate { get; set; }

		public ICollection<ChatMessage> Messages { get; set; }= new List<ChatMessage>();
	}
}
