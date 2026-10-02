
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using V.SMART.Shared.BusinessLayer.BusinessService.IBusinessService;
using V.SMART.Shared.Repository.IRepository;
using V.SMART.Shared.Services;
using V.SMART.Shared.ViewModels.EmailserviceVM;
using V.SMART.Shared.ViewModels.Mail;

public class EmailService
{
    private readonly EmailSettings _settings;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommonService _commonService;
    private readonly CurrentUserService _currentUserService;
    private readonly ILoggingService _logs;

    public EmailService(IOptions<EmailSettings> options, IUnitOfWork unitOfWork,
            ICommonService commonService,
            CurrentUserService userService,
            ILoggingService logs)
    {
        _settings = options.Value;
        _unitOfWork = unitOfWork;
        _commonService = commonService;
        _currentUserService = userService;
        _logs = logs;
    }

    public async Task<EmailSettings?> GetCurrentUserEmailSettingsAsync()
    {
        var userId = await _currentUserService.GetUserIdAsync();

        var settings = await _unitOfWork.Users
            .GetQueryable()
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();

        if (settings == null)
            return null;

        return new EmailSettings
        {
            SmtpServer = settings.EmailServerName,
            Port = int.TryParse(settings.EmailPortNo, out var port) ? port : 587,
            UserName = settings.EmailId,
            Password = settings.EmailAppPassword,
            SenderEmail = settings.EmailId,
            SenderName = settings.UserName,
            IsDefaultMail= settings.IsDefaultMail,
        };
    }



public async Task<EmailSendResult> SendEmailAsync(
    string toEmail,
    string? ccEmail,
    string? bccEmail,
    string subject,
    string htmlBody,
    List<EmailAttachment>? attachments)
    {
        try
        {
            // ==========================================
            // GET CURRENT USER EMAIL SETTINGS
            // ==========================================

            var settings =
                await GetCurrentUserEmailSettingsAsync();

            if (settings == null)
                throw new Exception(
                    "Email settings are not configured for the current user.");

            if (string.IsNullOrWhiteSpace(settings.SenderEmail))
                throw new Exception(
                    "Sender email is not configured.");

            if (string.IsNullOrWhiteSpace(settings.SmtpServer))
                throw new Exception(
                    "SMTP server is not configured.");

            if (settings.Port <= 0)
                throw new Exception(
                    "SMTP port is not configured.");

            if (string.IsNullOrWhiteSpace(settings.UserName))
                throw new Exception(
                    "SMTP username is not configured.");

            if (string.IsNullOrWhiteSpace(settings.Password))
                throw new Exception(
                    "SMTP password is not configured.");


            // ==========================================
            // CREATE EMAIL
            // ==========================================

            var email = new MimeMessage();


            // ==========================================
            // FROM
            // ==========================================

            email.From.Add(
                new MailboxAddress(
                    settings.SenderName ?? "",
                    settings.SenderEmail));


            // ==========================================
            // TO
            // ==========================================

            AddRecipients(
                email.To,
                toEmail);


            // ==========================================
            // CC
            // ==========================================

            AddRecipients(
                email.Cc,
                ccEmail);


            // ==========================================
            // BCC
            // ==========================================

            AddRecipients(
                email.Bcc,
                bccEmail);


            // ==========================================
            // CHECK RECIPIENTS
            // ==========================================

            if (!email.To.Any() &&
                !email.Cc.Any() &&
                !email.Bcc.Any())
            {
                throw new Exception(
                    "At least one recipient email is required.");
            }


            // ==========================================
            // SUBJECT
            // ==========================================

            email.Subject =
                subject ?? string.Empty;


            // ==========================================
            // BODY
            // ==========================================

            var builder = new BodyBuilder
            {
                HtmlBody = htmlBody ?? string.Empty
            };


            // ==========================================
            // MULTIPLE ATTACHMENTS
            // ==========================================

            if (attachments != null &&
                attachments.Count > 0)
            {
                foreach (var attachment in attachments)
                {
                    // --------------------------------------
                    // VALIDATE FILE NAME
                    // --------------------------------------

                    if (string.IsNullOrWhiteSpace(
                        attachment.FileName))
                    {
                        continue;
                    }


                    // --------------------------------------
                    // VALIDATE FILE CONTENT
                    // --------------------------------------

                    if (attachment.FileBytes == null ||
                        attachment.FileBytes.Length == 0)
                    {
                        continue;
                    }


                    // --------------------------------------
                    // CONTENT TYPE
                    // --------------------------------------

                    var contentType =
                        string.IsNullOrWhiteSpace(
                            attachment.ContentType)
                        ? "application/octet-stream"
                        : attachment.ContentType;


                    // --------------------------------------
                    // ADD ATTACHMENT
                    // --------------------------------------

                    builder.Attachments.Add(
                        attachment.FileName,
                        attachment.FileBytes,
                        ContentType.Parse(contentType));
                }
            }


            // ==========================================
            // SET EMAIL BODY
            // ==========================================

            email.Body =
                builder.ToMessageBody();


            // ==========================================
            // SMTP
            // ==========================================

            using var smtp = new SmtpClient();


            await smtp.ConnectAsync(
                settings.SmtpServer,
                settings.Port,
                SecureSocketOptions.StartTls);


            // ==========================================
            // AUTHENTICATE
            // ==========================================

            await smtp.AuthenticateAsync(
                settings.UserName,
                settings.Password);


            // ==========================================
            // SEND EMAIL
            // ==========================================

            await smtp.SendAsync(email);


            // ==========================================
            // DISCONNECT
            // ==========================================

            await smtp.DisconnectAsync(true);


            // ==========================================
            // SUCCESS
            // ==========================================

            return new EmailSendResult
            {
                Success = true,
                Message = attachments != null &&
                          attachments.Count > 0
                    ? $"Email sent successfully with {attachments.Count} attachment(s)."
                    : "Email sent successfully."
            };
        }
        catch (MailKit.Net.Smtp.SmtpCommandException ex)
        {
            return new EmailSendResult
            {
                Success = false,
                Message =
                    $"SMTP error: {ex.Message} | Status: {ex.StatusCode}",
                Exception = ex
            };
        }
        catch (SmtpProtocolException ex)
        {
            return new EmailSendResult
            {
                Success = false,
                Message =
                    $"SMTP protocol error: {ex.Message}",
                Exception = ex
            };
        }
        catch (Exception ex)
        {
            return new EmailSendResult
            {
                Success = false,
                Message = ex.Message,
                Exception = ex
            };
        }
    }

private void AddRecipients(
    InternetAddressList addressList,
    string? emails)
    {
        if (string.IsNullOrWhiteSpace(emails))
            return;


        var recipients = emails.Split(
            new[] { ',', ';' },
            StringSplitOptions.RemoveEmptyEntries);


        foreach (var recipient in recipients)
        {
            var address = recipient.Trim();


            if (string.IsNullOrWhiteSpace(address))
                continue;


            try
            {
                addressList.Add(
                    MailboxAddress.Parse(address));
            }
            catch (FormatException)
            {
                throw new Exception(
                    $"Invalid email address: {address}");
            }
        }
    }

}