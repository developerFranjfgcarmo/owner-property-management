using System;

namespace OwnerPropertyManagement.Data.Entities
{
    public class Auditable
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string UserCreated { get; set; }
        public string UserUpdated { get; set; }
    }
}