using Desafio_Ilia_PARR.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Ilia_PARR.Model
{
    [Table("momento")]
    public class Momento : BaseEntity 
    {
        [Column("dataHora")]
        [Required]
        public string? dataHora { get; set; }
    }
}
