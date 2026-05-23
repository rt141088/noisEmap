using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using NoisEmap.Application.Services;
using NoisEmap.Domain.Entities;
using System.Linq;

namespace NoisEmap.Api.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly SensorService _service;

        public TestController(SensorService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("MINHA_CHAVE_SUPER_SECRETA_12345678");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "admin")
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get(int page = 1, int size = 10)
        {
            var sensores = _service.GetAll(page, size).ToList();

            var itens = sensores.Select(s => new
            {
                data = s,
                _links = new
                {
                    self = $"/api/test/{s.Id}",
                    update = $"/api/test/{s.Id}",
                    delete = $"/api/test/{s.Id}"
                }
            });

            var response = new
            {
                page,
                size,
                total = sensores.Count,
                items = itens,
                _links = new
                {
                    self = $"/api/test?page={page}&size={size}",
                    next = $"/api/test?page={page + 1}&size={size}",
                    prev = page > 1 ? $"/api/test?page={page - 1}&size={size}" : null
                }
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sensor = _service.GetById(id);
            if (sensor == null) return NotFound();
            return Ok(new
            {
                data = sensor,
                _links = new
                {
                    self = $"/api/test/{sensor.Id}",
                    update = $"/api/test/{sensor.Id}",
                    delete = $"/api/test/{sensor.Id}"
                }
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sensor sensor)
        {
            try
            {
                _service.Add(sensor);
                return CreatedAtAction(nameof(GetById), new { id = sensor.Id }, sensor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Sensor sensorAtualizado)
        {
            var sensor = _service.GetById(id);
            if (sensor == null) return NotFound();
            sensor.Temperatura = sensorAtualizado.Temperatura;
            sensor.Umidade = sensorAtualizado.Umidade;
            _service.Update(sensor);
            return Ok(new
            {
                data = sensor,
                _links = new
                {
                    self = $"/api/test/{sensor.Id}",
                    update = $"/api/test/{sensor.Id}",
                    delete = $"/api/test/{sensor.Id}"
                }
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sensor = _service.GetById(id);
            if (sensor == null) return NotFound();
            _service.Delete(id);
            return NoContent();
        }
    }
}