using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Data.Configurations
{
    public class TypesFacilityConfiguration : IEntityTypeConfiguration<TypesFacility>
    {
        public void Configure(EntityTypeBuilder<TypesFacility> builder)
        {
            builder.ToTable("TypesFacility");
            builder.Property(p => p.Description).HasMaxLength(50);
        }
    }
}
