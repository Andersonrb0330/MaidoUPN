using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class ReservaEntityConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public ReservaEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.NombreCompleto)
                .HasColumnName("NombreCompleto")
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.CorreoElectronico)
                .HasColumnName("CorreoElectronico")
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(r => r.Fecha)
                .HasColumnName("Fecha")
                .IsRequired();

            builder.Property(r => r.Telefono)
               .HasColumnName("Telefono")
               .HasMaxLength(20)
               .IsUnicode(false)
               .IsRequired();

            builder.Property(r => r.Dni)
               .HasColumnName("Dni")
               .HasMaxLength(8)
               .IsUnicode(false)
               .IsRequired();

            builder.Property(r => r.Hora)
                .HasColumnName("Hora")
                .IsRequired();

            builder.Property(r => r.CantidadPersonas)
                .HasColumnName("CantidadPersonas")
                .IsRequired();

            builder.Property(r => r.Notas)
                .HasColumnName("Notas")
                .HasMaxLength(250)
                .IsUnicode(false);
        }
    }
}