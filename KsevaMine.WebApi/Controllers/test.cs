using Microsoft.AspNetCore.Mvc;

namespace KsevaMine.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new { message = "API работает!", time = DateTime.Now });
        }

        [HttpGet("hello/{name}")]
        public IActionResult SayHelloToUser(string name)
        {
            return Ok(new { message = $"Привет, {name}! Лаунчер готов к работе!" });
        }
    }
}