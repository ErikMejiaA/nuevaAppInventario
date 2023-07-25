namespace Core.Entities;

public class TipoPersona : BaseEntityB
{
    //definimos los atributos de la entidad
    public string ? Descripcion { get; set; }

    //definimos los ICollection a la entidad
    public ICollection<Persona> ? Personas { get; set; }
        
}
