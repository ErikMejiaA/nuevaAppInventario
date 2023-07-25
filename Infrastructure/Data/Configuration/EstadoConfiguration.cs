using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estados");

        builder.Property(p => p.IdCodigo)
        .IsRequired()
        .HasAnnotation("MySql : ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasMaxLength(3);

        builder.Property(p => p.nombreEstado)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasIndex(p => p.nombreEstado)
        .IsUnique();

        //Añadimos la llave FOREIGN KEY
        builder.HasOne(p => p.Pais)
        .WithMany(p => p.Estados)
        .HasForeignKey(p => p.codPais)
        .IsRequired();
        
    }
}
