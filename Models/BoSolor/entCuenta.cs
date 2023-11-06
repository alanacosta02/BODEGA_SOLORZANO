using System.ComponentModel.DataAnnotations;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entCuenta
    {
        public int IdCuenta { get; set; }
        public string DNI { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "El teléfono debe tener 9 dígitos.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string Correo { get; set; }
        [RegularExpression(@"^[a-zA-ZÑñ]{6,20}$", ErrorMessage = "El nombre de usuario debe tener entre 6 y 20 caracteres y solo puede contener letras")]
        public string UserName { get; set; }
        [RegularExpression(@"^.{6,}$",ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string Password { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; } // DateTime? para permitir valores nulos
        public entRol IdRol { get; set; }
    }
}
