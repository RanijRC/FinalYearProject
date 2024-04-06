using CRMS.Domain.Shared;
using System.Text.Json.Serialization;

namespace CRMS.Domain.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        //One to many relationship with Faculty
        [JsonIgnore]
        public List<Faculty>? Faculties { get; set; }
    }
}
