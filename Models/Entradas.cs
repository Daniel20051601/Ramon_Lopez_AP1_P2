using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ramon_Lopez_AP1_P2.Models;

public class Entradas
{
    [Key]
    public int EntradaId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Debe agregar un concepto.")]
    [StringLength(500, ErrorMessage = "El concepto no puede exceder los 500 caracteres.")]
    public string Concepto { get; set; } = null!;

    [Required(ErrorMessage = "El peso total es obligatorio.")]
    [Range(0.01, 99999999.99, ErrorMessage = "El peso total debe ser mayor a 0.")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal PesoTotal { get; set; }

    public int IdProducido { get; set; }

    [ForeignKey("IdProducido")]
    public virtual Productos? ProductoProducido { get; set; }

    public int CantidadProducida { get; set; }

    [InverseProperty("Entradas")]
    public virtual ICollection<EntradasDetalle> EntradasDetalle { get; set; } = new List<EntradasDetalle>();
}
