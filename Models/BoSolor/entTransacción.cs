using System.ComponentModel.DataAnnotations;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entTransacción
    {
        public int IdTransaccion { get; set; }
        public string CodTransaccion { get; set; }
        public string tipoTransaccion;
        public decimal montoBruto;
        public decimal descuento;
        public decimal montoTotal;
        public DateTime FechaHora { get; set; }
        public string EstadoTransaccion { get; set; }
        public string IdPersona { get; set; }
        public entMetodoPago IdMetodo { get; set; }
        public entCuenta IdCuenta { get; set; }


        #region Get and Set

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 100 caracteres")]
        public string TipoTransaccion
        {
            get { return tipoTransaccion; }
            set { tipoTransaccion = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "formato incorrecto para el sub total")]
        public decimal MontoBruto
        {
            get { return montoBruto; }
            set { montoBruto = value; }
        }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "formato incorrecto para el sub total")]
        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "formato incorrecto para el sub total")]
        public decimal MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        #endregion
    }
}
