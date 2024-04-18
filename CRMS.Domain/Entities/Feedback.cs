using CRMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Domain.Entities
{
    public class Feedback : OtherBaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string ComplaintFeedback { get; set; } = string.Empty;
        [Required]
        public string FeedbackRecomendation { get; set; } = string.Empty;
    }
}
