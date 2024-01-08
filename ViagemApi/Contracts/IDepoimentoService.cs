using Microsoft.EntityFrameworkCore.Diagnostics;
using ViagemApi.Data.Dtos;
using ViagemApi.ViewModels;

namespace ViagemApi.Contracts;

public interface IDepoimentoService
{
    Task Share(ViewCreateDepoimento depoimento);

    Task<IEnumerable<DepoimentoDto>> GetAll(int skip, int take);

   Task<DepoimentoDto> GetById(int id);

    Task<IEnumerable<DepoimentoDto>> LastThree();
    Task Delete(int id);
}
