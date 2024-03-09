using CRMS.Domain.Shared;

namespace CRMS.Domain.Entities
{
    public class Complaint : BaseEntity
    {
        public string? CustomerNumber { get; set; }
        public string? ComplaintName { get; set; }
        public string? ComplaintType { get; set; }
        public string? CustomerTelephoneNumber { get; set; }
        public string? Photo {  get; set; }
        public string? FeedbackComments { get; set; }
        public string? Other {  get; set; }

        //Relationship: Many to One
        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }

        public Faculty? Faculty { get; set; }
        public int FacultyId { get;set; }
    }
}
