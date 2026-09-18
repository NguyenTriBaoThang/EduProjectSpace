using System.Net;
using System.Net.Mail;
using EduProject_TADProgrammer.Data;

namespace EduProject_TADProgrammer.Services;

// Call only after the academic transaction commits. SMTP failure must not report
// that an already-saved grade or approval failed to save.
public static class AcademicEmailService
{
    public static async Task TrySendAsync(ApplicationDbContext db, IConfiguration configuration, string? recipient, string subject, string content)
    {
        if (string.IsNullOrWhiteSpace(recipient)) return;
        try {
            var settings = await new NotificationService(db, configuration).GetConfigAsync();
            if (!settings.EnableEmail) return;
            var smtp = settings.SmtpConfig;
            if (smtp == null || string.IsNullOrWhiteSpace(smtp.Host) || string.IsNullOrWhiteSpace(smtp.Username)) {
                Console.Error.WriteLine("Academic email was not sent: SMTP is not configured."); return;
            }
            using var client = new SmtpClient(smtp.Host, smtp.Port) { EnableSsl = true, Credentials = new NetworkCredential(smtp.Username, smtp.Password), Timeout = 15000 };
            using var message = new MailMessage(smtp.Username, recipient, subject, content) { IsBodyHtml = false };
            await client.SendMailAsync(message);
        } catch (Exception e) when (e is SmtpException or FormatException or ArgumentException or InvalidOperationException) {
            Console.Error.WriteLine($"Academic data was saved; email delivery failed ({e.GetType().Name}).");
        }
    }
}
