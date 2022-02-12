using AutoMapper;
using GestupperwareApi.Data;
using GestupperwareApi.Dtos.Storages;
using GestupperwareApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestupperwareApi.Services
{
    public class StorageService : IStorageService
    {
        private readonly GestupperwareContext _context;
        private readonly IMapper _mapper;

        public StorageService(GestupperwareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(Storage storage)
        {
            _context.Storages.Add(storage);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var storage = await _context.Storages.FindAsync(id);

            if (storage == null)
            {
                return false;
            }
            _context.Storages.Remove(storage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ViewStorageDto>> GetAllAsync()
        {
            var storages = await _context.Storages.ToListAsync();
            var mappedStorages = _mapper.Map<List<ViewStorageDto>>(storages);
            return mappedStorages;
        }

        public async Task<ViewStorageDto> GetByIdAsync(int id)
        {
            var storage = await _context.Storages.FirstOrDefaultAsync(s => s.Id == id);
            var mappedStorages = _mapper.Map<ViewStorageDto>(storage);
            return mappedStorages;
        }

        public async Task<bool> UpdateAsync(Storage storage, int id)
        {
            bool hasAny = await _context.Storages.AnyAsync(s => s.Id == id);

            if (!hasAny)
            {
                return false;
            }
            storage.Id = id;
            _context.Storages.Update(storage);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}