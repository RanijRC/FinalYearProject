using CRMS.Domain.Shared;

namespace CRMS.Domain.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        //One to many relationship with Faculty
        public List<Faculty>? Faculties { get; set; }
    }
}
