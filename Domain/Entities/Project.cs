using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public virtual List<Task> Tasks { get; set; } = new List<Task>();

        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public virtual ProjectChangeLog ProjectChangeLog { get; private set; }

        public Project(string name, string description, DateTime? startDate, DateTime? endDate, int? teamId)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            TeamId = teamId;
        }
    }
}
