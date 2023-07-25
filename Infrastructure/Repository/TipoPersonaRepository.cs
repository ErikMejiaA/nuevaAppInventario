
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TipoPersonaRepository : GenericRepositoryB<TipoPersona>, ITipoPersonaInterface
{
    protected readonly nuevaAppInventarioContext _context;

    public TipoPersonaRepository(nuevaAppInventarioContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
    {
        return await _context.Set<TipoPersona>().ToListAsync();
    }

    public override async Task<TipoPersona> GetByIdAsync(int id)
    {
        return await _context.Set<TipoPersona>().FindAsync(id);
    }

}
