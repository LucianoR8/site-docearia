using ConfeitariaWeb.Data;
using ConfeitariaWeb.Repositories.Interface;

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