using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authentication;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;


[TestFixture]
public class PruebasProducto
{
    [Test]
    public void TestCrearProducto()
    {
        // Arrange
        entProducto producto = new entProducto
        {
            Nombre = "Producto de prueba",
            Descripcion = "Descripción de prueba",
            Codigo = "12345",
            PrecioVenta = 100,
            Imagen = "ruta/de/imagen.jpg",
            IdCategoria = new entCategoria { IdCategoria = 1, Nombre = "Categoria de prueba" }
        };

        logProducto logProducto = new logProducto(); // Asegúrate de que la clase GestorProductos está accesible

        // Act
        bool resultado = logProducto.CrearProducto(producto);

        // Assert
        Assert.IsTrue(resultado, "El producto no se creó correctamente.");
    }
}

