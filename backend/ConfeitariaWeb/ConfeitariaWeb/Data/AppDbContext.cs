using Microsoft.EntityFrameworkCore;
using ConfeitariaWeb.Models;

namespace ConfeitariaWeb.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos => Set<Produto>();

    public DbSet<Categoria> Categorias => Set<Categoria>();

    public DbSet<Configuracao> Configuracoes => Set<Configuracao>();
}