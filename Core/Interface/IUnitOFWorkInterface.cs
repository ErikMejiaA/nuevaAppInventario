namespace Core.Interfaces;

public interface IUnitOFWorkInterface
{
    //generamos cada una de las intefaces que se tiene desarrolladas 
    IEstadoInterface Estados { get; set; }
    IPaisInterface Paises { get; set; }
    IPersonaInterface Personas { get; set; }
    IProductoInterface Productos { get; set; }
    IRegionInterface Regiones { get; set; }
    ITipoPersonaInterface TiposPersonas { get; set; }
    
    //metodo Post
    Task<int> SaveAsync();
}
