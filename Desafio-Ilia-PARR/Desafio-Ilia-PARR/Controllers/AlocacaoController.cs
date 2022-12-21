using Desafio_Ilia_PARR.Model;
using Desafio_Ilia_PARR.Model.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Ilia_PARR.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AlocacaoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<AlocacaoController> _logger;
        private IAlocacaoService _alocacaoService;
        
        public AlocacaoController(ILogger<AlocacaoController> logger, IAlocacaoService alocacaoService)
        {
            _logger = logger;
            _alocacaoService = alocacaoService;
        }

        [HttpGet(Name = "alocacoes")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name ="alocacao")]
        public void Post([FromBody] Alocacao alocacao)
        {
            _alocacaoService.insereAlocacao(alocacao);
        }


    }
}