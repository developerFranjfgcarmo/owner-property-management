using System.Collections.Generic;

namespace OwnerPropertyManagement.Data.Entities
{
    public class Zone
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
    }
}
