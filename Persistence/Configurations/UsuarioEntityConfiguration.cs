using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public UsuarioEntityConfiguration() { } 
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .HasColumnName("Username")
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(120)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnName("Password")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(10)
                .IsUnicode(false);

        }
    }
}