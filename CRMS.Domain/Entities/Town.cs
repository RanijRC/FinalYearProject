using CRMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Domain.Entities
{
    public class Town : BaseEntity
    {
        //Relationship: One to Many with ComplaintCustomer
        public List<Complaint>? Complaints { get; set; }

        //Many to one relationship with City
        public City? City { get; set; }
        public int CityId { get; set; }
    }
}
