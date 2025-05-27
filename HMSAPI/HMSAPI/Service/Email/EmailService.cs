namespace HMSAPI.Service.Email;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using HMSAPI.Model.EmailModel;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailWithAttachmentAsync(string toEmail, string subject, string body, byte[] attachment, string filename)
    {
        var message = new MailMessage();
        message.To.Add(toEmail);
        message.Subject = subject;
        message.Body = body;
        message.From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName);

        message.Attachments.Add(new Attachment(new MemoryStream(attachment), filename));

        using var smtp = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port)
        {
            Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
            EnableSsl = true
        };

        await smtp.SendMailAsync(message);
    }

    public async Task SendOtpEmailAsync(string toEmail, string otpCode)
    {
        try
        {
            var subject = "Your OTP Code";
            var body = $"Your verification code is: {otpCode}";

            using var message = new MailMessage
            {
                From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            message.To.Add(toEmail);

            using var smtp = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                EnableSsl = true
            };

            await smtp.SendMailAsync(message);
        }
        catch (Exception ex)
        {
            // Log error
            throw new ApplicationException("Failed to send OTP email", ex);
        }
    }
}



