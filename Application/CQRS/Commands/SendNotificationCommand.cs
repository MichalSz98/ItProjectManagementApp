using System.ComponentModel.DataAnnotations;

namespace Application.CQRS.Commands
{
    public class SendNotificationCommand : ICommand
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }
    }
}
