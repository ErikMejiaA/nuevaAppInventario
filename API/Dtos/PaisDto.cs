
using Core.Entities;

namespace API.Dtos;

public class PaisDto
{
    //Definimos los atribuctos de la entidad
    public string ? codPais { get; set; }
    public string ? nombrePais { get; set; }
    public List<EstadoDto> ? estados { get; set; }
}
 