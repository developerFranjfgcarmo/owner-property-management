using System.Collections.Generic;

namespace OwnerPropertyManagement.Contracts.Dtos
{
    public class PagedCollection<TDto>
    {
        public List<TDto> Items { get; set; }
        public long Total { get; set; }
    }
}
