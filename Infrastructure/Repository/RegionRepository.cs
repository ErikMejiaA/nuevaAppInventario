
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class RegionRepository : GenericRepositoryA<Region>, IRegionInterface
{
    //variable context
    protected readonly nuevaAppInventarioContext _context;
    //constructor
    public RegionRepository(nuevaAppInventarioContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await _context.Set<Region>().ToListAsync();
    }

    public override async Task<Region> GetByIdAsync(string id)
    {
        return await _context.Set<Region>().FindAsync(id);
    }

}
