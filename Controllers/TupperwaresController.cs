using AutoMapper;
using GestupperwareApi.Dtos;
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
        public async Task<ActionResult<List<TupperwareDto>>> GetAllTupperwares()
        {
            var tupperwares = await _tupperwareService.GetAllAsync();
            return Ok(tupperwares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TupperwareDto>> GetTupperware(int id)
        {
            var tupperware = await _tupperwareService.GetByIdAsync(id);
            if (tupperware == null)
            {
                return NotFound();
            }
            return Ok(tupperware);
        }



        [HttpPost()]
        public async Task<ActionResult> AddTupperware(EditTupperwareDto tuppeware)
        {
            var mappedTupperware = _mapper.Map<Tupperware>(tuppeware);
            await _tupperwareService.AddAsync(mappedTupperware);
            return Ok();
        }
    }
}