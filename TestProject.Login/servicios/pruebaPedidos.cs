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
    public class PruebasPedidos
    {
        [Test]
        public void TestCrearMetodoPago()
        {
            // Arrange
            logMetodoPago gestorMetodoPago = new logMetodoPago(); // Asegúrate de que la clase GestorMetodoPago está accesible

            entMetodoPago metodoPago = new entMetodoPago
            {
                Nombre = "Tarjeta de Crédito",
                Descripcion = "Método de pago con tarjeta de crédito"
            };

            // Act
            bool resultado = gestorMetodoPago.CrearMetodoPago(metodoPago);

            // Assert
            Assert.IsTrue(resultado, "El método de pago debería ser creado correctamente.");
        }
    }
}
