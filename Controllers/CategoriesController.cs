using InventoryManagement.Api.Dtos.Categories;
using InventoryManagement.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // POST: api/categories
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            var category = await _categoryService.CreateAsync(dto);
            return Ok(category);
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryCreateDto dto)
        {
            var updated = await _categoryService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _categoryService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
