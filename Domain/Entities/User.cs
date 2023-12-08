using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
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
        public string Email { get; set; }
        public string Phone { get; set; }

        public UserRole? Role { get; set; }

        public bool HasRole()
        {
            return Role.HasValue;
        }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}
