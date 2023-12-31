using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EstadoDto
    {
        //Definimos los atribuctos de cada una de las entidades
        public string ? IdCodigo { get; set; }
        public string ? NombreEstado { get; set; }

        public List<RegionDto> ? Regiones { get; set; }
    }
}