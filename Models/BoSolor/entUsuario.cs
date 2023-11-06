using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BODEGA_SOLORZANO.Models.BoSolor
{
        public class entUsuario
        {
            /*Para poder usar el DataAnnotations es necesario descargar el paquete nuget -> System.ComponentModel.Annotations en la capa que deseas usar*/

            [Display(Name = "ID")]
            public int IdCuenta { get; set; }

            [Required(ErrorMessage = "El DNI es requerido.")]
            [RegularExpression(@"^\d{8}[a-zA-Z]?$", ErrorMessage = "El DNI debe tener 8 dígitos y una letra opcional.")]
            public string Dni { get; set; }

            [RegularExpression(@"^\d{9}$", ErrorMessage = "El teléfono debe tener 9 dígitos.")]
            public string Telefono { get; set; }

            public DateTime FechaInicio { get; set; }

            public DateTime FechaFin { get; set; }

            [Required(ErrorMessage = "El correo electrónico es obligatorio")]
            [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
            public string Correo { get; set; }

            [RegularExpression(@"^[a-zA-ZÑñ]{6,20}$", ErrorMessage = "El nombre de usuario debe tener entre 6 y 20 caracteres y solo puede contener letras")]
            public string UserName { get; set; }

            [RegularExpression(@"^.{6,}$",
            ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
            public string Pass { get; set; }

            public entRol Rol { get; set; }

            public int IdRol { get; set; }

            public bool Activo { get; set; }

            public entUsuario()
            {
            }

            public entUsuario(string userName, string correo, string pass, entRol rol)
            {
                UserName = userName;
                Correo = correo;
                Pass = pass;
                Rol = rol;
            }
        }
    }

