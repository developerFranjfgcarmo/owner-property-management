namespace OwnerPropertyManagement.Contracts.Dtos.Filter
{
    public class PropertyFilter:PagedFilter
    {
        public int? OwnerId { get; set; }
    }
}
