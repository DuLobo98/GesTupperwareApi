using AutoMapper;
using Gestupperware.Api.Data;
using Gestupperware.Api.Dtos.Tupperwares;
using Gestupperware.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestupperware.Api.Services
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

        public async Task<bool> DeleteAsync(int id)
        {
            var tupperware = await _context.Tupperwares.FindAsync(id);

            if (tupperware == null)
            {
                return false;
            }
            _context.Tupperwares.Remove(tupperware);
            await _context.SaveChangesAsync();
            return true;
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

        public async Task<bool> UpdateAsync(Tupperware tupperware, int id)
        {
            bool hasAny = await _context.Tupperwares.AnyAsync(t => t.Id == id);

            if (!hasAny)
            {
                return false;
            }
            tupperware.Id = id;
            _context.Update(tupperware);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}