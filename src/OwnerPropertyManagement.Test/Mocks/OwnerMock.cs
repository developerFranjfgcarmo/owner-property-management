using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Test.Mocks
{
    public class OwnerMock
    {
        private static OwnerMock _ownerMock;

        private OwnerMock()
        {
        }

        public static OwnerMock Instance()
        {
            return _ownerMock ??= new OwnerMock();
        }

        public void AddOwners(DatabaseFixture fixture)
        {
            var context = fixture.GetDbContext();

            var owners = new List<Owner>
            {
                new Owner { Id = 1, FirstName = "Francisco", Surname = "Fernández", Nick="Fran", PersonalPhoneNumber = "654987654", City = "Carmona", Country = "Spain"},
                new Owner { Id = 2, FirstName = "Pepe", Surname = "Rodriguez", Nick="", PersonalPhoneNumber = "456123789", City = "Ronda", Country = "Spain"},
                new Owner { Id = 3, FirstName = "Francisco", Surname = "Rando", Nick="Francis", PersonalPhoneNumber = "123456789", City = "Coin", Country = "Spain"},
                new Owner { Id = 4, FirstName = "Jose", Surname = "Fernández", Nick="Fran", PersonalPhoneNumber = "789456123", City = "Carmona", Country = "Spain"},
                new Owner { Id = 5, FirstName = "Ignacio", Surname = "Sánchez", Nick="Fran", PersonalPhoneNumber = "456123789", City = "Carmona", Country = "Spain"},
                new Owner { Id = 6, FirstName = "Jorge", Surname = "Palma", Nick="Fran", PersonalPhoneNumber = "654987654", City = "Pizarra", Country = "Spain"},
                new Owner { Id = 7, FirstName = "Juan", Surname = "García", Nick="Juan", PersonalPhoneNumber = "654987654", City = "Almargen", Country = "Spain"},
                new Owner { Id = 8, FirstName = "Manuel", Surname = "Fernández", Nick="Manu", PersonalPhoneNumber = "784596555", City = "Tebas", Country = "Spain"},
                new Owner { Id = 9, FirstName = "Pedro", Surname = "Avila", Nick="Peter", PersonalPhoneNumber = "654987654", City = "Campillos", Country = "Spain"},
                new Owner { Id = 10, FirstName = "Braulio", Surname = "Perez", Nick="", PersonalPhoneNumber = "456321789", City = "Alora", Country = "Spain"},
            };

            var any = context.Owners.Any(w => owners.Select(s => s.Id).ToList().Contains(w.Id));
            if (any) return;
            context.Owners.AddRange(owners);
            context.SaveChanges();

        }
    }
}
