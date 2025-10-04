using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class PedidoDetalleEntityConfiguration : IEntityTypeConfiguration<PedidoDetalle>
    {
        public PedidoDetalleEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<PedidoDetalle> builder)
        {
            builder.ToTable("PedidoDetalle");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Cantidad)
                .HasColumnName("Cantidad")
                .IsRequired();

            builder.Property(d => d.PrecioUnitario)
                .HasColumnName("PrecioUnitario")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(d => d.Comentarios)
                .HasColumnName("Comentarios")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(d => d.IdPedido)
                .HasColumnName("IdPedido")
                .IsRequired();

            builder.Property(d => d.IdExperiencia)
                .HasColumnName("IdExperiencia")
                .IsRequired();

            builder.HasOne(d => d.Pedido)
                .WithMany(p => p.PedidoDetalles)
                .HasForeignKey(d => d.IdPedido);

            builder.HasOne(d => d.Experiencia)
                .WithMany(e => e.PedidoDetalles)
                .HasForeignKey(d => d.IdExperiencia);
        }
    }
}