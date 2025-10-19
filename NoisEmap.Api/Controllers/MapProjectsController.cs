using Microsoft.AspNetCore.Mvc;
using NoisEmap.Application.Interfaces; // <-- ESTE É O USING CRUCIAL
using NoisEmap.Domain.Entities;
using NoisEmap.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapProjectsController : ControllerBase
    {
        private readonly IMapService _mapService; // Agora, IMapService será reconhecido

        public MapProjectsController(IMapService mapService)
        {
            _mapService = mapService;
        }

        // Endpoint GET /api/MapProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapDto>>> GetAll()
        {
            var projects = await _mapService.GetAllAsync();
            return Ok(projects);
        }

        // Endpoint GET /api/MapProjects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MapDto>> Get(int id)
        {
            var project = await _mapService.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        // Endpoint POST /api/MapProjects
        [HttpPost]
        public async Task<ActionResult<MapDto>> Post([FromBody] CreateMapDto dto)
        {
            await _mapService.AddAsync(dto);

            // Retorna status 201 Created.
            return StatusCode(201);
        }

        // Endpoint PUT /api/MapProjects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateMapDto dto)
        {
            await _mapService.UpdateAsync(id, dto);
            return NoContent();
        }

        // Endpoint DELETE /api/MapProjects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mapService.DeleteAsync(id);
            return NoContent();
        }
    }
}