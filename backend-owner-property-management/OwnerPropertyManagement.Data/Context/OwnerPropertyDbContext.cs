using Microsoft.EntityFrameworkCore;

namespace OwnerPropertyManagement.Data.Context
{
    public class OwnerPropertyDbContext : DbContext, IOwnerPropertyDbContext
    {
        public OwnerPropertyDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        }
    }
}
