using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Producto : BaseEntityA
{
   //ddefinimos los atributos de la entidad 
   public string ? NombreProducto { get; set; }
   public string ? Descripcion { get; set; }
   public double Precio { get; set; } 
   public int StockMinimo { get; set; }
   public int StockMaximo { get; set; }

   //deinimos una ICollection
   public ICollection<ProductoPersona> ? ProductosPersonas { get; set; }
   
        
}
