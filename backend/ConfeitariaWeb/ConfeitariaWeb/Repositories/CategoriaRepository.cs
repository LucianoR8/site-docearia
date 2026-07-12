using ConfeitariaWeb.Data;
using ConfeitariaWeb.Repositories.Interfaces;

namespace ConfeitariaWeb.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}