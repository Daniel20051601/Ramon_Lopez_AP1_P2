using Microsoft.EntityFrameworkCore;
using Ramon_Lopez_AP1_P2.Models;

namespace Ramon_Lopez_AP1_P2.Dal;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public Contexto() { }

    public DbSet<Productos> Productos { get; set; } = null!;
    public DbSet<Entradas> Entradas { get; set; } = null!;
    public DbSet<EntradasDetalle> EntradasDetalle { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Productos>().HasData(
            new Productos {ProductoId = 1, Descripcion = "Maní",Peso = 5.00m,Existencia = 100.0m, EsCompuesto = false},
            new Productos {ProductoId = 2, Descripcion = "Almendra", Peso = 10.00m, Existencia = 75.0m, EsCompuesto = false },
            new Productos {ProductoId = 3, Descripcion = "Pistacho", Peso = 20.00m, Existencia = 50.0m, EsCompuesto = false}
        );
    }

}
