
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PersonaRepository : GenericRepositoryA<Persona>, IPersonaInterface
{
    protected readonly nuevaAppInventarioContext _context;

    //constructor
    public PersonaRepository(nuevaAppInventarioContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Set<Persona>().ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(string id)
    {
        return await _context.Set<Persona>().FindAsync(id);
    }

}
