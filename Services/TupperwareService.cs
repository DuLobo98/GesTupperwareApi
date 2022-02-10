using AutoMapper;
using GestupperwareApi.Data;
using GestupperwareApi.Dtos;
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

        public async Task<List<TupperwareDto>> GetAllAsync()
        {
            var tupperwares = await _context.Tupperwares.Include(c => c.Category).Include(s => s.Storage).ToListAsync();
            var mappedTupperwares = _mapper.Map<List<TupperwareDto>>(tupperwares);
            return mappedTupperwares;
        }

        public async Task<TupperwareDto> GetByIdAsync(int id)
        {
            var tupperwares = await _context.Tupperwares.Include(c => c.Category).Include(s => s.Storage).FirstOrDefaultAsync(i => i.Id == id);
            var mappedTupperwares = _mapper.Map<TupperwareDto>(tupperwares);
            return mappedTupperwares;
        }

        public Task UpdateAsync(Tupperware tupperware)
        {
            throw new NotImplementedException();
        }
    }
}