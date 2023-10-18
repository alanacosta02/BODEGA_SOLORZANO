using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    [Authorize]
    public class ProveedorProductoController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public ProveedorProductoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        private readonly logProveedorProducto _datosProveedorProducto = new logProveedorProducto();

        public IActionResult Listar()
        {
            var listaProveedorProductos = _datosProveedorProducto.ListarProveedorProducto();
            return View(listaProveedorProductos);
        }

        public IActionResult Guardar()
        {
            // Obtener la lista de proveedores y productos necesarios para el formulario
            logProveedor logProveedor = new logProveedor();     
            logProducto logProducto = new logProducto();
            ViewBag.Proveedores = logProveedor.ListarProveedor();
            ViewBag.Productos = logProducto.ListarProductos();

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(entProveedorProducto proveedorProducto,int producto,int proveedor)
        {
            entProducto pro = new entProducto();
            entProveedor prov =  new entProveedor();

            pro.IdProducto = producto;
            prov.IdProveedor = proveedor;

            proveedorProducto.Producto = pro;
            proveedorProducto.Proveedor = prov;
           
            
            var respuesta = _datosProveedorProducto.CrearProveedorProductos(proveedorProducto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }

            // En caso de que ModelState.IsValid sea falso, regresa la vista actual con el modelo
            return View();
        }

    }
}
