using PPT.Domain.Entities;

namespace PPT.Domain.Interfaces
{
    public interface IBatallaRepository
    {
        Task<int> CrearBatalla(Batalla batalla);
    }
}
