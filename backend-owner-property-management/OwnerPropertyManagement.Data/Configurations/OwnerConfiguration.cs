using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnerPropertyManagement.Data.Entities;

namespace OwnerPropertyManagement.Data.Configurations
{
    public class OwnerConfiguration: IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");
            builder.Property(p => p.FirstName).HasMaxLength(50);
            builder.Property(p => p.Surname).HasMaxLength(50);
            builder.Property(p => p.Nick).HasMaxLength(50);
            builder.Property(p => p.PersonalPhoneNumber).HasMaxLength(20);
            builder.Property(p => p.ContactPhoneProperty).HasMaxLength(20);
            builder.Property(p => p.Street).HasMaxLength(150);
            builder.Property(p => p.PostalCode).HasMaxLength(5);
            builder.Property(p => p.City).HasMaxLength(100);
            builder.Property(p => p.Country).HasMaxLength(100);
            builder.Property(p => p.AboutMe).HasMaxLength(500);
        }
    }
}
