using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOFWorkInterface, IDisposable
{
    //variable context
    private readonly nuevaAppInventarioContext _context;

    //generamos variables de cada repositorio creado
    private EstadoRepository ? _estados; 
    private PaisRepository ? _paises;
    private PersonaRepository ? _personas;
    private ProductoRepository ? _productos;
    private RegionRepository ? _regiones;
    private TipoPersonaRepository ? _tiposPersonas;

    //generamos el constructor de la variable context
    public UnitOfWork(nuevaAppInventarioContext context)
    {
        _context = context;
    }

    //generamos el constructor de las varibales del repository
    //Estados
    public IEstadoInterface Estados 
    {
        get
        {
            if (_estados == null) {
                _estados = new EstadoRepository(_context);
            }
            return _estados;
        }

        set 
        {
            if (_estados == null) {
                _estados = new EstadoRepository(_context);
            }
        }

    }

    //Paises
    public IPaisInterface Paises
    {
        get
        {
            if (_paises == null) {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }

        set 
        {
            if (_paises == null) {
                _paises = new PaisRepository(_context);
            }
        }
    }

    //Personas
    public IPersonaInterface Personas
    {
        get
        {
            if (_personas == null) {
                _personas = new PersonaRepository(_context);
            }
            return _personas;
        }

        set 
        {
            if (_personas == null) {
                _personas = new PersonaRepository(_context);
            }
        }
    }

    //Productos
    public IProductoInterface Productos
    {
        get
        {
            if (_productos == null) {
                _productos = new ProductoRepository(_context);
            }
            return _productos;
        }

        set 
        {
            if (_productos == null) {
                _productos = new ProductoRepository(_context);
            }
        }
    }

    //Regiones 
    public IRegionInterface Regiones
    {
        get
        {
            if (_regiones == null) {
                _regiones = new RegionRepository(_context);
            }
            return _regiones;
        }

        set 
        {
            if (_regiones == null) {
                _regiones = new RegionRepository(_context);
            }
        }
    }

    //TiposPersonas
    public ITipoPersonaInterface TiposPersonas
    {
        get
        {
            if (_tiposPersonas == null) {
                _tiposPersonas = new TipoPersonaRepository(_context);
            }
            return _tiposPersonas;
        }

        set 
        {
            if (_tiposPersonas == null) {
                _tiposPersonas = new TipoPersonaRepository(_context);
            }
        }
    }

    public void Dispose()
    {
        _context.Dispose(); //destruir el contexto si no se esta Utilizando, liberar memoria 
    }
    
    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    
}
