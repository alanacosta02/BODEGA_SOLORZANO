using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entProveedor
    {
        private int idProveedor;
        private string razonSocial;
        private string numDocumento;
        private string Contacto;
        private bool activo;

        #region Get and Set
        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La longitud debe estar entre 2 y 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Solo se permiten letras, números y espacios")]
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números")]
        [StringLength(8, ErrorMessage = "La longitud debe ser de 8 dígitos")]
        public string NumDocumento
        {
            get { return numDocumento; }
            set { numDocumento = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(9, MinimumLength = 7, ErrorMessage = "La longitud debe estar entre 7 y 9 caracteres")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números")]
        public string contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        #endregion
    }
}
