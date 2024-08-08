using Microsoft.Extensions.Options;
using New_System.Application.Core.Abstractions.Emails;
using New_System.Infrastructure.Emails.Settings;
using System.Net;
using System.Net.Mail;

namespace New_System.Infrastructure.Emails;

internal class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly SmtpClient _smtpClient;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
        _smtpClient = new SmtpClient(_emailSettings.SmtpServer)
        {
            Port = _emailSettings.SmtpPort,
            Credentials = new NetworkCredential(_emailSettings.SmtpUser, _emailSettings.SmtpPassword),
            EnableSsl = true
        };
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress("noreply@example.com"),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        mailMessage.To.Add(to);

        await _smtpClient.SendMailAsync(mailMessage);
    }
}
