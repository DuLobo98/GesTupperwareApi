using GestupperwareApi.Dtos.Categories;
using GestupperwareApi.Models;

namespace GestupperwareApi.Services
{
    public interface ICategoryService
    {
        Task<List<ViewCategoryDto>> GetAllAsync();
        Task<ViewCategoryDto> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task<bool> UpdateAsync(Category category, int id);
        Task<bool> DeleteAsync(int id);

    }
}