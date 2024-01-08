using AutoMapper;
using ViagemApi.Data.Dtos;
using ViagemApi.Model;

namespace ViagemApi.Mappings
{
    public class Profiles : Profile
    {

        public Profiles()
        {
            CreateMap<DepoimentoDto, Depoimento>().ReverseMap();

            CreateMap<DestinoDto, Destino>().ReverseMap();
        }
    }
}
