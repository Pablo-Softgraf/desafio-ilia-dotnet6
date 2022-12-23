using Desafio_Ilia_PARR.Data.ValueObjects;
using Desafio_Ilia_PARR.Model;
using System.Net.Http.Headers;

namespace Desafio_Ilia_PARR.Repository
{
    public interface IAlocacaoRepository
    {
        Task<AlocacaoVO> Create(AlocacaoVO alocacaoVO);
        Task<List<AlocacaoVO>> ListAll(AlocacaoVO vo);
        Task<List<Alocacao>> ListByDate(string myDate);
    }
}
