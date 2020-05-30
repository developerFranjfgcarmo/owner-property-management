using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Data.Configurations
{
    public class PropertyFacilityConfiguration : IEntityTypeConfiguration<PropertyFacility>
    {
        public void Configure(EntityTypeBuilder<PropertyFacility> builder)
        {
            builder.ToTable("PropertyFacility");
            builder.HasOne(ho => ho.Property).WithMany(wm => wm.PropertyFacilities).HasForeignKey(fk => fk.PropertyId);
            builder.HasOne(ho => ho.Facility).WithMany(wm => wm.PropertyFacilities).HasForeignKey(fk => fk.FacilityId);
        }
    }
}
