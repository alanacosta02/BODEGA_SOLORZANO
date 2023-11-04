using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Login.servicios
{
    public class test
    {
        [Test]
        public void TestCrearUsuario_ConErrores()
        {
            // Arrange
            entUsuario usuario = new entUsuario
            {
                // Configura los valores de usuario como desees para probar diferentes casos de error
            };

            logUsuario gestorUsuarios = new logUsuario();

            // Act
            List<string> errores = new List<string>();
            bool resultado = gestorUsuarios.CrearUsuario(usuario, out errores);

            // Assert
            Assert.IsFalse(resultado, "El usuario con errores no debería ser creado correctamente.");
            Assert.IsNotEmpty(errores, "La lista de errores no debería estar vacía cuando la creación del usuario falla.");
        }

        [Test]
        public void TestCrearUsuario_SinErrores()
        {
            // Arrange
            entUsuario usuario = new entUsuario
            {
                // Configura los valores de usuario válidos para probar la creación exitosa
            };

            logUsuario gestorUsuarios = new logUsuario();

            // Act
            List<string> errores = new List<string>();
            bool resultado = gestorUsuarios.CrearUsuario(usuario, out errores);

            // Assert
            Assert.IsTrue(resultado, "El usuario sin errores debería ser creado correctamente.");
            Assert.IsEmpty(errores, "La lista de errores debería estar vacía cuando la creación del usuario tiene éxito.");
        }

        [Test]
        public void TestValidateUsuario_Valido()
        {
            // Arrange
            string usuario = "UsuarioValido";

            // Act
            string resultado = logUsuario.Instancia.ValidateCorreo(usuario);

            // Assert
            Assert.AreEqual(string.Empty, resultado, "El usuario válido debería pasar la validación.");
        }

        [Test]
        public void TestValidateUsuario_Invalido()
        {
            // Arrange
            string usuario = "Inválido1"; // Menos de 5 caracteres

            // Act
            string resultado = logUsuario.Instancia.ValidateUsuario(usuario);

            // Assert
            Assert.AreEqual("El nombre de usuario no es válido (Solo se aceptan de 5 a 20 letras).", resultado, "El usuario inválido debería fallar la validación.");
        }

        [Test]
        public void TestValidateCorreo_Valido()
        {
            // Arrange
            string correo = "usuario@gmail.com";

            // Act
            string resultado = logUsuario.Instancia.ValidateCorreo(correo);

            // Assert
            Assert.AreEqual(string.Empty, resultado, "El correo válido debería pasar la validación.");
        }

        [Test]
        public void TestValidateCorreo_Invalido()
        {
            // Arrange
            string correo = "correo@hotmail.com"; // No es un correo de Gmail

            // Act
            string resultado = logUsuario.Instancia.ValidateCorreo(correo);

            // Assert
            Assert.AreEqual("El correo electrónico no es válido (Solo se aceptan correos gmail).", resultado, "El correo inválido debería fallar la validación.");
        }

        [Test]
        public void TestValidatePassword_Valido()
        {
            // Arrange
            string password = "Admin25*-+"; // Cumple con los requisitos

            // Act
            string resultado = logUsuario.Instancia.ValidatePassword(password);

            // Assert
            Assert.AreEqual(string.Empty, resultado, "La contraseña válida debería pasar la validación.");
        }

        [Test]
        public void TestValidatePassword_Invalido()
        {
            // Arrange
            string password = "pass"; // Menos de 8 caracteres

            // Act
            string resultado = logUsuario.Instancia.ValidatePassword(password);

            // Assert
            Assert.AreEqual("La contraseña no es válida (Debe contener al menos un número, una letra, un carácter especial y como mínimo 8 caracteres).", resultado, "La contraseña inválida debería fallar la validación.");
        }
    }
}
