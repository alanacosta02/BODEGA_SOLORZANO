using System.ComponentModel.DataAnnotations;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entCuenta
    {
        public int IdCuenta { get; set; }
        public string DNI { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "El teléfono debe tener 9 dígitos.")]
        public string Telefono;
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string Correo;
        [RegularExpression(@"^[a-zA-ZÑñ]{6,20}$", ErrorMessage = "El nombre de usuario debe tener entre 6 y 20 caracteres y solo puede contener letras")]
        public string UserName;
        [RegularExpression(@"^.{6,}$",ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password;
        public bool Activo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; } // DateTime? para permitir valores nulos
        public entRoll IdRol { get; set; }
    }
}
