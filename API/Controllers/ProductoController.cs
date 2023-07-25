using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductoController : BaseApiController
{
     //creamos el constructor de la clase 
     private readonly IUnitOFWorkInterface _UnitOfWork;
     
     public ProductoController(IUnitOFWorkInterface UnitOfWork)
     {
          _UnitOfWork = UnitOfWork;
     }

     //Metodo Get para obtener todos los registros 
     [HttpGet]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<IEnumerable<Producto>>> Get()
     {
          var nameVar = await _UnitOfWork.Productos.GetAllAsync();
          return Ok(nameVar);
     }

     //Metodo Get para traer un unico registro 
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<IActionResult> Get(string id)
     {
          var producto = await _UnitOfWork.Productos.GetByIdAsync(id);
          return Ok(producto);
     }

     //Metodo POST para enviar datos a la entideda de la Db
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<IEnumerable<Producto>>> Post(Producto producto)
     {
          this._UnitOfWork.Productos.Add(producto);
          await _UnitOfWork.SaveAsync();
          if (producto == null) {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new {id = producto.IdCodigo}, producto);
     }

     //Metodo PUT permite editar un registro de la entidad 
     [HttpPut("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<Producto>> Put(string id, [FromBody]Producto producto)
     {
          if (producto == null) {
          return NotFound();
          }
          _UnitOfWork.Productos.Update(producto);
          await _UnitOfWork.SaveAsync();
          return producto;
     }

     //Metodo DELETE permite eliminar un registro de la entidad 
     [HttpDelete("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]
     public async Task<ActionResult> Delete(string id)
     {
          var producto = await _UnitOfWork.Productos.GetByIdAsync(id);
          if (producto == null)
          {
          return NotFound();
          }
          _UnitOfWork.Productos.Remove(producto);
          await _UnitOfWork.SaveAsync();
          return NoContent();
     }

        
}
