using System;

namespace OwnerPropertyManagement.Domain.Dtos
{
    public class AuditableDto
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string UserCreated { get; set; }
        public string UserUpdated { get; set; }
    }
}