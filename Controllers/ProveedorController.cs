using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IWebHostEnvironment _environment; // Esto se usa para obtener la ruta del directorio de contenido web
        public ProveedorController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        private readonly logProveedor _datos = new logProveedor();

        public IActionResult Listar()
        {
            var listaCategorias = _datos.ListarProveedor();
            return View(listaCategorias);
        }
        public IActionResult Guardar()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Guardar(entProveedor proveedor)
        {
            var respuesta = _datos.CrearProveedor(proveedor);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }

            return View(proveedor);
        }
    }
    
}
