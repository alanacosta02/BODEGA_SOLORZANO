using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    public class CuentaController : Controller
    {
        private readonly IWebHostEnvironment _environment; // Esto se usa para obtener la ruta del directorio de contenido web

        private readonly logCuenta _datosCuenta = new logCuenta();

        public CuentaController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Listar()
        {
            var listaCuentas = _datosCuenta.ListarCuenta();
            return View(listaCuentas);
        }

        public IActionResult Guardar()
        {
            logRoll cuenta = new logRoll();
            ViewBag.Roles = cuenta.ListarRol() ?? new List<entRoll>();
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(entCuenta cuenta,int idroll)
        {
            entRoll EntRoll = new entRoll();
           
            EntRoll.IdRoll = idroll;    

            cuenta.IdRol = EntRoll;   

          
            var respuesta = _datosCuenta.CrearCuenta(cuenta);


            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            return View();
        }
    }
}
