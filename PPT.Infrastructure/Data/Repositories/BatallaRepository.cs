using PPT.Domain.Entities;
using PPT.Domain.Interfaces;

namespace PPT.Infrastructure.Data.Repositories
{
    public class BatallaRepository(ApplicationDbContext dbContext) : IBatallaRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        public async Task<int> CrearBatalla(Batalla batalla)
        {
            _dbContext.Batallas.Add(batalla);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
