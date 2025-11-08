using Microsoft.AspNetCore.Mvc;
using NoisEmap.Application.Interfaces;
using NoisEmap.Application.Services;
using NoisEmap.Application.DTOs; // <-- Corrigido (antes estava "Dtos")
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Api.Controllers // <-- Corrigido (antes estava "NoisEmap.API")
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapProjectsController : ControllerBase
    {
        private readonly IMapService _mapService;

        public MapProjectsController(IMapService mapService)
        {
            _mapService = mapService;
        }

        // GET: api/MapProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapDto>>> GetAll()
        {
            var projects = await _mapService.GetAllAsync();
            return Ok(projects);
        }

        // GET: api/MapProjects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MapDto>> Get(int id)
        {
            var project = await _mapService.GetByIdAsync(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        // POST: api/MapProjects
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMapDto dto)
        {
            await _mapService.AddAsync(dto);
            return StatusCode(201);
        }

        // PUT: api/MapProjects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateMapDto dto)
        {
            await _mapService.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE: api/MapProjects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mapService.DeleteAsync(id);
            return NoContent();
        }
    }
}
