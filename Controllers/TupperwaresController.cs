using AutoMapper;
using GestupperwareApi.Dtos.Tupperwares;
using GestupperwareApi.Models;
using GestupperwareApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestupperwareApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TupperwaresController : ControllerBase
    {
        private readonly ITupperwareService _tupperwareService;
        private readonly IMapper _mapper;

        public TupperwaresController(ITupperwareService tupperwareService, IMapper mapper)
        {
            _tupperwareService = tupperwareService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<ViewTupperwareDto>>> GetAllTupperwares()
        {
            var tupperwares = await _tupperwareService.GetAllAsync();
            return Ok(tupperwares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewTupperwareDto>> GetTupperware(int id)
        {
            var tupperware = await _tupperwareService.GetByIdAsync(id);
            if (tupperware == null)
            {
                return NotFound();
            }
            return Ok(tupperware);
        }

        [HttpPost()]
        public async Task<ActionResult> AddTupperware(AddTupperwareDto tupperware)
        {
            var mappedTupperware = _mapper.Map<Tupperware>(tupperware);
            await _tupperwareService.AddAsync(mappedTupperware);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTupperware(EditTupperwareDto tupperware, int id)
        {
            var mappedTupperware = _mapper.Map<Tupperware>(tupperware);
            await _tupperwareService.UpdateAsync(mappedTupperware, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTupperware(int id)
        {
            await _tupperwareService.DeleteAsync(id);
            return Ok();
        }
    }
}