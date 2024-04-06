using CRMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRMS.Domain.Entities
{
    public class Branch : BaseEntity
    {
        //Many to one relationship with Faculty
        public Faculty? Faculty { get; set; }
        public int FacultyId { get; set; }

        //Relationship: One to Many with Complaint
        [JsonIgnore]
        public List<Complaint>? Complaints { get; set; }
    }
}
