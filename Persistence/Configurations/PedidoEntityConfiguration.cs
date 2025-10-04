﻿using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class PedidoEntityConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public PedidoEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Fecha)
                .HasColumnName("Fecha")
                .IsRequired();

            builder.Property(p => p.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(p => p.IdReserva)
                 .HasColumnName("IdReserva")
                 .IsRequired();

            builder.Property(p => p.IdCliente)
                .HasColumnName("IdCliente"); 

            builder.HasOne(p => p.Reserva)
                .WithMany(r => r.Pedidos)
                .HasForeignKey(p => p.IdReserva);

            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.IdCliente);

        }
    }
}