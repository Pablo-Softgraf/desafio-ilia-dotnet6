﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Desafio_Ilia_PARR.Data.ValueObjects
{
    public class AlocacaoVO
    {
        
        public long Id { get; set; }
        public string? dia { get; set; }
        public string? tempo { get; set; }
        public string? nomeProjeto { get; set; }

        public AlocacaoVO()
        {
            dia = DateTime.Now.ToString("dd/MM/yyyy");
            nomeProjeto = "Insira nome do projeto";
        }

    }
}
