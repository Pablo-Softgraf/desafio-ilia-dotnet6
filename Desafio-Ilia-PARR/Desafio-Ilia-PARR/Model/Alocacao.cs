using Desafio_Ilia_PARR.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Ilia_PARR.Model
{
    [Table("alocacao")]
    public class Alocacao : BaseEntity
    {
        [Column("dia")]
        [Required]
        public string? dia { get; set; }
        [Column("tempo")]
        public string? tempo { get; set; }
        [Column("nomeProjeto")]
        public string? nomeProjeto { get; set; }

    }
}
