using Microsoft.AspNetCore.Mvc;

namespace Desafio_Ilia_PARR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BatidasController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<BatidasController> _logger;

        public BatidasController(ILogger<BatidasController> logger)
        {
            _logger = logger;
        }

        
    }
}