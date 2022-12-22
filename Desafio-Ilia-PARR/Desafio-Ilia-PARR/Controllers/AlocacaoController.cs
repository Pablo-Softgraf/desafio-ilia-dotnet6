using Desafio_Ilia_PARR.Data.ValueObjects;
using Desafio_Ilia_PARR.Model;
using Desafio_Ilia_PARR.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Desafio_Ilia_PARR.Controllers
{
    [ApiController]
    [Route("v1/[controller]/alocacoes")]
    public class AlocacaoController : ControllerBase
    {
        private IAlocacaoRepository _repository;

        public AlocacaoController(IAlocacaoRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<ActionResult<AlocacaoVO>> Create(AlocacaoVO alocacaoVO)
        {
            List<AlocacaoVO> _alocado = await _repository.ListAll(alocacaoVO);

            if (_alocado.Count > 0)
            {
                Mensagem _msg = new Mensagem();
                _msg.mensagem = "N�o pode alocar tempo maior que o tempo trabalhado no dia";
                return BadRequest(_msg);
            }
            if (!IsDateTime(alocacaoVO.dia))
            {
                Mensagem _msg = new Mensagem();
                _msg.mensagem = "Campo Dia com formato incorreto";
                return BadRequest(_msg);
            }

            if (alocacaoVO == null) return BadRequest();
            var alocacao = await _repository.Create(alocacaoVO);
            return Created("", alocacao); 
        }

        public static bool IsDateTime(string tempDate)
        {
            DateTime fromDateValue;
            var format = "dd/MM/yyyy";
            return DateTime.TryParseExact(tempDate, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue);
        }
    }
}