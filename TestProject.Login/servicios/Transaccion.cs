using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Login.servicios
{
    [TestFixture]
    public class PruebasTransacciones
    {
        [Test]
        public void TestListarTransacciones()
        {
            // Arrange
            logTransacción gestorTransacciones = new logTransacción(); // Asegúrate de que la clase GestorTransacciones está accesible

            // Act
            List<entTransacción> transacciones = gestorTransacciones.ListarTransacciones();

            // Assert
            Assert.IsNotNull(transacciones, "La lista de transacciones no debería ser nula.");
            Assert.IsNotEmpty(transacciones, "La lista de transacciones no debería estar vacía.");
            // Puedes realizar más aserciones según el número esperado de transacciones o verificar otros campos si es necesario
        }
    }
}
