using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerPropertyManagement.Data.Entities
{
    public class Town
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
