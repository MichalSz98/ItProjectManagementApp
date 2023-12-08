using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    // Port architektury heksagonalnej
    public interface INotificationService
    {
        void SendAssignmentNotification(string email, string number, string taskTitle);
    }
}
