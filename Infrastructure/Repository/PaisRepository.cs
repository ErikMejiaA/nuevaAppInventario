
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PaisRepository : GenericRepositoryA<Pais>, IPaisInterface
{
    //variable de contexto
    protected readonly nuevaAppInventarioContext _context;
    //constructor
    public PaisRepository(nuevaAppInventarioContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        //return await _context.Set<Pais>().ToListAsync();
        return await _context.Set<Pais>()
        .Include(p => p.Estados) 
        .ToListAsync();
        
    }

    public override async Task<Pais> GetByIdAsync(string id)
    {
        return await _context.Set<Pais>()
        .Include(p => p.Estados)
        .FirstOrDefaultAsync(p => p.IdCodigo == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Paises as IQueryable<Pais>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombrePais.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Estados)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return (totalRegistros, registros);
    }



}
