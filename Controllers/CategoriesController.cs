using AutoMapper;
using Gestupperware.Api.Dtos.Categories;
using Gestupperware.Api.Models;
using Gestupperware.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gestupperware.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        //[Authorize]
        [HttpGet()]
        public async Task<ActionResult<List<ViewCategoryDto>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewCategoryDto>> GetCategory(int id)
        {
            //Valitade if the given id exists
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        //[Authorize]
        [HttpPost()]
        public async Task<ActionResult> AddCategory(EditCategoryDto category)
        {
            //Mapping EditCategoryDto to Category
            var mappedCategory = _mapper.Map<Category>(category);

            await _categoryService.AddAsync(mappedCategory);

            //Location to return
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/api/Categories/" + mappedCategory.Id;

            //Object to return
            var returnCategory = await _categoryService.GetByIdAsync(mappedCategory.Id);

            //Return a 201 code with location uri and a CategoryDto object
            return Created(locationUri, returnCategory);
        }

        //[Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(EditCategoryDto category, int id)
        {
            //Mapping EditCategoryDto to Category
            var mappedCategory = _mapper.Map<Category>(category);

            var updated = await _categoryService.UpdateAsync(mappedCategory, id);

            //Validating if Category was updated or not exists
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var deleted = await _categoryService.DeleteAsync(id);

            //Validating if Category was deleted or not exists
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}