using Desafio_Ilia_PARR.Data.ValueObjects;
using System.Net.Http.Headers;

namespace Desafio_Ilia_PARR.Repository
{
    public interface IAlocacaoRepository
    {
        Task<AlocacaoVO> Create(AlocacaoVO alocacaoVO);
        Task<List<AlocacaoVO>> ListAll(AlocacaoVO vo);
    }
}
