using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peach_ActiviGo.Services.DTOs;
using Peach_ActiviGo.Services.Interface;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Peach_ActiviGo.Core.Models;

namespace Peach_ActiviGo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Tags("Admin")]
    public class ActivitySlotsController : ControllerBase
    {
        private readonly IActivitySlotService _service;
        private readonly IMapper _mapper;

        public ActivitySlotsController(IActivitySlotService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var slots = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ActivitySlotResponseDto>>(slots));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var slot = await _service.GetByIdAsync(id);

            if (slot == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ActivitySlotResponseDto>(slot));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActivitySlotRequestDto dto)
        {
            var entity = _mapper.Map<ActivitySlot>(dto);
            var created = await _service.CreateAsync(dto);
            return Ok(_mapper.Map<ActivitySlotResponseDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ActivitySlotRequestDto dto)
        {
            var entity = _mapper.Map<ActivitySlot>(dto);
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(_mapper.Map<ActivitySlotResponseDto>(updated));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok("Slot cancelled successfully.");
        }
    }
}
