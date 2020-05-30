using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Data.Configurations
{
    public class FacilityConfiguration: IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.ToTable("Facility");
            builder.Property(p => p.Description).HasMaxLength(50);
            builder.HasOne(ho => ho.TypesFacility).WithMany(wm => wm.Facilities).HasForeignKey(fk => fk.TypeFacilityId);
        }
    }
}
