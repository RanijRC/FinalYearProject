

namespace CRMS.BaseLibrary.Entities
{
    public class Customer : BaseEntity
    {
        public string? CustomerId { get; set; }
        public string? ComplaintNumber { get; set; }
        public string? Fullname { get; set; }
        public string? Address { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? Photo { get; set; }
        public string? Other { get; set; }

        public Complaint? Complaints { get; set; }
        public int ComplaintId { get; set; }

        public Department? Departments { get; set; }
        public int DepartmentId { get; set;}
    }
}
