using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetTaskCommentsQuery : IQuery
    {
        [Required]
        public int TaskId { get; set; }
    }
}
