using System.ComponentModel.DataAnnotations;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entProducto
    {
        private int idProducto;
        private string nombre;
        private string descripcion;
        private string codigo;
        private int stock;
        private double precioVenta;
        private string imagen;
        private bool activo;
        private DateTime fechaCreacion;
        private entCategoria idCategoria;

        #region Get and Set
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud debe estar entre 3 y 50 caracteres")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 100 caracteres")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(8, ErrorMessage = "La longitud máxima es 8 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Solo se permiten letras y números")]
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Formato de precio incorrecto")]
        public double PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        public entCategoria IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        #endregion

        public string mostrarDatos()
        {
            return nombre + " " + codigo + " " + stock + " " + precioVenta;
        }
    }
}
