using PPT.Application.DTO;

namespace PPT.Application.Interfaces
{
    public interface IJugadorService
    {
        Task<IEnumerable<JugadorDTO>> ListarJugadoresAsync();
        Task<IEnumerable<JugadorBatallaDTO>> ListarJugadoresBatallasAsync();
        Task<int> CrearJugadorAsync(JugadorCreateDTO jugadorCreateDTO);
        Task<bool> ExisteJugadorAsync(string nombre);
    }
}
