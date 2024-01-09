using ViagemApi.Data.Dtos;
using ViagemApi.Model;
using ViagemApi.ViewModels;

namespace ViagemApi.Contracts
{
    public interface IDestinoService
    {
        public Task CreateDestino(ViewCreateDestino destinoCreate);

        public Task<IEnumerable<ResumoDestinoDto>> GetAll();

        public Task<DestinoDto> GetDestinoByName(string name);

        public Task<DestinoDto> GetDestinoById(int id);

        public Task Delete(int id);

        public Task Update(int id, DestinoDto dto);

    }
}
