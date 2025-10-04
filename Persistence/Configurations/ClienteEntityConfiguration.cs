using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public ClienteEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.ApellidoPaterno)
                .HasColumnName("ApellidoPaterno")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.ApellidoMaterno)
                .HasColumnName("ApellidoMaterno")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(c => c.Telefono)
                .HasColumnName("Telefono")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(c => c.FechaNacimiento)
                .HasColumnName("FechaNacimiento");

            builder.Property(c => c.FechaRegistro)
                .HasColumnName("FechaRegistro")
                .IsRequired();
        }
    }
}