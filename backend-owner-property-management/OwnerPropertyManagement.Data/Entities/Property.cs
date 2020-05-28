using System.Collections.Generic;

namespace OwnerPropertyManagement.Data.Entities
{
    public class Property:Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Sleeps { get; set; }
        public short Bedrooms { get; set; }
        public short Bathrooms { get; set; }
        public bool PrivatePool { get; set; }
        public bool HeatedPool { get; set; }
        public bool Wifi { get; set; }
        public bool Garden { get; set; }
        public int LivingArea { get; set;}
        public short DistanceAirport { get; set; }
        public short DistanceBeach { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public string LocalLeisure { get; set; }
        public string LocalActivities { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<PropertyFacility> PropertyFacilities { get; set; }

    }
}
