using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Application.DTOs
{
    public class StaffRequestDTO
    {
        public DateTime JoinDate { get; set; }
        public string? Faculty { get; set; }
        public int FacultyId { get; set; }
    }
}
