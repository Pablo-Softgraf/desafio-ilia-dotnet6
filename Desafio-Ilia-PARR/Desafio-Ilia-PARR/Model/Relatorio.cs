﻿namespace Desafio_Ilia_PARR.Model
{
    public class Relatorio
    {
        public string? mes { get; set; }
        public string? horasTrabalhadas { get; set; }
        public string? horasExcedentes { get; set; }
        public string? horasDevidas { get; set; }
        public List<Registro> ? registros { get; set; }
        public List<Alocacao> ? alocacoes { get; set; }
    }
}