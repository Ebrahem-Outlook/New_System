namespace New_System.Infrastructure.Emails.Settings;

internal sealed class EmailSettings
{
    public const string SettingsKey = "EmailSettings";

    public EmailSettings(string smtpServer, int smtpPort, string senderEmail, string senderName, string smtpUser, string smtpPassword)
    {
        SmtpServer = smtpServer;
        SmtpPort = smtpPort;
        SenderEmail = senderEmail;
        SenderName = senderName;
        SmtpUser = smtpUser;
        SmtpPassword = smtpPassword;
    }

    public string SmtpServer { get; set; } = default!;
    public int SmtpPort { get; set; } = default!;
    public string SenderEmail { get; set; } = default!;
    public string SenderName { get; set; } = default!;
    public string SmtpUser { get; set; } = default!;
    public string SmtpPassword { get; set; } = default!;
}
