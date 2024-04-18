using CRMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Domain.Entities
{
    public class DataPending : OtherBaseEntity
    {
        [Required]
        public DateTime ComplaintDateStart { get; set; }
        [Required]
        public DateTime ComplaintDateEnd { get; set; }
        public int NumberofDays => (ComplaintDateEnd - ComplaintDateStart).Days;

        public DataPendingType? DataPendingType { get; set; }
        [Required]
        public int DataPendingTypeId { get; set; }
    }
}
