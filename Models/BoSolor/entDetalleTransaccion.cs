using System.ComponentModel.DataAnnotations;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entDetalleTransaccion
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "formato incorrecto para el sub total")]
        public decimal SubTotal;
        public entTransacción Transaccion { get; set; }
        public int IdTransaccion { get; set; }
        public entProducto Producto { get; set; }
        public int IdProducto { get; set; }

    }
}
