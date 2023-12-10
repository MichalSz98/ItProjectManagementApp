using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class AddCommentCommand : ICommand
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        [MaxLength(250)]
        public string CommentText { get; set; }
    }
}
