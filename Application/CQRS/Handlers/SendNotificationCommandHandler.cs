using Application.CQRS.Commands;
using Domain.Entities;
using Domain.Repositories;
using System.Net.Mail;
using System.Net;

namespace Application.CQRS.Handlers
{
    public class SendNotificationCommandHandler : ICommandHandler<SendNotificationCommand>
    {
        const string SMTP_HOST = "myHost";
        const int SMTP_PORT = 587;
        const string SMTP_USER = "system@domainName.pl";
        const string SMTP_PASSWORD = "password";

        //string SMTP_HOST = "h2.hitme.pl";
        //int SMTP_PORT = 587;
        //string SMTP_USER = "system@test1234.hmcloud.pl";
        //string SMTP_PASSWORD = "c4Ev5nIZKXdtJK6CTKe";

        private readonly IDataRepository<User> _userRepository;

        public SendNotificationCommandHandler(IDataRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(SendNotificationCommand command)
        {
            var user = _userRepository.GetById(command.UserId);

            if (user == null)
                throw new ArgumentException("Argument cannot be empty", nameof(user));

            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient(SMTP_HOST);

            mail.From = new MailAddress(SMTP_USER);
            mail.To.Add(user.Email);
            mail.Subject = $"Zadanie przypisane.";
            mail.Body = command.Message;

            smtp.Port = SMTP_PORT;
            smtp.Credentials = new NetworkCredential(SMTP_USER, SMTP_PASSWORD);
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
    }
}
