using PPT.Domain.Entities;
namespace PPT.Domain.Interfaces
{
    public interface IJugadorRepository
    {
        Task<IEnumerable<Jugador>> ListarJugadores();
        Task<IEnumerable<JugadorBatalla>> ListarJugadoresBatallas();
        Task<int> CrearJugador(Jugador jugador);
        Task<bool> ExisteJugador(string nombre);
    }
}
