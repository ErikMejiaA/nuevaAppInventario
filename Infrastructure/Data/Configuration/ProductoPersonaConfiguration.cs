using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class ProductoPersonaConfiguration : IEntityTypeConfiguration<ProductoPersona>
{
    public void Configure(EntityTypeBuilder<ProductoPersona> builder)
    {
        
        builder.ToTable("ProductosPersonas");

        //definimos las llaves FOREIGN KEY

        builder.HasOne(p => p.Producto)
        .WithMany(p => p.ProductosPersonas)
        .HasForeignKey(p => p.IdProducto)
        .IsRequired();

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.ProductosPersonas)
        .HasForeignKey(p => p.IdPersona)
        .IsRequired();
    }
}
