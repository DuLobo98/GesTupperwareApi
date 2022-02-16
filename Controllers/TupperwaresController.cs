using AutoMapper;
using GestupperwareApi.Dtos.Tupperwares;
using GestupperwareApi.Models;
using GestupperwareApi.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet()]
        public async Task<ActionResult<List<ViewTupperwareDto>>> GetAllTupperwares()
        {
            var tupperwares = await _tupperwareService.GetAllAsync();
            return Ok(tupperwares);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewTupperwareDto>> GetTupperware(int id)
        {
            //Valitade if the given id exists
            var tupperware = await _tupperwareService.GetByIdAsync(id);
            if (tupperware == null)
            {
                return NotFound();
            }

            return Ok(tupperware);
        }

        [Authorize]
        [HttpPost()]
        public async Task<ActionResult> AddTupperware(AddTupperwareDto tupperware)
        {
            //Mapping AddTupperwareDto to Tupperware
            var mappedTupperware = _mapper.Map<Tupperware>(tupperware);

            await _tupperwareService.AddAsync(mappedTupperware);

            //Location to return
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/api/Tupperwares/" + mappedTupperware.Id;

            //Object to return
            var returnTupperware = await _tupperwareService.GetByIdAsync(mappedTupperware.Id);

            //Return a 201 code with location uri and a ViewTupperwareDto object
            return Created(locationUri, returnTupperware);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTupperware(EditTupperwareDto tupperware, int id)
        {
            //Mapping EditTupperwareDto to Tupperware
            var mappedTupperware = _mapper.Map<Tupperware>(tupperware);

            var updated = await _tupperwareService.UpdateAsync(mappedTupperware, id);

            //Validating if Tupperware was updated or not exists
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTupperware(int id)
        {
            var deleted = await _tupperwareService.DeleteAsync(id);

            //Validating if Tupperware was deleted or not exists
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}