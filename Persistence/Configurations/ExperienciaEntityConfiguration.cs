using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class ExperienciaEntityConfiguration : IEntityTypeConfiguration<Experiencia>
    {
        public ExperienciaEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<Experiencia> builder)
        {
            builder.ToTable("Experiencia");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(120)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(400)
                .IsUnicode(false);

            builder.Property(e => e.Precio)
                .HasColumnName("Precio")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.Disponible)
                .HasColumnName("Disponible")
                .IsRequired();

            builder.Property(e => e.IdCategoria)
                .HasColumnName("IdCategoria");

            builder.HasOne(e => e.Categoria)
                .WithMany(c => c.Experiencias)
                .HasForeignKey(e => e.IdCategoria);

        }
    }
}