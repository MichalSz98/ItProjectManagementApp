using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Application.CQRS.Commands
{
    public class CreateTaskCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public TaskType Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ProjectId { get; set; }
    }
}
