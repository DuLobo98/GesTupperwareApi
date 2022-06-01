using Gestupperware.Api.Dtos.Storages;
using Gestupperware.Api.Models;

namespace Gestupperware.Api.Services
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