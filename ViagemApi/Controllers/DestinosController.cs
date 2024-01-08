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

        var path = Path.Combine("Storage", createDestino.Foto.FileName);

        using Stream file = new FileStream(path, FileMode.Create);

        createDestino.Foto.CopyTo(file);

        Destino destino = new() { Name = createDestino.Name, Price = createDestino.Price, Foto = path };

        await _service.CreateDestino(destino);

        return Ok(destino);

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DestinoDto>>> GetAll()
    {
        try
        {

            var listDestinos = await _service.GetDestinos();
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

            var destino = await _service.GetDestino(name);
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
