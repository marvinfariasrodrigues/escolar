using Escolar.Models;
using Microsoft.EntityFrameworkCore;

namespace Escolar.Context
{
  public class AlunoContext : DbContext
  {
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Turma> Turmas { get; set; }
    public DbSet<Serie> Series { get; set; }

    protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=escolar.db");
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
