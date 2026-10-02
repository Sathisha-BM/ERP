using AutoMapper;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService.IMasterServices.IChatBox;
using V.SMART.Shared.Data.Master.ChatBox_Module;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.MasterViewModel.ChatBoxViewModel;

namespace V.SMART.Shared.BusinessLayer.BusinessService.MasterService.ChatBox
{
    public class MessengerService : IMessengerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonService _commonService;
        private readonly CurrentUserService _currentUserService;
        private readonly ILoggingService _logs;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public MessengerService(
            IUnitOfWork unitOfWork,
            ICommonService commonService,
            CurrentUserService userService,
            ILoggingService logs,
            IMapper mapper,
             IConfiguration configuration
             )
        {
            _unitOfWork = unitOfWork;
            _commonService = commonService;
            _currentUserService = userService;
            _logs = logs;
            _mapper = mapper;
            _configuration = configuration;

        }


        public async Task<int> GetScreenCodeByScreenNameAsync(string screenName)
               => await _commonService.GetScreenCodeByScreenNameAsync(screenName);


        public async Task<List<ChatUserVM>> GetUsersAsync(int currentUserId)
        {
            try
            {
                var users = await _unitOfWork.Users.GetAllAsync();

                return users
                    .Where(x => x.UserId != currentUserId)
                    .Select(x => new ChatUserVM
                    {
                        UserId = x.UserId,
                        UserName = x.UserName
                    })
                    .ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<ChatMessageVM>> GetMessagesAsync(int currentUserId, int otherUserId)
        {
            try
            {
                var conversations = await _unitOfWork.ChatConversations.GetAllAsync();

                var conversation = conversations.FirstOrDefault(x =>
                    (x.User1Id == currentUserId &&
                     x.User2Id == otherUserId) ||
                    (x.User1Id == otherUserId &&
                     x.User2Id == currentUserId));

                if (conversation == null)
                    return new List<ChatMessageVM>();

                var messages =
                    await _unitOfWork.ChatMessages.GetAllAsync();

                var conversationMessages = messages
                    .Where(x => x.ConversationId == conversation.Id)
                    .OrderBy(x => x.SentDate)
                    .ToList();

                var attachments =
                    await _unitOfWork.ChatMessageAttachments.GetAllAsync();

                return conversationMessages
                    .Select(x => new ChatMessageVM
                    {
                        Id = x.Id,
                        ConversationId = x.ConversationId,
                        SenderId = x.SenderId,

                        ReceiverId = x.SenderId == currentUserId
                            ? otherUserId
                            : currentUserId,

                        Message = x.Message,
                        SentDate = x.SentDate,
                        IsRead = x.IsRead,
                        ReadDate = x.ReadDate,
                        IsMine = x.SenderId == currentUserId,

                        Attachments = attachments
                            .Where(a => a.MessageId == x.Id)
                            .OrderBy(a => a.Id)
                            .ToList()
                    })
                    .ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ChatMessageVM> SendMessageAsync(ChatMessageVM vm)
        {
            try
            {
                var conversations = await _unitOfWork.ChatConversations.GetAllAsync();

                var conversation = conversations.FirstOrDefault(x =>
                    (x.User1Id == vm.SenderId &&
                     x.User2Id == vm.ReceiverId) ||
                    (x.User1Id == vm.ReceiverId &&
                     x.User2Id == vm.SenderId));

                if (conversation == null)
                {
                    conversation = new ChatConversation
                    {
                        User1Id = vm.SenderId,
                        User2Id = vm.ReceiverId,
                        CreatedDate = DateTime.Now,
                        LastMessageDate = DateTime.Now
                    };

                    await _unitOfWork.ChatConversations
                        .CreateAsync(conversation);

                    await _unitOfWork.SaveAsync();
                }

                var entity = new ChatMessage
                {
                    ConversationId = conversation.Id,
                    SenderId = vm.SenderId,
                    Message = vm.Message?.Trim() ?? string.Empty,
                    SentDate = DateTime.Now,
                    IsRead = false
                };

                await _unitOfWork.ChatMessages
                    .CreateAsync(entity);

                conversation.LastMessageDate = entity.SentDate;

                await _unitOfWork.SaveAsync();

                vm.Id = entity.Id;
                vm.ConversationId = entity.ConversationId;
                vm.Message = entity.Message;
                vm.SentDate = entity.SentDate;
                vm.IsRead = entity.IsRead;
                vm.ReadDate = entity.ReadDate;
                vm.IsMine = true;

                return vm;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> GetUnreadCountAsync(int currentUserId, int otherUserId)
        {
            try
            {
                var conversations = await _unitOfWork.ChatConversations.GetAllAsync();

                var conversation = conversations.FirstOrDefault(x =>
                    (x.User1Id == currentUserId &&
                     x.User2Id == otherUserId) ||
                    (x.User1Id == otherUserId &&
                     x.User2Id == currentUserId));

                if (conversation == null)
                    return 0;

                var messages =
                    await _unitOfWork.ChatMessages.GetAllAsync();

                return messages.Count(x =>
                    x.ConversationId == conversation.Id &&
                    x.SenderId == otherUserId &&
                    !x.IsRead);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task MarkMessagesAsReadAsync(int currentUserId, int otherUserId)
        {
            try
            {
                var conversations = await _unitOfWork.ChatConversations.GetAllAsync();

                var conversation = conversations.FirstOrDefault(x =>
                    (x.User1Id == currentUserId &&
                     x.User2Id == otherUserId) ||
                    (x.User1Id == otherUserId &&
                     x.User2Id == currentUserId));

                if (conversation == null)
                    return;

                var messages =
                    await _unitOfWork.ChatMessages.GetAllAsync();

                var unreadMessages = messages
                    .Where(x =>
                        x.ConversationId == conversation.Id &&
                        x.SenderId == otherUserId &&
                        !x.IsRead)
                    .ToList();

                foreach (var message in unreadMessages)
                {
                    message.IsRead = true;
                    message.ReadDate = DateTime.Now;
                }

                if (unreadMessages.Count > 0)
                    await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> GetTodayMeaasagesCountAsync(int userid)
        {
            try
            {
                return await _unitOfWork.ChatMessages
                   .GetQueryable()
                   .CountAsync(x =>
                       !x.IsRead &&
                       x.Conversation != null &&
                       (x.Conversation.User1Id == userid ||
                        x.Conversation.User2Id == userid) &&
                       x.SenderId != userid);
            }
            catch (Exception ex)
            {

                throw;
            }

        }




        public async Task<List<ChatMessageAttachment>> GetAttachmentsAsync(long messageId)
        {
            try
            {
                var attachments = await _unitOfWork.ChatMessageAttachments.GetAllAsync();

                return attachments
                    .Where(x => x.MessageId == messageId)
                    .OrderBy(x => x.Id)
                    .ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAttachmentAsync(long attachmentId)
        {
            try
            {
                var attachments = await _unitOfWork.ChatMessageAttachments.GetAllAsync();

                var attachment = attachments
                    .FirstOrDefault(x => x.Id == attachmentId);

                if (attachment == null)
                    return false;

                await _unitOfWork.ChatMessageAttachments.DeleteAsync(attachment);

                await _unitOfWork.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public async Task<ChatMessageAttachment> UploadAttachmentAsync(long messageId, IBrowserFile file)
        {
            try
            {
                const long maxFileSize = 10 * 1024 * 1024;

                var allowedExtensions = new[]
                {".jpg",".jpeg",".png",".pdf",".xlsx",".xls",".doc",".docx"};

                var extension = Path.GetExtension(file.Name).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException(
                        $"File '{file.Name}' is not supported.");
                }

                if (file.Size > maxFileSize)
                {
                    throw new InvalidOperationException(
                        $"File '{file.Name}' is larger than 10 MB.");
                }

                byte[] fileBytes;

                await using var stream = file.OpenReadStream(maxFileSize);
                using var memoryStream = new MemoryStream();

                await stream.CopyToAsync(memoryStream);

                fileBytes = memoryStream.ToArray();

                var attachment = new ChatMessageAttachment
                {
                    MessageId = messageId,
                    FileName = file.Name,
                    ContentType = file.ContentType,
                    FilePath = $"/uploads/chat/files",
                    FileSize = file.Size,
                    Image = fileBytes,
                    CreatedDate = DateTime.Now
                };

                await _unitOfWork.ChatMessageAttachments.CreateAsync(attachment);
                await _unitOfWork.SaveAsync();

                return attachment;
            }
            catch (Exception ex)
            {
                await _logs.LogDeveloperError(ex);
                return new ChatMessageAttachment();
            }
        }

        public async Task<ChatMessageVM> SendMessageAsync(ChatMessageVM vm, List<IBrowserFile> files)
        {

            try
            {
                var conversations =await _unitOfWork.ChatConversations.GetAllAsync();

                var conversation = conversations.FirstOrDefault(x =>
                    (x.User1Id == vm.SenderId &&
                     x.User2Id == vm.ReceiverId) ||
                    (x.User1Id == vm.ReceiverId &&
                     x.User2Id == vm.SenderId));

                if (conversation == null)
                {
                    conversation = new ChatConversation
                    {
                        User1Id = vm.SenderId,
                        User2Id = vm.ReceiverId,
                        CreatedDate = DateTime.Now,
                        LastMessageDate = DateTime.Now
                    };

                    await _unitOfWork.ChatConversations
                        .CreateAsync(conversation);

                    await _unitOfWork.SaveAsync();
                }

                var entity = new ChatMessage
                {
                    ConversationId = conversation.Id,
                    SenderId = vm.SenderId,
                    Message = vm.Message?.Trim() ?? string.Empty,
                    SentDate = DateTime.Now,
                    IsRead = false
                };

                await _unitOfWork.ChatMessages
                    .CreateAsync(entity);

                conversation.LastMessageDate = entity.SentDate;

                await _unitOfWork.SaveAsync();

                if (files != null && files.Any())
                {
                    foreach (var file in files)
                    {
                        await UploadAttachmentAsync(entity.Id, file);
                    }
                }

                vm.Id = entity.Id;
                vm.ConversationId = entity.ConversationId;
                vm.Message = entity.Message;
                vm.SentDate = entity.SentDate;
                vm.IsRead = entity.IsRead;
                vm.ReadDate = entity.ReadDate;
                vm.IsMine = true;

                return vm;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        // For Sending notfications
        public async Task SendScreenNotificationAsync(string ScreenName, int currentUserId, string messageText)
        {
            try
            {
                int screenCode = await GetScreenCodeByScreenNameAsync(ScreenName);

                if (screenCode <= 0)
                    return;

                if (currentUserId <= 0)
                    return;

                if (string.IsNullOrWhiteSpace(messageText))
                    return;

                var fromId = await GetAssignedfromIdsAsync(screenCode, currentUserId);


                if (fromId == null || fromId == 0)
                    return;


                // Get users assigned to this screen
                var userIds = await GetAssignedUserIdsAsync(screenCode, fromId);



                if (userIds == null || !userIds.Any())
                    return;






                // Send message to all assigned users
                foreach (var userId in userIds)
                {
                    if (userId == currentUserId)
                        continue;

                    var vm = new ChatMessageVM
                    {
                        SenderId = currentUserId,
                        ReceiverId = userId,
                        Message = messageText,
                        SentDate = DateTime.Now,
                        IsRead = false,
                        IsMine = true
                    };

                    await SendMessageAsync(vm, new List<IBrowserFile>());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Messenger notification failed: {ex.Message}");
            }
        }
        //AssenginedUsers
        public async Task<List<int>> GetAssignedUserIdsAsync(int screenCode, int fromId)
        {

            try
            {
                return (await _unitOfWork.MessengerScreenUserSettings.GetAllAsync())
                   .Where(x => x.ScreenCode == screenCode && x.FromUserId == fromId && x.IsActive && x.UserId.HasValue)
                   .Select(x => x.UserId.Value)
                   .ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //FromUserid given or not 
        public async Task<int> GetAssignedfromIdsAsync(int screenCode, int currentUserId)
        {
            try
            {
                return (await _unitOfWork.MessengerScreenUserSettings.GetAllAsync())
                    .Where(x => x.ScreenCode == screenCode && x.FromUserId == currentUserId && x.UserId.HasValue)
                    .Select(x => x.FromUserId.Value).Distinct().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
