using CRMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Domain.Entities
{
    public class Faculty: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
