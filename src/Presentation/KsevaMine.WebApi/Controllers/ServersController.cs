using KsevaMine.Application.Interfaces;
using KsevaMine.Application.Servers.Queries.GetServerInfo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KsevaMine.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IApplicationDbContext _db; // <-- добавляем поле

        public ServersController(IMediator mediator, IApplicationDbContext db)
        {
            _mediator = mediator;
            _db = db; // сохраняем контекст
        }

        [HttpGet("debug")]
        public async Task<IActionResult> Debug()
        {
            var servers = await _db.Servers
                .Include(s => s.Build)
                .Include(s => s.BuildVersion)
                .ToListAsync();

            var result = servers.Select(s => new {
                s.Name,
                BuildName = s.Build?.Name,
                BuildVersion = s.Build?.MinecraftVersion,
                s.BuildId
            });

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetServer(
            [FromQuery] string name,
            [FromQuery] string version)
        {
            var query = new GetServerInfoQuery 
            { 
                Name = name, 
                Version = version 
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound(new
                {
                    error = "server_not_found",
                    message = $"Сервер {name} версии {version} не найден"
                });
            }
            return Ok(result);
        }
    }
}
