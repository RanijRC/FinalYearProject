using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Domain.Shared
{
    public class OtherBaseEntity
    {
        public int Id { get; set; }
        public int ComplaintId { get; set; }
    }
}
