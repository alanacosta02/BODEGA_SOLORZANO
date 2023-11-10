using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    [Authorize]
    public class CompraController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public CompraController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        List<entDetalleTransaccion> lsDetalleProducto = new();
        private readonly logTransacción _datos = new logTransacción();
        public IActionResult Index()
        {
            var listar = _datos.ListarTransacciones();
            return View(listar);
        }


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

        public IActionResult Reporte()
        {
            return View();
        }


    }
}
