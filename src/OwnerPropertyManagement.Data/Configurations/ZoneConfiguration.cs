using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Data.Configurations
{
    public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.ToTable("Zone");
            builder.Property(p => p.Description).HasMaxLength(50);
        }
    }
}
