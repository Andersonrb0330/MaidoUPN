using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class RolEntityConfiguration : IEntityTypeConfiguration<Rol>
    {
        public RolEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsRequired();

        }
    }
}