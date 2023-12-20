using AutoMapper;
using ViagemApi.Data.Dtos;

namespace ViagemApi.Mappings
{
    public class Profiles : Profile
    {

        public Profiles()
        {
            CreateMap<DepoimentoDto, DepoimentoDto>();

        }
    }
}
