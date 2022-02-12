using GestupperwareApi.Dtos.Storages;
using GestupperwareApi.Models;

namespace GestupperwareApi.Services
{
    public interface IStorageService
    {
        Task<List<ViewStorageDto>> GetAllAsync();
        Task<ViewStorageDto> GetByIdAsync(int id);
        Task AddAsync(Storage storage);
        Task<bool> UpdateAsync(Storage storage, int id);
        Task<bool> DeleteAsync(int id);
    }
}