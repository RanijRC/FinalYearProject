
using CRMS.Domain.Entities;
using System.Text.Json.Serialization;

namespace CRMS.Domain.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //Relationship : One to Many
        [JsonIgnore]
        public List<Complaint> Complaints { get; set; }
    }
}
