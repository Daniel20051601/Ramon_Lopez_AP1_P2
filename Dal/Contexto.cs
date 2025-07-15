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
            new Productos
            {
                ProductoId = 1,
                Descripcion = "Maní",
                Peso = 10.00m,
                Existencia = 100,
                EsCompuesto = false
            },
            new Productos
            {
                ProductoId = 2,
                Descripcion = "Pistachos",
                Peso = 5.00m,
                Existencia = 100,
                EsCompuesto = false
            },
            new Productos
            {
                ProductoId = 3,
                Descripcion = "Almendras",
                Peso = 20.00m,
                Existencia = 100,
                EsCompuesto = false
            },

             new Productos
             {
                 ProductoId = 4,
                 Descripcion = "Frutos Mixtos 200gr",
                 Peso = 200.00m,
                 Existencia = 0,
                 EsCompuesto = true
             },
            new Productos
            {
                ProductoId = 5,
                Descripcion = "Frutos Mixtos 400gr",
                Peso = 400.00m,
                Existencia = 0,
                EsCompuesto = true
            },
            new Productos
            {
                ProductoId = 6,
                Descripcion = "Frutos Mixtos 600gr",
                Peso = 600.00m,
                Existencia = 0,
                EsCompuesto = true
            }
        );
    }

}
