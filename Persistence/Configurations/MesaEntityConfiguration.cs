using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class MesaEntityConfiguration : IEntityTypeConfiguration<Mesa>
    {
        public MesaEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            builder.ToTable("Mesa");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Numero)
                .HasColumnName("Numero")
                .IsRequired();

            builder.Property(m => m.Capacidad)
                .HasColumnName("Capacidad")
                .IsRequired();

            builder.Property(m => m.Ubicacion)
                .HasColumnName("Ubicacion")
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(m => m.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(m => m.Piso)
              .HasColumnName("Piso")
              .IsRequired();

        }
    }
}