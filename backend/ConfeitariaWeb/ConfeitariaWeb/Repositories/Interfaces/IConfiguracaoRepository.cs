using ConfeitariaWeb.Models;

namespace ConfeitariaWeb.Repositories.Interfaces
{
    public interface IConfiguracaoRepository
    {
        Task<Configuracao?> ObterAsync();
        void Atualizar(Configuracao configuracao);
        Task SalvarAlteracoesAsync();
    }
}