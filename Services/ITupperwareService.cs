using GestupperwareApi.Models;

namespace GestupperwareApi.Services
{
    public interface ITupperwareService
    {
        Task<List<Tupperware>> GetAllAsync();
        Task<Tupperware> GetByIdAsync(int id);
        Task AddAsync(Tupperware tupperware);
        Task UpdateAsync(Tupperware tupperware);
        Task DeleteAsync(int id);
    }
}