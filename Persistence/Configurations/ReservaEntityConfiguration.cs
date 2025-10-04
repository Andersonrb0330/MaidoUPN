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

            builder.Property(r => r.Fecha)
                .HasColumnName("Fecha")
                .IsRequired();

            builder.Property(r => r.Hora)
                .HasColumnName("Hora")
                .IsRequired();

            builder.Property(r => r.CantidadPersonas)
                .HasColumnName("CantidadPersonas")
                .IsRequired();

            builder.Property(r => r.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(r => r.Notas)
                .HasColumnName("Notas")
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(r => r.IdCliente)
                .HasColumnName("IdCliente")
                .IsRequired();

            builder.HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.IdCliente);
        }
    }
}