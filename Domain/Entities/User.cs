using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public UserRole Role { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
