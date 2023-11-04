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
    public class estadoPEdido
    {
        [Test]
        public void TestCrearEstadoPedido()
        {
            // Arrange
            logEstadoPedido gestorEstadoPedido = new logEstadoPedido(); // Asegúrate de que la clase GestorEstadoPedido está accesible

            entEstadoPedido estadoPedido = new entEstadoPedido
            {
                NombreEstado = "Nuevo",
                Descripcion = "Pedido recién creado"
            };

            // Act
            bool resultado = gestorEstadoPedido.CrearEstadoPedido(estadoPedido);

            // Assert
            Assert.IsTrue(resultado, "El estado del pedido debería ser creado correctamente.");
        }
    }
}
