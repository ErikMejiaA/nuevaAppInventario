using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        //definimos las propiedades de los atributos de la entidad

        builder.ToTable("Personas");

        builder.Property(p => p.IdCodigo)
        .HasAnnotation("MySql : ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(p => p.NombrePersona)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.ApellidoPersona)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.EmailPersona)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasIndex(p =>p .EmailPersona)
        .IsUnique();

        //definimos la llave FOREIGN KEY

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdTipoPersona);

        builder.HasOne(p => p.Region)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.CodRegion)
        .IsRequired();



    }
}
