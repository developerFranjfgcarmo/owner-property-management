namespace OwnerPropertyManagement.Data.Entities
{
    public class PropertyFacility
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual Property Property { get; set; }
    }
}
