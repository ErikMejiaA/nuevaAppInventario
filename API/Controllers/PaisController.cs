using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

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
   public async Task<List<PaisesDto>> Get()
   {
      var paises = await _UnitOfWork.Paises.GetAllAsync();
      return this.mapper.Map<List<PaisesDto>>(paises);
   }*/

   [HttpGet]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   [ProducesResponseType(StatusCodes.Status304NotModified)]
   public async Task<ActionResult<Pager<PaisDto>>> Get([FromQuery] Params paisParams)
   {
      var pais = await _UnitOfWork.Paises.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
      var lstPaisesDto = this.mapper.Map<List<PaisDto>>(pais.registros);
      return new Pager<PaisDto>(lstPaisesDto, pais.totalRegistros,  paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
   }

   [HttpGet]
   [MapToApiVersion("1.1")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<List<PaisesDto>> Get11()
   {
      var paises = await _UnitOfWork.Paises.GetAllAsync();
      return this.mapper.Map<List<PaisesDto>>(paises);
   }

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
   public async Task<ActionResult<PaisesDto>> Post(PaisesDto paisDto)
   {

      var pais = this.mapper.Map<Pais>(paisDto);
      this._UnitOfWork.Paises.Add(pais);
      await _UnitOfWork.SaveAsync();
      if (pais == null) {
         return BadRequest();
      }
      paisDto.IdCodigo = pais.IdCodigo;
      return CreatedAtAction(nameof(Post), new {id = paisDto.IdCodigo}, paisDto);
   }

   //Metodo PUT permite editar un registro de la entidad 
   [HttpPut("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<ActionResult<PaisesDto>> Put(string id, [FromBody]PaisesDto paisDto)
   {
      
      if (paisDto == null) {
         return NotFound();
      }

      var pais = this.mapper.Map<Pais>(paisDto);
      pais.IdCodigo = id;
      _UnitOfWork.Paises.Update(pais);
      await _UnitOfWork.SaveAsync();
      return paisDto;
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
