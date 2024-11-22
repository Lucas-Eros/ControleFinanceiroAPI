using ControleFinaceiroAPI.Models;

namespace ControleFinaceiroAPI.Data;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Mes> Meses { get; set; }
    public DbSet<Gasto> Gastos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mes>()
            .HasMany(m => m.Gastos)
            .WithOne(g => g.Mes)
            .HasForeignKey(g => g.MesId);
    }
}
