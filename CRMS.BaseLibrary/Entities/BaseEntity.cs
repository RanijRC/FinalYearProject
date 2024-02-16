

namespace CRMS.BaseLibrary.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Customer>? Customers { get; set; }
    }
}
