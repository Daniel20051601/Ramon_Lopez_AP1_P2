using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ramon_Lopez_AP1_P2.Models;

public class Entradas
{
    [Key]
    public int EntradaId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Debe agregar un concepto")]
    public string Concepto { get; set; } = null!;

    [InverseProperty("Entradas")]
    public virtual ICollection<EntradasDetalle> EntradasDetalle { get; set; } = new List<EntradasDetalle>();
}
