using ApiSimples.Model;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

   public DbSet<AutorModel> Autor{ get; set; }
    public DbSet<LivroModel> Livros { get; set; }

}