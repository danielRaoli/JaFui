using Microsoft.AspNetCore.Mvc;
using ViagemApi.Contracts;
using ViagemApi.Data.Dtos;
using ViagemApi.Model;
using ViagemApi.Services;
using ViagemApi.ViewModels;

namespace ViagemApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DestinosController : ControllerBase
{
    private readonly IDestinoService _service;

    public DestinosController(IDestinoService destinoService)
    {
        _service = destinoService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] ViewCreateDestino createDestino)
    {



        await _service.CreateDestino(createDestino);

        return CreatedAtAction(nameof(Get), new { name = createDestino.Name });

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResumoDestinoDto>>> GetAll()
    {
        try
        {

            var listDestinos = await _service.GetAll();
            return Ok(listDestinos);

        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }


    [HttpGet]
    [Route("name")]
    public async Task<ActionResult<DestinoDto>> Get([FromQuery] string name)
    {
        try
        {

            var destino = await _service.GetDestinoByName(name);
            return Ok(destino);

        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<DestinoDto>> Get([FromRoute] int id)
    {
        try
        {

            var destino = await _service.GetDestinoById(id);
            return Ok(destino);

        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] DestinoDto destinoDto)
    {
        try
        {

            await _service.Update(id, destinoDto);
            return NoContent();

        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        try
        {
            await _service.Delete(id);
            return NoContent();
        }
        catch (ArgumentNullException)
        {
            return NotFound();
        }
    }

}
