using AutoMapper;
using GestupperwareApi.Dtos.Storages;
using GestupperwareApi.Models;
using GestupperwareApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestupperwareApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoragesController : ControllerBase
    {
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public StoragesController(IStorageService storageService, IMapper mapper)
        {
            _storageService = storageService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet()]
        public async Task<ActionResult<List<ViewStorageDto>>> GetAllStorages()
        {
            var storages = await _storageService.GetAllAsync();
            return Ok(storages);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewStorageDto>> GetStorage(int id)
        {
            //Valitade if the given id exists
            var storage = await _storageService.GetByIdAsync(id);
            if (storage == null)
            {
                return NotFound();
            }

            return Ok(storage);
        }

        [Authorize]
        [HttpPost()]
        public async Task<ActionResult> AddStorage(EditStorageDto storage)
        {
            //Mapping EditStorageDto to Storage
            var mappedStorage = _mapper.Map<Storage>(storage);

            await _storageService.AddAsync(mappedStorage);

            //Location to return
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/api/storages/" + mappedStorage.Id;

            //Object to return
            var returnStorage = await _storageService.GetByIdAsync(mappedStorage.Id);

            //Return a 201 code with location uri and a CategoryDto object
            return Created(locationUri, returnStorage);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStorage(EditStorageDto storage, int id)
        {
            //Mapping EditStorageDto to Storage
            var mappedStorage = _mapper.Map<Storage>(storage);

            var updated = await _storageService.UpdateAsync(mappedStorage, id);

            //Validating if Storage was updated or not exists
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStorage(int id)
        {
            var deleted = await _storageService.DeleteAsync(id);

            //Validating if Storage was deleted or not exists
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}