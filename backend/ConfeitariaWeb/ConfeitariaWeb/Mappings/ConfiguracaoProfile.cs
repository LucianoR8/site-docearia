using AutoMapper;
using ConfeitariaWeb.Models;
using ConfeitariaWeb.DTOs.Configuracao;
using ConfeitariaWeb.DTOs;

namespace ConfeitariaWeb.Mappings
{
    public class ConfiguracaoProfile : Profile
    {
        public ConfiguracaoProfile()
        {
            CreateMap<Configuracao, ConfiguracaoResponseDto>();
            CreateMap<ConfiguracaoUpdateDto, Configuracao>();
        }
    }
}
