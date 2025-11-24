using AutoMapper;
using PPT.Application.DTO;
using PPT.Application.Interfaces;
using PPT.Domain.Entities;
using PPT.Domain.Interfaces;

namespace PPT.Application.Services
{
    public class BatallaService(IMapper mapper, IBatallaRepository batallaRepository) : IBatallaService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBatallaRepository _batallaRepository = batallaRepository;
        public async Task<int> CrearBatallaAsync(BatallaCreateDTO batallaCreateDTO)
        {
            var batalla = _mapper.Map<Batalla>(batallaCreateDTO);

            return await _batallaRepository.CrearBatalla(batalla);
        }
    }
}
