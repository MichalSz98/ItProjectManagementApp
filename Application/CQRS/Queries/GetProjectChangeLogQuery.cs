using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetProjectChangeLogQuery : IQuery
    {
        public int ProjectId { get; set; }
    }
}
