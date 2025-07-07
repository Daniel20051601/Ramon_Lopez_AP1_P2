using Microsoft.EntityFrameworkCore;

namespace Ramon_Lopez_AP1_P2.Dal;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public Contexto() { }

    public DbSet<Models.Registro> Registros { get; set; } = null!;
    
}
