using Desafio_Ilia_PARR.Data.ValueObjects;
using Desafio_Ilia_PARR.Model;

namespace Desafio_Ilia_PARR.Repository
{
    public interface IMomentoRepository
    {
        Task<MomentoVO> Create(MomentoVO alocacaoVO);
        Task<List<Momento>> ListAll(MomentoVO vo);
        Task<List<Momento>> FindAllDates(MomentoVO vo);
    }
}
