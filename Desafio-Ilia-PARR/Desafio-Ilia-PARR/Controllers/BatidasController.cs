using Desafio_Ilia_PARR.Data.ValueObjects;
using Desafio_Ilia_PARR.Model;
using Desafio_Ilia_PARR.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;

namespace Desafio_Ilia_PARR.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class BatidasController : ControllerBase
    {
        private IMomentoRepository _repository;

        public BatidasController(IMomentoRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpPost("insereBatida")]
        public async Task<ActionResult<MomentoVO>> Create(MomentoVO momentoVO)
        {
            
            if (momentoVO == null) return BadRequest();

            Mensagem _msg = new Mensagem();
            List<Momento> _momentos = await _repository.FindAllDates(momentoVO);
            DateTime _dataHora = Convert.ToDateTime(momentoVO.dataHora);

            //********************************************************************
            // Validações com padronização de retornos                           *   
            //********************************************************************            

            if (!IsDateTime(momentoVO.dataHora))
            {
                _msg.mensagem = "Data e Hora em formato inválido";
                return BadRequest(_msg);
            }
            
            if (momentoVO.dataHora == String.Empty)
            {
                _msg.mensagem = "Campo obrigatório não informado";
                return BadRequest(_msg);
            }

            if (_dataHora.DayOfWeek == DayOfWeek.Saturday || _dataHora.DayOfWeek == DayOfWeek.Sunday)
            {
                _msg.mensagem = "Sábado e domingo não são permitidos como dia de trabalho";
                return StatusCode(StatusCodes.Status403Forbidden, _msg);
            }

            var _duplicidade = _momentos.Find(r => r.dataHora == momentoVO.dataHora);
            if (_duplicidade != null)
            {
                _msg.mensagem = "Horário já registrado";
                return Conflict(_msg);
            }

            var _dataHoraAlmoco = _momentos.OrderBy(r => Convert.ToDateTime(r.dataHora))
                                          .Max(r => Convert.ToDateTime(r.dataHora));

            if (_momentos.Count == 2)
            {
                double totalHours = (_dataHora - _dataHoraAlmoco).TotalHours;

                if (totalHours < 1)
                {
                    _msg.mensagem = "Deve haver no minimo 1 hora de almoço";
                    return StatusCode(StatusCodes.Status403Forbidden, _msg);
                }
            }

            if (_momentos.Count == 4)
            {
                _msg.mensagem = "Apenas 4 horários podem ser registrados por dia";
                return StatusCode(StatusCodes.Status403Forbidden,_msg);
            }

            
            var _momentoCreated = await _repository.Create(momentoVO);
            List<Momento> _responseCreated = await _repository.FindAllDates(momentoVO);
            string _dia = _responseCreated.Select(r => Convert.ToDateTime(r.dataHora).ToString("yyyy-MM-dd")).First();  
            List<string> _horarios = _responseCreated.Select(r => Convert.ToDateTime(r.dataHora).ToString("HH:mm:ss")).ToList();

            return Created("", new Registro() { dia = _dia, horarios = _horarios }); 
        }

        public static bool IsDateTime(string tempDate)
        {
            DateTime fromDateValue;
            var format = "yyyy-MM-ddTHH:mm:ss";
            return DateTime.TryParseExact(tempDate, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue);
        }
    }
}