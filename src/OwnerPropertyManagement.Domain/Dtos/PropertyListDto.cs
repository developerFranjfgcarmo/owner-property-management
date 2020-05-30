using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerPropertyManagement.Domain.Dtos
{
    public class PropertyListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Town { get; set; }
        public string Zone { get; set; }
        public int DistanceAirport { get; set; }
        public int DistanceBeach { get; set; }
        public bool Active { get; set; }
    }
}
