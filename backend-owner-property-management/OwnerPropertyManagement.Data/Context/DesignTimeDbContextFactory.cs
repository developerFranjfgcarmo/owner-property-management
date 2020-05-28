using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwnerPropertyManagement.Data.Context
{
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
