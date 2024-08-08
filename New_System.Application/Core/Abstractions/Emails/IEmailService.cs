namespace New_System.Application.Core.Abstractions.Emails;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}
