using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerPropertyManagement.Domain.Dtos.Filter
{
    public class PropertyFilter:PagedFilter
    {
        public int? OwnerId { get; set; }
    }
}
