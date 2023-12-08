using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team : Entity
    {
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }

        public virtual Project Project { get; set; }
    }
}
