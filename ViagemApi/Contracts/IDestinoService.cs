using ViagemApi.Data.Dtos;
using ViagemApi.Model;
using ViagemApi.ViewModels;

namespace ViagemApi.Contracts
{
    public interface IDestinoService
    {
        public  Task CreateDestino(Destino destino);

        public Task<IEnumerable<DestinoDto>> GetDestinos();

        public Task<DestinoDto> GetDestino(string name);

        public Task Delete(int id);

        public Task Update(int id, DestinoDto dto);

    }
}
