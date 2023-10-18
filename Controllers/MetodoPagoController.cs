using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    [Authorize]
    public class MetodoPagoController : Controller
    {
        private readonly IWebHostEnvironment _environment; // Esto se usa para obtener la ruta del directorio de contenido web
        public MetodoPagoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        private readonly logMetodoPago _datos = new logMetodoPago();
        public IActionResult Listar()
        {
            var listaMetodo = _datos.ListarMetodosPago();
            return View(listaMetodo);
        }
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(entMetodoPago metodoPago)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var respuesta = _datos.CrearMetodoPago(metodoPago);

                    if (respuesta)
                    {
                        return RedirectToAction("Listar");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al intentar guardar el método de pago: {ex.Message}");
            }

            return View();
        }
    }
}
