using Desafio_Ilia_PARR.Data.ValueObjects;
using Desafio_Ilia_PARR.Model;
using Desafio_Ilia_PARR.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Desafio_Ilia_PARR.Controllers
{
    [ApiController]
    [Route("v1/alocacoes")]
    public class AlocacaoController : ControllerBase
    {
        private int horas;
        private int minutos;
        private int segundos;

        private IAlocacaoRepository _repository;
        private IMomentoRepository _momentoRepository;

        public AlocacaoController(IAlocacaoRepository repository, IMomentoRepository momentoRepository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
            _momentoRepository = momentoRepository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task<ActionResult<AlocacaoVO>> insereAlocacao(AlocacaoVO alocacaoVO)
        {
            int _horaAloc = 0;
            int _minutoAloc = 0;
            int _segundoAloc = 0;
            decimal totalAlocado = 0;
            decimal totalTrabalhado = 0;

            if (!IsDateTime(alocacaoVO.dia))
            {
                Mensagem _msg = new Mensagem();
                _msg.mensagem = "Campo Dia com formato incorreto";
                return BadRequest(_msg);
            }

            List<AlocacaoVO> _alocado = await _repository.ListAll(alocacaoVO);

            List<Momento> _momentos = await _momentoRepository.FindByMonth(Convert.ToDateTime(alocacaoVO.dia).ToString("yyyy-MM"));
            
            List<Momento> horasDia = _momentos
                                        .OrderBy(r=> Convert.ToDateTime(r.dataHora).ToString("HH:mm:yyyy"))
                                        .Where(r => Convert.ToDateTime(r.dataHora).ToString("yyyy-MM-dd") == alocacaoVO.dia)
                                        .ToList<Momento>();
            calculoHoras(horasDia);

            var horaAlocacao = alocacaoVO.tempo.Split(new[] {'T','H','M','S'});
            int.TryParse(horaAlocacao[1],out _horaAloc);
            int.TryParse(horaAlocacao[2],out _minutoAloc);
            int.TryParse(horaAlocacao[3],out _segundoAloc);

            totalAlocado = HtoC(_horaAloc,_minutoAloc,_segundoAloc);
            totalTrabalhado = HtoC(horas,minutos,segundos);

            if (totalAlocado > totalTrabalhado)
            {
                Mensagem _msg = new Mensagem();
                _msg.mensagem = "Não pode alocar tempo maior que o tempo trabalhado no dia";
                return BadRequest(_msg);
            }

            if (alocacaoVO == null) return BadRequest();
            var alocacao = await _repository.Create(alocacaoVO);
            return Created("", alocacao); 
        }

        public static bool IsDateTime(string tempDate)
        {
            DateTime fromDateValue;
            var format = "yyyy-MM-dd";
            return DateTime.TryParseExact(tempDate, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue);
        }

        private void calculoHoras(List<Momento> horasDia)
        {
            for (int i = 0; i < horasDia.Count() - 1; i++)
            {
                if (i == 1) continue;

                foreach (var item in horasDia)
                {
                    if (Convert.ToDateTime(horasDia[i].dataHora) < Convert.ToDateTime(item.dataHora))
                    {
                        TimeSpan diff = Convert.ToDateTime(item.dataHora) - Convert.ToDateTime(horasDia[i].dataHora);
                        horas += diff.Hours;
                        minutos += diff.Minutes;
                        segundos += diff.Seconds;

                        break;
                    }
                }
            }
        }

        private decimal HtoC(int Hora , decimal minuto, decimal segundo)
        {
            decimal cCent = Hora+decimal.Round((minuto / 60), 2, MidpointRounding.AwayFromZero)+(segundo/3600);
            return cCent;
        }

    }
}