using System.ComponentModel.DataAnnotations;

namespace PPT.Domain.Entities
{
    public class Jugador
    {
        public int JugadorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
