using Microsoft.EntityFrameworkCore;
using PPT.Domain.Entities;
using PPT.Domain.Interfaces;

namespace PPT.Infrastructure.Data.Repositories
{
    public class JugadorRepository(ApplicationDbContext dbContext) : IJugadorRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Jugador>> ListarJugadores()
        {
            return await _dbContext.Jugadores.ToListAsync();
        }

        public async Task<IEnumerable<JugadorBatalla>> ListarJugadoresBatallas()
        {
            var jugadores = await _dbContext.Jugadores
                .Select(j => new JugadorBatalla
                {
                    JugadorId = j.JugadorId,
                    Nombre = j.Nombre,

                    // Ganadas
                    Ganadas = _dbContext.Batallas
                        .Count(b => b.GanadorId == j.JugadorId),

                    // Perdidas
                    Perdidas = _dbContext.Batallas
                        .Count(b =>
                            (b.Jugador1Id == j.JugadorId || b.Jugador2Id == j.JugadorId)
                            && b.GanadorId != null
                            && b.GanadorId != j.JugadorId
                        ),

                    // Empatadas
                    Empatadas = _dbContext.Batallas
                        .Count(b =>
                            (b.Jugador1Id == j.JugadorId || b.Jugador2Id == j.JugadorId)
                            && b.GanadorId == null
                        )
                })
                .ToListAsync();

            return jugadores;
        }

        public async Task<int> CrearJugador(Jugador jugador)
        {
            _dbContext.Jugadores.Add(jugador);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExisteJugador(string nombre)
        {
            nombre = nombre.Trim().ToLower();

            return await _dbContext.Jugadores.AnyAsync(j => j.Nombre == nombre);
        }
    }
}
