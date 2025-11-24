using AutoMapper;
using PPT.Application.DTO;
using PPT.Domain.Entities;

namespace PPT.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Jugador, JugadorDTO>().ReverseMap();
            CreateMap<JugadorBatalla, JugadorBatallaDTO>().ReverseMap();
            CreateMap<JugadorCreateDTO, Jugador>().ReverseMap();

            CreateMap<BatallaCreateDTO, Batalla>().ReverseMap();
        }
    }
}
