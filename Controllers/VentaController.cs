using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    public class VentaController : Controller
    {
        List<entDetalleTransaccion> lsDetalleProducto = new();
        entTransacción transaccion = new();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Guardar()
        {

            return View();
        }
        [HttpGet]
        public IActionResult AgregarProducto(entDetalleTransaccion detalle)
        {
            lsDetalleProducto.Add(detalle);
            return View();
        }
        [HttpPost]
        public IActionResult GuardarTransaccion()
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
