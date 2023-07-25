using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EstadoController : BaseApiController
{
     //creamos el constructor de la clase
     private readonly IUnitOFWorkInterface _UnitOfWork;
     private readonly IMapper mapper;

     public EstadoController(IUnitOFWorkInterface UnitOfWork, IMapper mapper)
     {
          _UnitOfWork = UnitOfWork;
          this.mapper = mapper;
     }

     //metodo Get para obtener todo los registros de la entidad Estado de la Db
     [HttpGet]
     [ApiVersion("1.0")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<List<EstadosDTo>> Get()
     {
          var estados = await _UnitOfWork.Estados.GetAllAsync();
          return this.mapper.Map<List<EstadosDTo>>(estados);
     }

     //metodo GET para obtener un Unico Registro de la entidad EStado de la Db
     [HttpGet("{id}")]
     [ApiVersion("1.0")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EstadoDto>> Get(string id)
     {
          var estado = await _UnitOfWork.Estados.GetByIdAsync(id);
          return this.mapper.Map<EstadoDto>(estado);
     }

     //Metodo POST para enviar registros a la base de datos
     [HttpPost]
     [ApiVersion("1.0")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EstadosDTo>> Post(EstadosDTo estadoDTo)
     {
          var estado = this.mapper.Map<Estado>(estadoDTo);
          this._UnitOfWork.Estados.Add(estado);
          await _UnitOfWork.SaveAsync();
          if (estado == null) {
               return BadRequest();
          }
          estadoDTo.IdCodigo = estado.IdCodigo;
          return CreatedAtAction(nameof(Post), new {id = estadoDTo.IdCodigo}, estadoDTo);
     }

     //Metodo PUT permite editar un registro de la entidad 
     [HttpPut("{id}")]
     [ApiVersion("1.0")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]
     [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult<EstadosDTo>> Put(string id, [FromBody]EstadosDTo estadoDTo)
     {
          if (estadoDTo == null) {
               return NotFound();
          }
          var estado = this.mapper.Map<Estado>(estadoDTo);
          _UnitOfWork.Estados.Update(estado);
          await _UnitOfWork.SaveAsync();
          return estadoDTo;
     }

     //Metodo DELETE permite eliminar un registro de la entidad 
     [HttpDelete("{id}")]
     [ApiVersion("1.0")]
     [ProducesResponseType(StatusCodes.Status200OK)]
     [ProducesResponseType(StatusCodes.Status404NotFound)]
     public async Task<ActionResult> Delete(string id)
     {
          var estado = await _UnitOfWork.Estados.GetByIdAsync(id);
          if (estado == null) {
               return NotFound();
          }
          _UnitOfWork.Estados.Remove(estado);
          await _UnitOfWork.SaveAsync();
          return NoContent();
     }
        
}
