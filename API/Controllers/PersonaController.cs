using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PersonaController : BaseApiController
{
     //generamos el constructor de la clase 
     private readonly IUnitOFWorkInterface _UnitOfWork;

     public PersonaController(IUnitOFWorkInterface UnitOfWork)
     {
          _UnitOfWork = UnitOfWork;
     }

     //metodo GET para obtener todos los registros de la netidad Persona de la Db
     [HttpGet]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<IEnumerable<Persona>>> Get()
     {
          var personas = await _UnitOfWork.Personas.GetAllAsync();
          return Ok(personas);
     }

     //metodo GET para traer un unico registro de la entidad Persona de la Db
     [HttpGet("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<IActionResult> Get(string id)
     {
          var persona = await _UnitOfWork.Personas.GetByIdAsync(id);
          return Ok(persona);
     }

     //Metodo POST para enviar datos a la entideda de la Db
     [HttpPost]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<IEnumerable<Persona>>> Post(Persona persona)
     {

          this._UnitOfWork.Personas.Add(persona);
          await _UnitOfWork.SaveAsync();
          if (persona == null)
          {
               return BadRequest();
          }
          return CreatedAtAction(nameof(Post), new { id = persona.IdCodigo}, persona);
     }

     //Metodo PUT permite editar un registro de la entidad 
     [HttpPut("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<Persona>> Put(string id, [FromBody]Persona persona)
     {
          if (persona == null) {
          return NotFound();
          }
          _UnitOfWork.Personas.Update(persona);
          await _UnitOfWork.SaveAsync();
          return persona;
     }

     //Metodo DELETE permite eliminar un registro de la entidad 
     [HttpDelete("{id}")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]
     public async Task<ActionResult> Delete(string id)
     {
          var persona = await _UnitOfWork.Personas.GetByIdAsync(id);
          if (persona == null)
          {
          return NotFound();
          }
          _UnitOfWork.Personas.Remove(persona);
          await _UnitOfWork.SaveAsync();
          return NoContent();
     }
     
}
