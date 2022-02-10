using AutoMapper;
using GestupperwareApi.Data;
using GestupperwareApi.Dtos.Tupperwares;
using GestupperwareApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestupperwareApi.Services
{
    public class TupperwareService : ITupperwareService
    {
        private readonly GestupperwareContext _context;
        private readonly IMapper _mapper;

        public TupperwareService(GestupperwareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(Tupperware tupperware)
        {
            _context.Tupperwares.Add(tupperware);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ViewTupperwareDto>> GetAllAsync()
        {
            var tupperwares = await _context.Tupperwares.Include(c => c.Category).Include(s => s.Storage).ToListAsync();
            var mappedTupperwares = _mapper.Map<List<ViewTupperwareDto>>(tupperwares);
            return mappedTupperwares;
        }

        public async Task<ViewTupperwareDto> GetByIdAsync(int id)
        {
            var tupperwares = await _context.Tupperwares.Include(c => c.Category).Include(s => s.Storage).FirstOrDefaultAsync(i => i.Id == id);
            var mappedTupperwares = _mapper.Map<ViewTupperwareDto>(tupperwares);
            return mappedTupperwares;
        }

        public async Task UpdateAsync(Tupperware tupperware, int id)
        {
            bool hasAny = await _context.Tupperwares.AnyAsync(t => t.Id == id);

            if (hasAny)
            {
                tupperware.Id = id;
                _context.Update(tupperware);
                await _context.SaveChangesAsync();
            }
        }
    }
}