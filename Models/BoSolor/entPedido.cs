using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entPedido
    {
        public int IdPedido { get; set; }
        public string direccionEntrega;
        public string referencia;
        public string detalle;
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public entCliente IdCliente { get; set; }
        public entTransacción IdTransaccion { get; set; }
        public entEstadoPedido IdEstadoPedido { get; set; }
        public entCuenta IdRepartidor { get; set; }


        #region Get and Set

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 100 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Solo se permiten letras y números")]
        public string DireccionEntrega
        {
            get { return direccionEntrega; }
            set { direccionEntrega = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 100 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Solo se permiten letras y números")]
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 100 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Solo se permiten letras y números")]
        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        #endregion
    }
}
