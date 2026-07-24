using ConfeitariaWeb.Repositories.Interfaces;
using ConfeitariaWeb.Data;
using Microsoft.EntityFrameworkCore;
using ConfeitariaWeb.Models;

namespace ConfeitariaWeb.Repositories
{
    public class ConfiguracaoRepository : IConfiguracaoRepository
    {
        private readonly AppDbContext _context;

        public ConfiguracaoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Configuracao?> ObterAsync()
        {
            return await _context.Configuracoes.FirstOrDefaultAsync();
        }

        public void Atualizar(Configuracao configuracao)
        {
            _context.Configuracoes.Update(configuracao);
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}