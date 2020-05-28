using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerPropertyManagement.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Nick { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string ContactPhoneProperty { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AboutMe { get; set; }
    }
}
