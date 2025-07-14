using System.ComponentModel.DataAnnotations;

namespace Ramon_Lopez_AP1_P2.Models;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Peso { get; set; }

    public decimal Existencia { get; set; }

    public bool EsCompuesto { get; set; }

    public virtual ICollection<EntradasDetalle> EntradasDetalles { get; set; } = new List<EntradasDetalle>();
}
