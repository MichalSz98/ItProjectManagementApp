using System.ComponentModel.DataAnnotations;

namespace Application.CQRS.Commands
{
    public class AssignTaskCommand : ICommand
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
