using CRMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Domain.Entities
{
    public class ComplaintComplete : OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime EndDate => StartDate.AddDays(NumberOfDays);

        public ComplaintCompleteType? ComplaintCompleteType { get; set;}
        [Required]
        public int ComplaintCompleteTypeId { get; set; }
    }
}
