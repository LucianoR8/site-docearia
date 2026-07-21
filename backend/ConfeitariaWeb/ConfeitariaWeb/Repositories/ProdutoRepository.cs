using ConfeitariaWeb.Repositories.Interface;
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using ConfeitariaWeb.Data;

namespace ConfeitariaWeb.Repositories
{
    public class ProdutoRepository  : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Produto>> ObterTodosAsync()
        {
            return await _context.Produtos.Include(p => p.Categoria).OrderBy(p => p.NomeProduto).ToListAsync();
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            return await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.IdProduto == id);
        }

        public async Task<List<Produto>> ObterPorCategoriaAsync(int categoriaId)
        {
            return await _context.Produtos.Include(p => p.Categoria).Where(p => p.CategoriaId == categoriaId).OrderBy(p => p.NomeProduto).ToListAsync();
        }
    }
}