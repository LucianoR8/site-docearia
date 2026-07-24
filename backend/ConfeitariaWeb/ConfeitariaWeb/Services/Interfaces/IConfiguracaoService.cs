using ConfeitariaWeb.Models;
using ConfeitariaWeb.DTOs;
using ConfeitariaWeb.DTOs.Configuracao;

namespace ConfeitariaWeb.Services.Interface
{
    public interface IConfiguracaoService
    {
        Task<ConfiguracaoResponseDto?> ObterAsync();
        Task<ConfiguracaoResponseDto> AtualizarAsync(ConfiguracaoUpdateDto dto);

    }
}