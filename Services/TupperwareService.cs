using GestupperwareApi.Data;
using GestupperwareApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestupperwareApi.Services
{
    public class TupperwareService : ITupperwareService
    {
        private readonly GestupperwareContext _context;

        public TupperwareService(GestupperwareContext context)
        {
            _context = context;
        }

        public Task AddAsync(Tupperware tupperware)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tupperware>> GetAllAsync()
        {
            return await _context.Tupperwares.ToListAsync();
        }

        public Task<Tupperware> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Tupperware tupperware)
        {
            throw new NotImplementedException();
        }
    }
}