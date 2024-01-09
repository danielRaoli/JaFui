using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ViagemApi.Contracts;
using ViagemApi.Data;
using ViagemApi.Data.Dtos;
using ViagemApi.Model;
using ViagemApi.ViewModels;

namespace ViagemApi.Services
{
    public class DestinoService : IDestinoService
    {

        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public DestinoService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateDestino(ViewCreateDestino createDestino)
        {
            string fotoPerfil = FotosService.GerarCaminho(createDestino.FotoPerfil);
            string fotoDetalhes = FotosService.GerarCaminho(createDestino.FotoDetalhes);

            string descricao = createDestino.Descricao ?? await GeradorDeDescricao.GerarDescricao(createDestino.Name);

            Destino destino = new()
            {
                Name = createDestino.Name,
                FotoPerfil = fotoPerfil,
                FotoDetalhes = fotoDetalhes,
                Descricao = descricao,
                Meta = createDestino.Meta
            };

            _context.Add(destino);
            await _context.SaveChangesAsync();
        }


        public async Task Delete(int id)
        {
            var destinoDb = _context.Destinos.FirstOrDefault(d => d.Id == id);
            if (destinoDb == null)
            {
                throw new ArgumentNullException("Destino not found");

            }

            _context.Destinos.Remove(destinoDb);
            await _context.SaveChangesAsync();

        }

        public async Task<DestinoDto> GetDestinoByName(string name)
        {
            var destinoDb = await _context.Destinos.FirstOrDefaultAsync(d => d.Name.ToLower() == name.ToLower());

            if (destinoDb == null)
            {
                throw new ArgumentNullException("Destino not found");
            }

            var destinoDto = _mapper.Map<DestinoDto>(destinoDb);

            return destinoDto;
        }

        public async Task<DestinoDto> GetDestinoById(int id)
        {

            var destinoDB = _context.Destinos.FirstOrDefault(d => d.Id == id) ?? throw new ArgumentNullException(" Id Not Found");

            var destinoDto = _mapper.Map<DestinoDto>(destinoDB);
            return destinoDto;

        }

        public async Task<IEnumerable<ResumoDestinoDto>> GetAll()
        {
            var listDestinos = await _context.Destinos.ToListAsync();

            if (!listDestinos.Any())
            {
                throw new ArgumentNullException("The list is empty");
            }

            var listDestinosDto = _mapper.Map<List<ResumoDestinoDto>>(listDestinos);

            return listDestinosDto;
        }

        public async Task Update(int id, DestinoDto dto)
        {
            var destinoDb = await _context.Destinos.FirstOrDefaultAsync(d => d.Id == id);

            if (destinoDb == null)
            {
                throw new ArgumentNullException("Destino not found");

            }

            _mapper.Map(dto, destinoDb);
            await _context.SaveChangesAsync();



        }
    }
}
