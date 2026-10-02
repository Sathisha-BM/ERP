using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.Data.Master.ChatBox_Module;
using V.SMART.Shared.ViewModels.MasterViewModel.ChatBoxViewModel;
using Microsoft.AspNetCore.Components.Forms;


namespace V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IMasterServices.IChatBox
{
	public  interface IMessengerService
	{
		Task<List<ChatUserVM>> GetUsersAsync(int currentUserId);

		Task<List<ChatMessageVM>> GetMessagesAsync(int currentUserId, int otherUserId);

		//Task<ChatMessageVM> SendMessageAsync(ChatMessageVM vm);


		Task<ChatMessageVM> SendMessageAsync(ChatMessageVM vm,List<IBrowserFile> files);

		Task<int> GetUnreadCountAsync(int currentUserId, int otherUserId);

		Task MarkMessagesAsReadAsync(int currentUserId, int otherUserId);

		Task<int> GetTodayMeaasagesCountAsync(int userid);


		//For Attehments
		Task<ChatMessageAttachment> UploadAttachmentAsync(long messageId,IBrowserFile file);

		Task<List<ChatMessageAttachment>> GetAttachmentsAsync(long messageId);

		Task<bool> DeleteAttachmentAsync(long attachmentId);


		//For All screeNotifications
		Task SendScreenNotificationAsync(string ScreenName, int currentUserId,string messageText);

		Task<List<int>> GetAssignedUserIdsAsync(int screenCode,int currentUserId);

		Task<int> GetAssignedfromIdsAsync(int screenCode, int currentUserId);

       


	}
}
