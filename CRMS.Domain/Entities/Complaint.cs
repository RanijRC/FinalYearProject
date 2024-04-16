using CRMS.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace CRMS.Domain.Entities
{
    public class Complaint : BaseEntity
    {
        [Required]
        public string? CustomerNumber { get; set; } = string.Empty;
        [Required]
        public string? ComplaintName { get; set; } = string.Empty;
        [Required]
        public string? ComplaintIssue { get; set; } = string.Empty;
        public string? ComplaintType { get; set; } = string.Empty;
        [Required, DataType(DataType.PhoneNumber)]
        public string? CustomerTelephoneNumber { get; set; } = string.Empty;
        [Required]
        public string? Photo { get; set; } = string.Empty;
        [Required]
        public string? FeedbackComments { get; set; } = string.Empty;
        public string? Other {  get; set; }

        //Many to one relationship with Branch
        public Branch? Branch { get; set; }
        public int BranchId { get; set; }

        public Town? Town { get; set; }
        public int TownId { get; set; } 
    }
}
