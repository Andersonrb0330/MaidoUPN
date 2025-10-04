using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class CategoriaEntityConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public CategoriaEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(200)
                .IsUnicode(false);

        }
    }
}