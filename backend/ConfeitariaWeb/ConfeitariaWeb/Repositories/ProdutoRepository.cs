using ConfeitariaWeb.Repositories.Interface;
using ConfeitariaWeb.Models;
using Microsoft.EntityFrameworkCore;
using ConfeitariaWeb.Data;

namespace ConfeitariaWeb.Repositories
{
    public class ProdutoRepository  : IProdutoRepository
    {
        public async Task<List<Produto>> ObterTodosAsync()
        {

        }
    }
}