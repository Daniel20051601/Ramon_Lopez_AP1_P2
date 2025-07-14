using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ramon_Lopez_AP1_P2.Models;

public class EntradasDetalle
{
    [Key]
    public int VentaDetalleId { get; set; }

    public int EntradaId { get; set; }

    [ForeignKey("EntradaId")]
    [InverseProperty("EntradasDetalle")]
    public virtual Entradas Entradas { get; set; } = null!;

    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public virtual Productos Productos { get; set; }

    [Required(ErrorMessage = "Debe agregar cantidad")]
    public int Cantidad { get; set; }
    public decimal PesoTotal { get; set; }
}
