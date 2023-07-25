namespace Core.Entities;

public class ProductoPersona
{
    //definimos los atributos de las entidad
    public string ? IdPersona { get; set; }
    public string ? IdProducto { get; set; }

    //definimos una referencia
    public Persona ? Persona { get; set; }
    public Producto ? Producto { get; set; }
    
        
}
