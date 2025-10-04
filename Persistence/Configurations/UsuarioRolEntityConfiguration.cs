using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class UsuarioRolEntityConfiguration : IEntityTypeConfiguration<UsuarioRol>
    {
        public UsuarioRolEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
        {
            builder.ToTable("UsuarioRol");
            builder.HasKey(ur => ur.Id);

            builder.Property(ur => ur.IdUsuario)
                .HasColumnName("IdUsuario");

            builder.Property(ur => ur.IdRol)
                .HasColumnName("IdRol");

            builder.HasOne(ur => ur.Usuario)
                .WithMany(u => u.UsuarioRols)
                .HasForeignKey(ur => ur.IdUsuario);

            builder.HasOne(ur => ur.Rol)
                .WithMany(r => r.UsuarioRols)
                .HasForeignKey(ur => ur.IdRol);
        }
    }
}