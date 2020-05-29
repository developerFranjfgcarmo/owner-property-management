using System.Collections.Generic;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Test.Mocks
{
    public class PropertyMock
    {
        private static PropertyMock _doctorMock;

        private PropertyMock()
        {
        }

        public static PropertyMock Instance()
        {
            return _doctorMock ??= new PropertyMock();
        }

        public void AddProperties(DatabaseFixture fixture)
        {
            var context = fixture.GetDbContext();

            var owners = new List<Owner>
            {
                new Owner { Id = 1, FirstName = "Francisco", Surname = "Fernández"},
                new Owner { Id = 2, FirstName = "Juan Alberto", Surname = "Ramos"}
            };
            var properties = new List<Property>
            {
                new Property { Id = 1, Name = "Villa Bonita",TownId =1, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 1},
                new Property { Id = 2, Name = "Villa Bonita 1",TownId =2, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 2},
                new Property { Id = 3, Name = "Villa Bonita 2",TownId =3, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 1},
                new Property { Id = 4, Name = "Villa Bonita 3",TownId =4, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 1},
                new Property { Id = 5, Name = "Villa Bonita 4",TownId =5, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 2},
                new Property { Id = 6, Name = "Villa Bonita 5",TownId =6, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 1},
                new Property { Id = 7, Name = "Villa Bonita 6",TownId =7, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 1},
                new Property { Id = 8, Name = "Villa Bonita 7",TownId =1, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 2},
                new Property { Id = 9, Name = "Villa Bonita 8",TownId =2, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 1},
                new Property { Id = 10, Name = "Villa Bonita 9",TownId =3, DistanceAirport=15,DistanceBeach=18,Active= true, OwnerId = 2},
            };
            context.Owners.AddRange(owners);
            context.Properties.AddRange(properties);
            context.SaveChanges();

        }
    }
}
