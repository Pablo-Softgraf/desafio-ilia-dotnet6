using System.ComponentModel.DataAnnotations;

namespace Desafio_Ilia_PARR.Model
{
    public class Alocacao
    {
        public long? Id { get; set; }
        [Required]
        public string? dia { get; set; }
        [Required]
        public string? tempo { get; set; }
        [Required]
        public string? nomeProjeto { get; set; }
    }
}
