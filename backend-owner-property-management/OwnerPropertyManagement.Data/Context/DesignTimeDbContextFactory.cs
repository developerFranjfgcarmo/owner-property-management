using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerPropertyManagement.Data.Context
{
    /// <summary>
    ///     Implement this interface to enable design-time services for context types that do not have a public
    ///     default constructor. Design-time services will automatically discover implementations of this interface
    ///     that are in the same assembly as the derived context.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OwnerPropertyDbContext>
    {
        public OwnerPropertyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OwnerPropertyDbContext>();
            builder.UseSqlServer("Server=.\\;Database=OwnerProperty;Trusted_Connection=True;");
            return new OwnerPropertyDbContext(builder.Options);
        }
    }
}
