using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Data.Configurations;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigurationBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FacilityConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyFacilityConfiguration());
            modelBuilder.ApplyConfiguration(new TownConfiguration());
            modelBuilder.ApplyConfiguration(new TypesFacilityConfiguration());
            modelBuilder.ApplyConfiguration(new ZoneConfiguration());
        }

        public static void SeedZoneTown(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zone>().HasData(
                new Zone {Id = 1, Description = "Costa del Sol"},
                new Zone {Id = 2, Description = "Costa Brava"},
                new Zone {Id = 3, Description = "Costa Blanco"}
            );
            modelBuilder.Entity<Town>().HasData(
                new Town {Id = 1, Description = "Fuenguirola", ZoneId = 1},
                new Town {Id = 2, Description = "Estepona", ZoneId = 1},
                new Town {Id = 3, Description = "Benalmadena", ZoneId = 1},
                new Town {Id = 4, Description = "Begur", ZoneId = 2},
                new Town {Id = 5, Description = "Blanes", ZoneId = 2},
                new Town {Id = 6, Description = "Denia", ZoneId = 3},
                new Town {Id = 7, Description = "Altea", ZoneId = 3}
            );
        }

        public static void SeedTypesFacility(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypesFacility>().HasData(
                new TypesFacility {Id = 1, Description = "General"},
                new TypesFacility {Id = 2, Description = "Outside"},
                new TypesFacility {Id = 3, Description = "Inside"},
                new TypesFacility {Id = 4, Description = "Kitchen"},
                new TypesFacility {Id = 5, Description = "Bathroom"},
                new TypesFacility {Id = 6, Description = "Views"},
                new TypesFacility {Id = 7, Description = "Relevant information"}
            );
        }

        public static void SeedFacility(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>().HasData(
                new Facility {Id = 1, Description = "Beach towels", TypeFacilityId = 1},
                new Facility {Id = 2, Description = "Linen", TypeFacilityId = 1},
                new Facility {Id = 3, Description = "Towels", TypeFacilityId = 1},
                new Facility {Id = 4, Description = "Private pool", TypeFacilityId = 2},
                new Facility {Id = 5, Description = "Heated pool", TypeFacilityId = 2},
                new Facility {Id = 6, Description = "Outside jacuzzi", TypeFacilityId = 2},
                new Facility {Id = 7, Description = "Garden", TypeFacilityId = 2},
                new Facility {Id = 8, Description = "Parking", TypeFacilityId = 2},
                new Facility {Id = 9, Description = "Barbecue", TypeFacilityId = 2},
                new Facility {Id = 10, Description = "Sunbeds", TypeFacilityId = 2},
                new Facility {Id = 11, Description = "Wi-Fi", TypeFacilityId = 3},
                new Facility {Id = 12, Description = "Satellite", TypeFacilityId = 3},
                new Facility {Id = 13, Description = "Tv", TypeFacilityId = 3},
                new Facility {Id = 14, Description = "Cot", TypeFacilityId = 3},
                new Facility {Id = 15, Description = "Iron", TypeFacilityId = 3},
                new Facility {Id = 16, Description = "Safe", TypeFacilityId = 3},
                new Facility {Id = 17, Description = "Air conditioning", TypeFacilityId = 3},
                new Facility {Id = 18, Description = "Dishwasher", TypeFacilityId = 4},
                new Facility {Id = 19, Description = "Freezer", TypeFacilityId = 4},
                new Facility {Id = 20, Description = "Fridge", TypeFacilityId = 4},
                new Facility {Id = 21, Description = "Coffee machine", TypeFacilityId = 4},
                new Facility {Id = 22, Description = "Grill", TypeFacilityId = 4},
                new Facility {Id = 23, Description = "Hob", TypeFacilityId = 4},
                new Facility {Id = 24, Description = "Microwave", TypeFacilityId = 4},
                new Facility {Id = 25, Description = "Jacuzzi", TypeFacilityId = 5},
                new Facility {Id = 26, Description = "Shower", TypeFacilityId = 5},
                new Facility {Id = 27, Description = "Bath tub", TypeFacilityId = 5},
                new Facility {Id = 28, Description = "Hair dryer", TypeFacilityId = 5},
                new Facility {Id = 29, Description = "Sea views", TypeFacilityId = 6},
                new Facility {Id = 30, Description = "Mountain views", TypeFacilityId = 6},
                new Facility {Id = 31, Description = "Pool views", TypeFacilityId = 6},
                new Facility {Id = 32, Description = "Wheelchair accessible", TypeFacilityId = 7},
                new Facility {Id = 33, Description = "Suitable for the elderly", TypeFacilityId = 7},
                new Facility {Id = 34, Description = "Pets considered", TypeFacilityId = 7},
                new Facility {Id = 35, Description = "No smoking inside", TypeFacilityId = 7},
                new Facility {Id = 36, Description = "Car not necessary", TypeFacilityId = 7},
                new Facility {Id = 37, Description = "Car recommended", TypeFacilityId = 7}
            );
        }
    }
}