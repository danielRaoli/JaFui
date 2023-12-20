using ViagemApi.Contracts;
using ViagemApi.Data;
using ViagemApi.Data.Dtos;
using ViagemApi.Model;

namespace ViagemApi.Services
{
    public class DepoimentoService : IDepoimentoService
    {
        private readonly ApiContext _context;

        public DepoimentoService(ApiContext context)
        {
            _context = context;
        }


        public async Task Share(DepoimentoDto depoimento)
        {
            string path = Path.Combine("Storage", depoimento.Foto.FileName);

            using Stream file = new FileStream(path, FileMode.Create);

            depoimento.Foto.CopyTo(file);

            _context.Depoimentos.Add(new Depoimento(depoimento.Name, depoimento.Depoimento, path));
             await _context.SaveChangesAsync();  
            
        }


        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<DepoimentoDto>> GetAll(int skip = 0, int take = 10)
        {
            throw new NotImplementedException();
        }

        public Task<DepoimentoDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
