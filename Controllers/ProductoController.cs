using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IWebHostEnvironment _environment; // Esto se usa para obtener la ruta del directorio de contenido web
        public ProductoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        private readonly logProducto _datos = new logProducto();

        public IActionResult Listar()
        {
            var listaCategorias = _datos.ListarProductos();
            return View(listaCategorias);
        }
        public IActionResult Guardar()
        {
            logCategoria cat = new logCategoria();
            ViewBag.Categorias = cat.ListarCategoria() ?? new List<entCategoria>();

            return View();  
        }
        [HttpPost]

        public IActionResult Guardar(entProducto Producto,int categoria, IFormFile RutaImagen)
        {
            if (RutaImagen != null && RutaImagen.Length > 0)
            {
                // Define la ruta donde se guardará la imagen dentro de wwwroot
                var rutaDeGuardado = Path.Combine(_environment.WebRootPath, "images/Productos", RutaImagen.FileName);

                using (var stream = new FileStream(rutaDeGuardado, FileMode.Create))
                {
                    RutaImagen.CopyTo(stream);
                }

                Producto.Imagen = "/Imagenes/Productos/" + RutaImagen.FileName;
            }
            entCategoria cat = new entCategoria();
            cat.IdCategoria= categoria;
            Producto.IdCategoria = cat;

            var respuesta = _datos.CrearProducto(Producto);

            if (respuesta)
            {

                return RedirectToAction("Listar");

            }

            // En caso de que ModelState.IsValid sea falso, regresa la vista actual con el modelo
            return View();
        }

    }
}
