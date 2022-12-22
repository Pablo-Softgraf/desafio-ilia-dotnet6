using AutoMapper;
using Desafio_Ilia_PARR.Data.ValueObjects;
using Desafio_Ilia_PARR.Model;

namespace Desafio_Ilia_PARR.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AlocacaoVO, Alocacao>();
                config.CreateMap<Alocacao, AlocacaoVO>();
            });
            return mappingConfig; 
        }
    }
}
