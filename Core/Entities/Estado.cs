using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Estado : BaseEntityA
{
    //Definimos los atribuctos de cada una de las entidades
    public string ? NombreEstado { get; set; }
    public string ? CodPais { get; set; }

    //Definimos sus ICollection
    public ICollection<Region> ? Regiones { get; set; }

    //Definimos una referencia a la entidad Pais
    public Pais ? Pais { get; set; }

        
}
