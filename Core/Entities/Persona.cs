using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Persona : BaseEntityA
{
    //definimos los atributos de la entidad
    public string ? NombrePersona { get; set; }
    public string ? ApellidoPersona { get; set; }
    public string ? EmailPersona { get; set; }
    public string ? CodRegion { get; set; }

    //definimos la llave foranea
    public int IdTipoPersona { get; set; }

    //Definimos la referencia a la entidad
    public TipoPersona ? TipoPersona { get; set; }
    public Region ? Region { get; set; }

    //deinimos una ICollection
    public ICollection<ProductoPersona> ? ProductosPersonas { get; set; }

        
}
