using System.Collections.Generic;

namespace OwnerPropertyManagement.Data.Entities
{
    public class TypesFacility
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
    }
}
