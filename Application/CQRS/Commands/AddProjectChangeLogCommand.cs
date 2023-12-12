using System.ComponentModel.DataAnnotations;

namespace Application.CQRS.Commands
{
    public class AddProjectChangeLogCommand : ICommand
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(250)]
        public string ChangeDescription { get; set; }
    }
}
