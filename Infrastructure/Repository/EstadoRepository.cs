using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EstadoRepository : GenericRepositoryA<Estado>, IEstadoInterface
{
    //variable de context
    protected readonly nuevaAppInventarioContext _context;

    //constructor
    public EstadoRepository(nuevaAppInventarioContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Estado>> GetAllAsync()
    {
        return await _context.Set<Estado>()
        .Include(p => p.Regiones)
        .ToListAsync();
    }

    public override async Task<Estado> GetByIdAsync(string id)
    {
        return await _context.Set<Estado>()
        .Include(p => p.Regiones)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

}
