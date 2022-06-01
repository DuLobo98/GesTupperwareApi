using Gestupperware.Api.Dtos.Tupperwares;
using Gestupperware.Api.Models;

namespace Gestupperware.Api.Services
{
    public interface ITupperwareService
    {
        Task<List<ViewTupperwareDto>> GetAllAsync();
        Task<ViewTupperwareDto> GetByIdAsync(int id);
        Task AddAsync(Tupperware tupperware);
        Task<bool> UpdateAsync(Tupperware tupperware, int id);
        Task<bool> DeleteAsync(int id);
    }
}