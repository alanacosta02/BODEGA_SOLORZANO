using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BODEGA_SOLORZANO.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly IWebHostEnvironment _environment; // Esto se usa para obtener la ruta del directorio de contenido web
        public ProductoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        private readonly logProducto _datos = new logProducto();

        public IActionResult Index()
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
            if (ModelState.IsValid)
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
                cat.IdCategoria = categoria;
                Producto.IdCategoria = cat;

                var respuesta = _datos.CrearProducto(Producto);

                if (respuesta)
                {

                    return RedirectToAction("Listar");

                }
            }
            // En caso de que ModelState.IsValid sea falso, regresa la vista actual con el modelo
            return View();
        }


        public IActionResult ProductosCompra()
        {
            List<entProveedorProducto> producto = logProveedorProducto.Instancia.ListarProductosCompra();
            return View(producto);
        }
        public IActionResult AgregarProductoCompra(int idProducto, string nombre, int cantidad)
        {
            try
            {             
                entCarrito carrito = new();
                carrito.IdProducto = idProducto;
                carrito.Producto = nombre;
                ClaimsPrincipal claimUser = HttpContext.User;
                string id = claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
                carrito.IdUsuario = Convert.ToInt32(id);
                carrito.Cantidad = cantidad;
                logCarrito.Instancia.AgregarCarrito(carrito);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("ProductosCompra");
        }
        public IActionResult ProductosVenta()
        {
            return View();
        }
        public IActionResult ProductosPedido()
        {
            return View();
        }

        public IActionResult CarritoCompra()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            string id = claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            var listaProductos = logCarrito.Instancia.ListarCarrito(Convert.ToInt32(id));
            return View(listaProductos);
        }
    }
}
