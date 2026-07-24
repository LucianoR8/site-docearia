using AutoMapper;
using ConfeitariaWeb.Repositories.Interfaces;
using ConfeitariaWeb.Services.Interface;

namespace ConfeitariaWeb.Services
{
    public class ConfiguracaoService : IConfiguracaoService
    {
        private readonly IConfiguracaoRepository _configuracaoRepository;
        private readonly IMapper _mapper;

        public ConfiguracaoService(IConfiguracaoRepository configuracaoRepository, IMapper mapper)
        {
            _configuracaoRepository = configuracaoRepository;
            _mapper = mapper;
        }

    }
}