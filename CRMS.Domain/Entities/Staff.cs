using CRMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Domain.Entities
{
    public class Staff : BaseEntity
    {
        public int Id { get; set; }
        public DateTime JoinDate { get; set; }
        
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }

    
}
