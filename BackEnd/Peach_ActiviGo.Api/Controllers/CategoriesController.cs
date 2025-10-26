using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs.CategoryDtos;
using Peach_ActiviGo.Services.Interface;

namespace Peach_ActiviGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service) => _service = service;

        // GET: /api/admin/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll(CancellationToken ct)
            => Ok(await _service.GetAllAsync(ct));

        // GET: /api/admin/categories/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> Get(int id, CancellationToken ct)
            => (await _service.GetByIdAsync(id, ct)) is { } dto ? Ok(dto) : NotFound();

        // POST: /api/admin/categories
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryCreateDto dto, CancellationToken ct)
        {
            try
            {
                var created = await _service.CreateAsync(dto, ct);
                return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex) // t.ex. namn-dublett
            {
                return Conflict(new { message = ex.Message });
            }
        }

        // PUT: /api/admin/categories/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDto>> Update(int id, [FromBody] CategoryUpdateDto dto, CancellationToken ct)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, dto, ct);
                return updated is null ? NotFound() : Ok(updated);
            }
            catch (InvalidOperationException ex) // t.ex. namn-dublett
            {
                return Conflict(new { message = ex.Message });
            }
        }

        // DELETE: /api/admin/categories/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            try
            {
                return await _service.DeleteAsync(id, ct) ? NoContent() : NotFound();
            }
            catch (InvalidOperationException ex) // t.ex. har kopplade aktiviteter
            {
                return Conflict(new { message = ex.Message });
            }
        }
    }
}
