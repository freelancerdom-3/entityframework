namespace HMSAPI.Service.Email;
public interface IEmailService
{
    Task SendEmailWithAttachmentAsync(string toEmail, string subject, string body, byte[] attachment, string attachmentName);

    Task SendOtpEmailAsync(string toEmail, string otpCode);
}
