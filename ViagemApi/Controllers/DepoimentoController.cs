using Microsoft.AspNetCore.Mvc;
using ViagemApi.Contracts;
using ViagemApi.Data.Dtos;
using ViagemApi.ViewModels;

namespace ViagemApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepoimentoController : ControllerBase
{

    private readonly IDepoimentoService _depoimentoService;

    public DepoimentoController(IDepoimentoService depoimentoService)
    {
        _depoimentoService = depoimentoService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] ViewCreateDepoimento viewCreate)
    {

        await _depoimentoService.Share(viewCreate);

        return Ok(viewCreate.Depoimento);
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepoimentoDto>>> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var depoimentos = await _depoimentoService.GetAll(skip, take);

        return Ok(depoimentos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepoimentoDto>> GetOne([FromRoute] int id)
    {
        try
        {
            var depoimento = await _depoimentoService.GetById(id);



            return Ok(depoimento);
        }
        catch (ApplicationException ex)
        {
            return NotFound(ex.Message);
        }

    }


    [HttpGet]
    [Route("Recentes")]
    public async Task<ActionResult<List<DepoimentoDto>>> Recentes()
    {
        try
        {
            var recentes = await _depoimentoService.LastThree();


            return Ok(recentes);
        }
        catch (ApplicationException ex)
        {
            return Ok(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {

        await _depoimentoService.Delete(id);
        return NoContent();

    }

}
