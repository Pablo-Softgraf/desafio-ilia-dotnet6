using AutoMapper;
using Desafio_Ilia_PARR.Data.ValueObjects;
using Desafio_Ilia_PARR.Model;
using Desafio_Ilia_PARR.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Desafio_Ilia_PARR.Repository
{
    public class MomentoRepository : IMomentoRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public MomentoRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<List<Momento>> FindAllDates(MomentoVO vo)
        {
            DateTime dtConvert = Convert.ToDateTime(vo.dataHora);
            var RepeatedDay = await _context.Momentos.ToListAsync();
            List<Momento> _momentos = RepeatedDay.Where(r => Convert.ToDateTime(r.dataHora).ToString("yyyy-MM-dd") == dtConvert.ToString("yyyy-MM-dd")).ToList();
            return _momentos;
        }

        public async Task<List<Momento>> ListAll(MomentoVO vo)
        {
            var RepeatedDay = await _context.Momentos.ToListAsync();
            List<Momento> _momentos = RepeatedDay.Where(r => r.dataHora == vo.dataHora).ToList();
            return _momentos;
        }

        public async Task<MomentoVO> Create(MomentoVO vo)
        {
            Momento _momento = _mapper.Map<Momento>(vo);

            _context.Momentos.Add(_momento);
            await _context.SaveChangesAsync();
            return _mapper.Map<MomentoVO>(_momento);
        }

        public async Task<List<Momento>> FindByMonth(string mes)
        {
            var RepeatedDay = await _context.Momentos.ToListAsync();
            List<Momento> _momentos = RepeatedDay.Where(r => Convert.ToDateTime(r.dataHora).ToString("yyyy-MM") == mes).ToList();
            return _momentos;
        }
    }
}
