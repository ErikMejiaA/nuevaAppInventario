
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProductoRepository : GenericRepositoryA<Producto>, IProductoInterface
{
    //variable de contexto
    protected readonly nuevaAppInventarioContext _context;

    //constructor
    public ProductoRepository(nuevaAppInventarioContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Set<Producto>().ToListAsync();
    }

    public override async Task<Producto> GetByIdAsync(string id)
    {
        return await _context.Set<Producto>().FindAsync(id);
    }
    
}
