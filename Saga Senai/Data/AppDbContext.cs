using Microsoft.EntityFrameworkCore;
using TarefasApp.Models;

namespace TarefasApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Colaborador> Colaboradores { get; set; }
    public DbSet<RegistroEPI> RegistrosEPI { get; set; }
    }
}