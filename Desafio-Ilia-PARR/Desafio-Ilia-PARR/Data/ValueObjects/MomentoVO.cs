using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Desafio_Ilia_PARR.Data.ValueObjects
{
    public class MomentoVO
    {
        
        public long Id { get; set; }
        public string? dataHora { get; set; }

        public MomentoVO()
        {
            //dataHora = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
        }

    }
}
