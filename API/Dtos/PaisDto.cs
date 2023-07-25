
using Core.Entities;

namespace API.Dtos;

public class PaisDto
{
    //Definimos los atribuctos de la entidad
    public string ? IdCodigo { get; set; }
    public string ? NombrePais { get; set; }
    public List<EstadoDto> ? Estados { get; set; }
}
 