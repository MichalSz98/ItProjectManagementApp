using Domain.Ports;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Infrastructure.Services
{
    // Adapter architektury heksagonalnej
    public class SmsNotificationService : INotificationService
    {
        private const string TWILIO_USER = "USER";
        private const string TWILIO_PASSWORD = "PASSWORD";
        private const string TWILIO_VIRTUAL_NUMBER = "+1234567898";

        public void SendAssignmentNotification(string email, string number, string taskTitle)
        {
            if (string.IsNullOrEmpty(number))
                throw new ArgumentException("Argument cannot be empty", nameof(number));
            if (string.IsNullOrEmpty(taskTitle))
                throw new ArgumentException("Argument cannot be empty", nameof(taskTitle));

            TwilioClient.Init(TWILIO_USER, TWILIO_PASSWORD);

            MessageResource.Create(
                body: $"Zadanie {taskTitle} przypisane. Zapoznaj się z jego treścią.",
                from: new Twilio.Types.PhoneNumber(TWILIO_VIRTUAL_NUMBER),
                to: new Twilio.Types.PhoneNumber(number)
            );
        }
    }
}
