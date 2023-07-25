using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PaisController : BaseApiController
{
   private readonly IUnitOFWorkInterface _UnitOfWork;
   private readonly IMapper mapper;
   public PaisController(IUnitOFWorkInterface UnitOfWork, IMapper mapper)
   {
      _UnitOfWork = UnitOfWork;
      this.mapper = mapper;
    }

   //Metodo Get para lsiatr todo los paises de la base de datos
   /*[HttpGet]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<ActionResult<IEnumerable<Pais>>> Get()
   {
      var paises = await _UnitOfWork.Paises.GetAllAsync();
      return Ok(paises);
   }*/
   [HttpGet]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<List<PaisDto>> Get()
   {
      var paises = await _UnitOfWork.Paises.GetAllAsync();
      return this.mapper.Map<List<PaisDto>>(paises);
   }

   /*[HttpGet]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<List<PaisDto>> Get()
   {
      List<Pais> paisesFinal = new();
      var paises = await _UnitOfWork.Paises.GetAllAsync();
      foreach (Pais item in paises)
      {
         var p = await _UnitOfWork.Paises.GetByIdAsync(item.codPais);
         paisesFinal.Add(p);
      }
      return this.mapper.Map<List<PaisDto>>(paisesFinal);
      
   }*/

   //Metodo Get para solo traer un unico registro de la base de datos
   [HttpGet("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<ActionResult<PaisDto>> Get(string id)
   {
      var pais = await _UnitOfWork.Paises.GetByIdAsync(id);
      return this.mapper.Map<PaisDto>(pais);
   }

   //Metodo POST para enviar datos a la entideda de la Db
   [HttpPost]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<ActionResult<IEnumerable<Pais>>> Post(Pais pais)
   {

      this._UnitOfWork.Paises.Add(pais);
      await _UnitOfWork.SaveAsync();
      if (pais == null) {
         return BadRequest();
      }
      return CreatedAtAction(nameof(Post), new {id = pais.IdCodigo}, pais);
   }

   //Metodo PUT permite editar un registro de la entidad 
   [HttpPut("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<ActionResult<Pais>> Put(string id, [FromBody]Pais pais)
   {
      if (pais == null) {
         return NotFound();
      }
      _UnitOfWork.Paises.Update(pais);
      await _UnitOfWork.SaveAsync();
      return pais;
   }

   //Metodo DELETE permite eliminar un registro de la entidad 
   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public async Task<ActionResult> Delete(string id)
   {
      var pais = await _UnitOfWork.Paises.GetByIdAsync(id);
      if (pais == null)
      {
         return NotFound();
      }
      _UnitOfWork.Paises.Remove(pais);
      await _UnitOfWork.SaveAsync();
      return NoContent();
   }

}
