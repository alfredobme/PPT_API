using PPT.Application.DTO;

namespace PPT.Application.Interfaces
{
    public interface IBatallaService
    {
        Task<int> CrearBatallaAsync(BatallaCreateDTO batallaCreateDTO);
    }
}
