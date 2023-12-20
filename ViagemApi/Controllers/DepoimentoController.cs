using Microsoft.AspNetCore.Mvc;
using ViagemApi.Contracts;
using ViagemApi.Data.Dtos;
using ViagemApi.Model;

namespace ViagemApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class DepoimentoController : ControllerBase
    {

        private readonly IDepoimentoService _depoimentoService;

        public DepoimentoController(IDepoimentoService depoimentoService)
        {
            _depoimentoService = depoimentoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DepoimentoDto depoimento)
        {

           var result =  _depoimentoService.Share(depoimento);
            if (!result.IsCompletedSuccessfully) { throw new ApplicationException(); }
            return Ok(depoimento.Depoimento);
        }


    }
}
