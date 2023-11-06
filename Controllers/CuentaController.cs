using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    [Authorize]
    public class CuentaController : Controller
    {
        private readonly IWebHostEnvironment _environment; // Esto se usa para obtener la ruta del directorio de contenido web

        private readonly logCuenta _datosCuenta = new logCuenta();

        public CuentaController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            var listaCuentas = _datosCuenta.ListarCuenta();
            return View(listaCuentas);
        }

        public IActionResult Listar()
        {
            var listaCuentas = _datosCuenta.ListarCuenta();
            return View(listaCuentas);
        }

        public IActionResult Guardar()
        {
            logRol cuenta = new logRol();
            ViewBag.Roles = cuenta.ListarRol() ?? new List<entRol>();
            return View();
        }

        public IActionResult Create()
        {
            logRol cuenta = new logRol();
            ViewBag.Roles = cuenta.ListarRol() ?? new List<entRol>();
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(entCuenta cuenta,int idroll)
        {
            entRol EntRol = new entRol();
           
            EntRol.IdRol = idroll;    

            cuenta.IdRol = EntRol;   

          
            var respuesta = _datosCuenta.CrearCuenta(cuenta);


            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            return View();
        }
    }
}
