using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Application.DTOs
{
    public class ComplaintGrouping2
    {
        [Required]
        public string ComplaintIssue { get; set; } = string.Empty;
        [Required, Range(1,99999, ErrorMessage = "You must select branch")]
        public int BranchId { get; set; }
        [Required, Range(1,99999, ErrorMessage = "You must select town")]
        public int TownId { get; set; }
        [Required]
        public string? Other { get; set; }
    }
}
