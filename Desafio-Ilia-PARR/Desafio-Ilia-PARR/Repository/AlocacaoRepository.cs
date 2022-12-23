using AutoMapper;
using Desafio_Ilia_PARR.Data.ValueObjects;
using Desafio_Ilia_PARR.Model;
using Desafio_Ilia_PARR.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Ilia_PARR.Repository
{
    public class AlocacaoRepository : IAlocacaoRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public AlocacaoRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<AlocacaoVO> Create(AlocacaoVO vo)
        {
            Alocacao alocacao = _mapper.Map<Alocacao>(vo);

            _context.Alocacoes.Add(alocacao);
            await _context.SaveChangesAsync();  
            return _mapper.Map<AlocacaoVO>(alocacao);
        }

        public async Task<List<AlocacaoVO>> ListAll(AlocacaoVO vo)
        {
            var RepeatedDay = await _context.Alocacoes.ToListAsync();
            List<Alocacao> alocacoes = RepeatedDay.Where(r => r.dia == vo.dia && r.nomeProjeto == vo.nomeProjeto).ToList();
            return _mapper.Map<List<AlocacaoVO>>(alocacoes);

        }

        public async Task<List<Alocacao>> ListByDate(string myDate)
        {
            var RepeatedDay = await _context.Alocacoes.ToListAsync();
            List<Alocacao> alocacoes = RepeatedDay.Where(r => r.dia?.Substring(0,7) == myDate).ToList();
            return alocacoes;
        }
    }
}
