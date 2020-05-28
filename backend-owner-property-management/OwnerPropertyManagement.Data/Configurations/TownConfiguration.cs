using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Data.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Town");
            builder.Property(p => p.Description).HasMaxLength(50);
            builder.HasOne(ho => ho.Zone).WithMany(wm => wm.Towns).HasForeignKey(fk => fk.ZoneId);
        }
    }
}
