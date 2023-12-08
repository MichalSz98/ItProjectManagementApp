using Domain.Ports;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Services
{
    // Adapter architektury heksagonalnej
    public class EmailNotificationService : INotificationService
    {
        string smtpHost = "h2.hitme.pl";
        int smtpPort = 587;
        string smtpUser = "system@test1234.hmcloud.pl";
        string smtpPassword = "c4Ev5nIZKXdtJK6CTKe";

        public void SendAssignmentNotification(string email, string taskTitle)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient(smtpHost);

            mail.From = new MailAddress(smtpUser);
            mail.To.Add(email);
            mail.Subject = $"Zadanie {taskTitle} przypisane.";
            mail.Body = $"Zadanie {taskTitle} przypisane. Zapoznaj się z jego treścią.";

            smtp.Port = smtpPort;
            smtp.Credentials = new NetworkCredential(smtpUser, smtpPassword);
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
    }
}
