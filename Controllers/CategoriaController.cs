using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.Controllers
{

    public class CategoriaController : Controller
    {
        private readonly IWebHostEnvironment _environment; // Esto se usa para obtener la ruta del directorio de contenido web
        public CategoriaController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        private readonly logCategoria _datosCategoria = new logCategoria();

        public IActionResult Listar()
        {
            var listaCategorias = _datosCategoria.ListarCategoria();
            return View(listaCategorias);
        }

        public IActionResult Guardar()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(entCategoria categoria)
        {
            var respuesta = _datosCategoria.CrearCategoria(categoria);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            return View();

        }
    }
}
