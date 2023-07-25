using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class RegionController : BaseApiController
{
    //definimos el constructor de la clase 
    private readonly IUnitOFWorkInterface _UnitOfWork;
    
    public RegionController(IUnitOFWorkInterface UnitOfWork)
    {
       _UnitOfWork = UnitOfWork;
    }

    //metodo GET para obtener todos los registros
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Region>>> Get()
    {
        var regions = await _UnitOfWork.Regiones.GetAllAsync();
        return Ok(regions);
    }

    //Metodo GET para obtener un uniuco registro 
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(string id)
    {
        var region = await _UnitOfWork.Regiones.GetByIdAsync(id);
        return Ok(region);
    }
        
    //Metodo POST para enviar datos a la entideda de la Db
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Region>>> Post(Region region)
    {

        this._UnitOfWork.Regiones.Add(region);
        await _UnitOfWork.SaveAsync();
        if (region == null) {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = region.IdCodigo}, region);
    }

    //Metodo PUT permite editar un registro de la entidad 
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Put(string id, [FromBody]Region region)
    {
        if (region == null) {
            return NotFound();
        }
        _UnitOfWork.Regiones.Update(region);
        await _UnitOfWork.SaveAsync();
        return region;
    }

    //Metodo DELETE permite eliminar un registro de la entidad 
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(string id)
    {
        var region = await _UnitOfWork.Regiones.GetByIdAsync(id);
        if (region == null)
        {
        return NotFound();
        }
        _UnitOfWork.Regiones.Remove(region);
        await _UnitOfWork.SaveAsync();
        return NoContent();
    }

}