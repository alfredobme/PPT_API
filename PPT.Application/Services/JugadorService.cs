using AutoMapper;
using PPT.Application.DTO;
using PPT.Application.Interfaces;
using PPT.Domain.Entities;
using PPT.Domain.Interfaces;

namespace PPT.Application.Services
{
    public class JugadorService(IMapper mapper, IJugadorRepository jugadorRepository) : IJugadorService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IJugadorRepository _jugadorRepository = jugadorRepository;
        public async Task<IEnumerable<JugadorDTO>> ListarJugadoresAsync()
        {
            var jugadores = await _jugadorRepository.ListarJugadores();

            return _mapper.Map<IEnumerable<JugadorDTO>>(jugadores);
        }
        public async Task<IEnumerable<JugadorBatallaDTO>> ListarJugadoresBatallasAsync()
        {
            var jugadores = await _jugadorRepository.ListarJugadoresBatallas();

            return _mapper.Map<IEnumerable<JugadorBatallaDTO>>(jugadores);
        }
        public async Task<int> CrearJugadorAsync(JugadorCreateDTO jugadorCreateDTO)
        {
            var jugador = _mapper.Map<Jugador>(jugadorCreateDTO);

            return await _jugadorRepository.CrearJugador(jugador);
        }
        public async Task<bool> ExisteJugadorAsync(string nombre)
        {
            return await _jugadorRepository.ExisteJugador(nombre);
        }
    }
}
