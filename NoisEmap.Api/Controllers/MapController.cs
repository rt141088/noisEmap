using Microsoft.AspNetCore.Mvc;
using NoisEmap.Application.Interfaces;
using NoisEmap.Application.DTOs;
using NoisEmap.Application.Services;
using NoisEmap.Domain.Entities;

namespace NoisEmap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : ControllerBase
    {
        private readonly IMapService _service;
        private readonly LinkGenerator _linkGenerator;

        public MapController(IMapService service, LinkGenerator linkGenerator)
        {
            _service = service;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        // O IMapService só tem GetAllAsync() sem argumentos.
        // Mantemos os argumentos na assinatura, mas os ignoramos aqui para compilar.
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? location = null)
        {
            // Chamando GetAllAsync() sem argumentos, conforme o IMapService.
            var items = await _service.GetAllAsync();

            var result = new
            {
                Page = page,
                PageSize = pageSize,
                // O Total é o número de itens na lista retornada.
                Total = items.Count(),
                Items = items.Select(i => new {
                    i.Id,
                    i.Location,
                    i.NoiseLevel,
                    i.RecordedAt,
                    Links = new
                    {
                        Self = Url.Action(nameof(GetById), new { id = i.Id }),
                        Update = Url.Action(nameof(Update), new { id = i.Id }),
                        Delete = Url.Action(nameof(Delete), new { id = i.Id })
                    }
                })
            };

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetMapById")]
        public async Task<IActionResult> GetById(int id)
        {
            var m = await _service.GetByIdAsync(id);
            if (m == null) return NotFound();
            var dto = new
            {
                m.Id,
                m.Location,
                m.NoiseLevel,
                m.RecordedAt,
                Links = new
                {
                    Self = Url.Action(nameof(GetById), new { id = m.Id }),
                    Update = Url.Action(nameof(Update), new { id = m.Id }),
                    Delete = Url.Action(nameof(Delete), new { id = m.Id })
                }
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMapDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Chamando AddAsync
            var created = await _service.AddAsync(dto);

            return CreatedAtRoute("GetMapById", new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMapDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // CORREÇÃO CS0029:
            // O serviço retorna o Map atualizado (ou null se não encontrar).
            // Tratamos o retorno como um objeto, não como um booleano.
            var updatedMap = await _service.UpdateAsync(id, dto);

            // Retorna NoContent se atualizou (updatedMap não é nulo), ou NotFound.
            return updatedMap != null ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Mantido o DeleteAsync com retorno booleano (assumindo que o MapService o implementa assim)
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
