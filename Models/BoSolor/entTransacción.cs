using System.ComponentModel.DataAnnotations;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entTransacción
    {
        public int IdTransaccion { get; set; }
        public string CodTransaccion { get; set; }
        public string TipoTransaccion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "formato incorrecto para el sub total")]
        public decimal MontoBruto { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números")]
        [Range(1, 100, ErrorMessage = "El descuento debe estar en el rango del 1 al 100")]
        public decimal Descuento { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaHora { get; set; }
        public string EstadoTransaccion { get; set; }
        public entCliente IdPersona { get; set; }
        public entMetodoPago IdMetodo { get; set; }
        public entCuenta IdCuenta { get; set; }


    }
}
