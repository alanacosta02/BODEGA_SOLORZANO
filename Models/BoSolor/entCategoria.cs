using System.ComponentModel.DataAnnotations;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entCategoria
    {
        private int idCategoria;       
        private string nombre;
        private string descripcion;
        private bool activo;
        private DateTime fechaCreacion;

        #region Get and Set
        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
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
        #endregion
    }
}
