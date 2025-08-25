using ald_controls.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ald_controls.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Colaborador> Colaboradores { get; set; }
    public DbSet<RegistroEpi> RegistrosEpi { get; set; }
    public DbSet<Epi> Epis { get; set; }
}
