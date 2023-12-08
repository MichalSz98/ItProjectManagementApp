using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    // Adapter architektury heksagonalnej
    public class EmailNotificationService : INotificationService
    {
        public void SendAssignmentNotification(string email, string taskTitle)
        {
            // Implementacja wysyłania e-maila
            Console.WriteLine($"Email sent to {email}: Task '{taskTitle}' assigned.");
        }
    }
}
