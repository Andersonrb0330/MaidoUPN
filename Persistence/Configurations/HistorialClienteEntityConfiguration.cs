using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class HistorialClienteEntityConfiguration: IEntityTypeConfiguration<HistorialCliente>
    {
        public HistorialClienteEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<HistorialCliente> builder)
        {
            builder.ToTable("HistorialCliente");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.FechaVisita)
                .HasColumnName("FechaVisita")
                .IsRequired();

            builder.Property(h => h.Observaciones)
                .HasColumnName("Observaciones")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(h => h.IdCliente)
                .HasColumnName("IdCliente")
                .IsRequired();

            builder.HasOne(h => h.Cliente)
                .WithMany(c => c.HistorialClientes)
                .HasForeignKey(h => h.IdCliente);
        }
    }
}