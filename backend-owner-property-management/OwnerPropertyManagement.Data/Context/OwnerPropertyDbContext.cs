using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Data.Entities;
using OwnerPropertyManagement.Data.Extensions;

namespace OwnerPropertyManagement.Data.Context
{
    public class OwnerPropertyDbContext : DbContext, IOwnerPropertyDbContext
    {
        public OwnerPropertyDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurationBuilder();
        }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PropertyFacility> PropertyFacilities { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<TypesFacility> TypesFacilities { get; set; }
        public DbSet<Zone> Zones { get; set; }
    }
}
