using GestupperwareApi.Dtos;
using GestupperwareApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestupperwareApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TupperwaresController : ControllerBase
    {
        private readonly ITupperwareService _tupperwareService;

        public TupperwaresController(ITupperwareService tupperwareService)
        {
            _tupperwareService = tupperwareService;
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
    }
}