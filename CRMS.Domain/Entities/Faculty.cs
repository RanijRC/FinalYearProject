using CRMS.Domain.Shared;

namespace CRMS.Domain.Entities
{
    public class Faculty : BaseEntity
    {
        //Many to one relationship with General Department
        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }

        //One to many relationship with Branch
        public List<Branch>? Branches { get; set; }
    }
}
