using Desafio_Ilia_PARR.Data.ValueObjects;
using Desafio_Ilia_PARR.Model;
using Desafio_Ilia_PARR.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Desafio_Ilia_PARR.Controllers
{
    [ApiController]
    [Route("v1/folha-de-ponto/{mes}")]
    public class RelatorioController : ControllerBase
    {
        private int horasMes;
        private int minutosMes;
        private int segundosMes;
        private int horaAlocMes;
        private int minutosAlocMes;
        private int segundosAlocMes;
        
        private IMomentoRepository _momentoRepository;
        private IAlocacaoRepository _alocacaoRepository;

        public RelatorioController(IMomentoRepository repository, IAlocacaoRepository alocacaoRepository)
        {
            _momentoRepository = repository ?? throw new
                ArgumentNullException(nameof(repository));

            _alocacaoRepository = alocacaoRepository ?? throw new
                ArgumentNullException(nameof(alocacaoRepository));
        }

        [HttpGet()]
        public async Task<ActionResult<Relatorio>> geraRelatorioMensal(string mes)
        {
            decimal totalAlocado = 0;
            decimal totalTrabalhado = 0;
            string _horasExcedentes;
            string _horasDevidas;
            List<Momento> _momentos = await _momentoRepository.FindByMonth(mes);
            List<Alocacao> _alocacoes = await _alocacaoRepository.ListByDate(mes);
            List<Registro> listaRegistros = new List<Registro>();

            var dias = _momentos
                       .Select(r => Convert.ToDateTime(r.dataHora).ToString("yyyy-MM-dd"))
                       .Distinct();


            if (dias.Count() == 0) return NotFound("Relatório não encontrado");

            foreach (var dia in dias)
            {
                List<Momento> horasDia = _momentos
                                            .Where(r => Convert.ToDateTime(r.dataHora).ToString("yyyy-MM-dd") == dia)
                                            .ToList();
                calculoHoras(horasDia);

                Registro registro = new Registro()
                {
                    dia = dia,
                    horarios = horasDia.Select(r => Convert.ToDateTime(r.dataHora).ToString("HH:mm:ss")).ToList()
                };
                
                listaRegistros.Add(registro);
            }


            calculaAlocacoes(_alocacoes);
    
            totalAlocado = HtoC(horaAlocMes, minutosAlocMes, segundosAlocMes);
            totalTrabalhado = HtoC(horasMes, minutosMes, segundosMes);
            decimal totalExcedente = totalTrabalhado - totalAlocado;
            decimal totalDevidas = totalAlocado - totalTrabalhado;
            _horasExcedentes = "PT0S";
            _horasDevidas = "PT0S";

            if (totalExcedente > 0)
                _horasExcedentes = String.Format("PT{0:%h}H{0:%m}S{0:%s}", TimeSpan.FromHours(Convert.ToDouble(totalExcedente)));

            if (totalDevidas > 0)
                _horasDevidas = String.Format("PT{0:%h}H{0:%m}S{0:%s}", TimeSpan.FromHours(Convert.ToDouble(totalDevidas)));

            Relatorio relatorio = new Relatorio()
            {
                mes = mes,
                horasTrabalhadas = string.Format("PT{0}H{1}M{2}S", horasMes, minutosMes, segundosMes),
                horasExcedentes = _horasExcedentes,
                horasDevidas = _horasDevidas,
                registros = listaRegistros,
                alocacoes = _alocacoes
            };

            return Created("",relatorio);
        }

        private void calculoHoras(List<Momento> horasDia )
        {
            for (int i = 0; i < horasDia.Count() - 1; i++)
            {
                if (i == 1) continue;
                foreach (var item in horasDia)
                {
                    if (Convert.ToDateTime(horasDia[i].dataHora) < Convert.ToDateTime(item.dataHora))
                    {
                        TimeSpan diff = Convert.ToDateTime(item.dataHora) - Convert.ToDateTime(horasDia[i].dataHora);
                        horasMes += diff.Hours;
                        minutosMes += diff.Minutes;
                        segundosMes += diff.Seconds;
                        break;
                    }
                }
            }
        }

        private void calculaAlocacoes(List<Alocacao> _alocacoes)
        {
            int _horaAloc = 0;
            int _minutoAloc = 0;
            int _segundoAloc = 0;
            
            foreach ( Alocacao alocacao in _alocacoes)
            {
                var horaAlocacao = alocacao.tempo.Split(new[] { 'T', 'H', 'M', 'S' });
                int.TryParse(horaAlocacao[1], out _horaAloc);
                int.TryParse(horaAlocacao[2], out _minutoAloc);
                int.TryParse(horaAlocacao[3], out _segundoAloc);

                horaAlocMes += _horaAloc;
                minutosAlocMes+= _minutoAloc;
                segundosAlocMes += _segundoAloc;
            }
        }

        private decimal HtoC(int Hora, decimal minuto, decimal segundo)
        {
            decimal cCent = Hora + decimal.Round((minuto / 60), 2, MidpointRounding.AwayFromZero) + (segundo / 3600);
            return cCent;
        }

    }
}