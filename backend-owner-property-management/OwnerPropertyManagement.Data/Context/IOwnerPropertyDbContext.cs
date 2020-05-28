using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Data.Context
{
    public interface IOwnerPropertyDbContext : IDisposable
    {
        DbSet<Facility> Facilities { get; set; }
        DbSet<Owner> Owners { get; set; }
        DbSet<PropertyFacility> PropertyFacilities { get; set; }
        DbSet<Property> Properties { get; set; }
        DbSet<Town> Towns { get; set; }
        DbSet<TypesFacility> TypesFacilities { get; set; }
        DbSet<Zone> Zones { get; set; }
        DatabaseFacade Database { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken());

        EntityEntry Entry(object entity);
    }
}
