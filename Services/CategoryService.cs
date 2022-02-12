using AutoMapper;
using GestupperwareApi.Data;
using GestupperwareApi.Dtos.Categories;
using GestupperwareApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestupperwareApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly GestupperwareContext _context;
        private readonly IMapper _mapper;

        public CategoryService(GestupperwareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ViewCategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var mappedCategories = _mapper.Map<List<ViewCategoryDto>>(categories);
            return mappedCategories;
        }

        public async Task<ViewCategoryDto> GetByIdAsync(int id)
        {
            var categories = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            var mappedCategories = _mapper.Map<ViewCategoryDto>(categories);
            return mappedCategories;
        }

        public async Task<bool> UpdateAsync(Category category, int id)
        {
            bool hasAny = await _context.Categories.AnyAsync(c => c.Id == id);

            if (!hasAny)
            {
                return false;
            }
            category.Id = id;
            _context.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}