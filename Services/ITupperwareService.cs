using GestupperwareApi.Dtos.Tupperwares;
using GestupperwareApi.Models;

namespace GestupperwareApi.Services
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