using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProject.Login.servicios
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void ValidarCorreo_DeberiaRetornarMensajeCorrectoParaCorreoInvalido()
        {
            // Arrange (preparación)
            string correoInvalido = "correo_invalido";

            // Act (acción)
            string resultado = Validation.ValidarCorreo(correoInvalido);

            // Assert (verificación)
            Assert.AreEqual("El correo electrónico no tiene un formato válido.", resultado);
        }

        [Test]
        public void ValidarCorreo_DeberiaRetornarMensajeCorrectoParaCorreoConDominioIncorrecto()
        {
            // Arrange (preparación)
            string correoConDominioIncorrecto = "correo@hotmail.com";

            // Act (acción)
            string resultado = Validation.ValidarCorreo(correoConDominioIncorrecto);

            // Assert (verificación)
            Assert.AreEqual("Solo se aceptan correos electrónicos de Google (gmail.com).", resultado);
        }

        [Test]
        public void ValidarCorreo_DeberiaRetornarMensajeVacioParaCorreoValido()
        {
            // Arrange (preparación)
            string correoValido = "correo@gmail.com";

            // Act (acción)
            string resultado = Validation.ValidarCorreo(correoValido);

            // Assert (verificación)
            Assert.AreEqual(string.Empty, resultado);
        }

        [Test]
        public void ValidarUsuario_DeberiaRetornarMensajeCorrectoParaUsuarioInvalido()
        {
            // Arrange (preparación)
            string usuarioInvalido = "usuario123";

            // Act (acción)
            string resultado = Validation.ValidarUsuario(usuarioInvalido);

            // Assert (verificación)
            Assert.AreEqual("El usuario no es válido. Solo se permiten letras (mayúsculas y minúsculas) y debe tener una longitud entre 5 y 20 caracteres.", resultado);
        }

        [Test]
        public void ValidarUsuario_DeberiaRetornarMensajeVacioParaUsuarioValido()
        {
            // Arrange (preparación)
            string usuarioValido = "UsuarioValido";

            // Act (acción)
            string resultado = Validation.ValidarUsuario(usuarioValido);

            // Assert (verificación)
            Assert.AreEqual(string.Empty, resultado);
        }



            
    


    }

}
