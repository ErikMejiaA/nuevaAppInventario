using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Pais : BaseEntityA
{
    //Definimos los atribuctos de cada una de las entidades
    public string ? NombrePais { get; set; }

    //definimos las ICollection
    public ICollection<Estado> ? Estados { get; set;}


}
