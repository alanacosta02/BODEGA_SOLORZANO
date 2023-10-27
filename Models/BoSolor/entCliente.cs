using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using System;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entCliente
    {
        public int idCliente;
        public string nombres;
        public string apellidos;
        public string numDocumento;


        #region Get and Set
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud debe estar entre 3 y 50 caracteres")]
        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La longitud debe estar entre 5 y 50 caracteres")]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números")]
        [StringLength(8, ErrorMessage = "La longitud debe ser de 8 dígitos")]
        public string NumDocumento
        {
            get { return numDocumento; }
            set { numDocumento = value; }
        }


        #endregion

    }
}
