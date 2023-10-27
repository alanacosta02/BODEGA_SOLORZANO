using System.ComponentModel.DataAnnotations;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entDetalleTransaccion
    {
        public entTransacción Transaccion { get; set; }
        public entProducto Producto { get; set; }
        public int cantidad;
        public decimal subTotal;

        #region Get and Set

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números")]
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "formato incorrecto para el sub total")]
        public decimal SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }


        #endregion
    }
}
