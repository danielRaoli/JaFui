using Microsoft.EntityFrameworkCore.Diagnostics;
using ViagemApi.Data.Dtos;

namespace ViagemApi.Contracts;

public interface IDepoimentoService
{
    Task Share(DepoimentoDto depoimento);

    Task<IEnumerable<DepoimentoDto>> GetAll(int skip = 0, int take = 10);

    Task<DepoimentoDto> GetByName(string name);

    Task Delete(int id);
}
