using Microsoft.EntityFrameworkCore;
using PPT.Domain.Entities;

namespace PPT.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Jugador> Jugadores { get; set; }

        public DbSet<Batalla> Batallas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Batalla>(entity =>
            {
                // Relación Jugador1
                entity.HasOne(b => b.Jugador1)
                    .WithMany()
                    .HasForeignKey(b => b.Jugador1Id)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación Jugador2
                entity.HasOne(b => b.Jugador2)
                    .WithMany()
                    .HasForeignKey(b => b.Jugador2Id)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación Ganador (Nulo es empate)
                entity.HasOne(b => b.Ganador)
                    .WithMany()
                    .HasForeignKey(b => b.GanadorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
