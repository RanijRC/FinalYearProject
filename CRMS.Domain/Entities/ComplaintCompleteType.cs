using CRMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Domain.Entities
{
    public class ComplaintCompleteType : BaseEntity
    {
        public List<ComplaintComplete>? ComplaintCompletes {  get; set; }
    }
}
