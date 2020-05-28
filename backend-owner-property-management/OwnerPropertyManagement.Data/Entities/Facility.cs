﻿namespace OwnerPropertyManagement.Data.Entities
{
    public class Facility
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TypeFacilityId { get; set; }
        public TypesFacility TypesFacility { get; set; }
    }
}
