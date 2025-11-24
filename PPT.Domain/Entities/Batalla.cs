using System.ComponentModel.DataAnnotations;

namespace PPT.Domain.Entities
{
    public class Batalla
    {
        public int BatallaId { get; set; }

        [Required]
        public int Jugador1Id { get; set; }

        [Required]
        public int Jugador2Id { get; set; }

        public int? GanadorId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        public Jugador? Jugador1 { get; set; }
        public Jugador? Jugador2 { get; set; }
        public Jugador? Ganador { get; set; }
    }
}
