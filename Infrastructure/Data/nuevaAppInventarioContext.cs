
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class nuevaAppInventarioContext : DbContext
{
     public nuevaAppInventarioContext(DbContextOptions<nuevaAppInventarioContext> options) : base(options)
    {
        
    }

    //aqui van referencias de las entidades creadas
    public DbSet<Region> ? Regiones { get; set; }
    public DbSet<Pais> ? Paises { get; set; }
    public DbSet<Estado> ? Estados { get; set; } 
    public DbSet<Persona> ? Personas { get; set; }
    public DbSet<TipoPersona> ? TiposPersonas { get; set; }
    public DbSet<Producto> ? Productos { get; set; }
    public DbSet<ProductoPersona> ? ProductosPersonas { get; set; }
        
    //metodo para cargar de forma automatica las entidades y configuraciones de estas en la base de datos creada 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //definimos las llaves primarias campuestas de la entida ProductoPersona. de una relacion de muchos a muchos
        modelBuilder.Entity<ProductoPersona>().HasKey(p => new { p.IdProducto, p.IdPersona} );

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    internal void SaveAsync()
    {
        throw new NotImplementedException();
    }
        
}
