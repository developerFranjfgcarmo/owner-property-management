using System.Collections.Generic;

namespace OwnerPropertyManagement.Domain.Dtos
{
    public class PagedCollection<TDto>
    {
        public List<TDto> Items { get; set; }
        public int Total { get; set; }
    }
}
