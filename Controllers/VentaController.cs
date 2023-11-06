using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();
        }
        public IActionResult GenerarFactura()
        {
            return View();
        }
        public IActionResult Reporte()
        {
            return View();
        }
    }
}
