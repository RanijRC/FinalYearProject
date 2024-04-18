using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Application.DTOs
{
    public class ComplaintGrouping1
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required] 
        public string ComplaintType { get; set; } = string.Empty;
        [Required]
        public string CustomerTelephoneNumber { get; set; } = string.Empty;
        [Required]
        public string CustomerNumber {  get; set; } = string.Empty;
        [Required]
        public string FeedbackComments {  get; set; } = string.Empty;
        [Required]
        public string Photo { get; set; } = string.Empty;
    }
}
