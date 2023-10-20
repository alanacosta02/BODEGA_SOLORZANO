using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    public class EstadoPedidoController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly logEstadoPedido _datosEstadoPedido = new logEstadoPedido();

        public EstadoPedidoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Listar()
        {
            var listaEstadosPedido = _datosEstadoPedido.ListarEstadosPedido();
            return View(listaEstadosPedido);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(entEstadoPedido estadoPedido)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Lógica para validar y crear el estado de pedido
                    _datosEstadoPedido.CrearEstadoPedido(estadoPedido);

                    // Redireccionar a la acción de listar después de crear el estado de pedido
                    return RedirectToAction("Listar");
                }
                catch (Exception ex)
                {
                    // Manejar la excepción, puedes redirigir a una página de error o mostrar un mensaje al usuario
                    ModelState.AddModelError(string.Empty, $"Error al guardar el estado de pedido: {ex.Message}");
                }
            }

            // Si el modelo no es válido o hay un error, regresar a la vista de creación con errores
            return View(estadoPedido);
        }
    }
}
