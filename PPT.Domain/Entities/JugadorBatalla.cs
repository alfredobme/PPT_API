namespace PPT.Domain.Entities
{
    public class JugadorBatalla
    {
        public int JugadorId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Ganadas { get; set; }
        public int Perdidas { get; set; }
        public int Empatadas { get; set; }
    }
}
