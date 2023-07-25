using System.ComponentModel.DataAnnotations;
namespace Core.Entities;

public class BaseEntityA
{
    [Key] //se define la llave primaria 
    public string ? IdCodigo { get; set; }    
}
