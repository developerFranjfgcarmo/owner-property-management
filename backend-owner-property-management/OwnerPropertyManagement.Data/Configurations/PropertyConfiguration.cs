using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Data.Configurations
{
    public class PropertyConfiguration: IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property");
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(2000);
            builder.Property(p => p.LocalLeisure).HasMaxLength(250);
            builder.Property(p => p.LocalActivities).HasMaxLength(250);
            builder.HasOne(ho => ho.Owner).WithMany(wm => wm.Properties).HasForeignKey(fk => fk.OwnerId);
        }
    }
}
