// NoisEmap.Api/Controllers/MapProjectsController.cs
using Microsoft.AspNetCore.Mvc;
using NoisEmap.Application.Services;
using NoisEmap.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoisEmap.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapProjectsController : ControllerBase
    {
        private readonly MapService _mapService;

        public MapProjectsController(MapService mapService)
        {
            _mapService = mapService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapProjects>>> GetAllMapProjects()
        {
            var mapProjects = await _mapService.GetAllMapProjectsAsync();
            return Ok(mapProjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MapProjects>> GetMapProjectById(int id)
        {
            var mapProject = await _mapService.GetMapProjectByIdAsync(id);
            if (mapProject == null)
                return NotFound();

            return Ok(mapProject);
        }

        [HttpPost]
        public async Task<ActionResult> AddMapProject(MapProjects mapProject)
        {
            await _mapService.AddMapProjectAsync(mapProject);
            return CreatedAtAction(nameof(GetMapProjectById), new { id = mapProject.Id }, mapProject);
        }
    }
}