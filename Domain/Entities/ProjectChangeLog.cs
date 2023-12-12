using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProjectChangeLog : Entity
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public string ChangeDescription { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
