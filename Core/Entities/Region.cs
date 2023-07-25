using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Region : BaseEntityA
{
    //Definimos los atribuctos de cada una de las entidades
    public string ? NombreRegion { get; set; }
    public string ? CodEstado { get; set; }

    //Definimos una referencia a la entidad Estado
    public Estado ? Estado { get; set;}

    //definimos una ICollection
    public ICollection<Persona> ? Personas { get; set; }

        
}
