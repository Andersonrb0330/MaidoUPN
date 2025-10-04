using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class ReservaMesaEntityConfiguration : IEntityTypeConfiguration<ReservaMesa>
    {
        public ReservaMesaEntityConfiguration() { } 
        public void Configure(EntityTypeBuilder<ReservaMesa> builder)
        {
            builder.ToTable("ReservaMesa");
            builder.HasKey(rm => rm.Id);

            builder.Property(rm => rm.IdReserva)
                .HasColumnName("IdReserva");

            builder.Property(rm => rm.IdMesa)
                .HasColumnName("IdMesa");

            builder.HasOne(rm => rm.Reserva)
                .WithMany(r => r.ReservaMesas)
                .HasForeignKey(rm => rm.IdReserva);

            builder.HasOne(rm => rm.Mesa)
                .WithMany(m => m.ReservaMesas)
                .HasForeignKey(rm => rm.IdMesa);
        }
    }
}