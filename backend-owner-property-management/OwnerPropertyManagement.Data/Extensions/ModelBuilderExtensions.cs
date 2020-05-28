using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Data.Configurations;

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
    }
}
