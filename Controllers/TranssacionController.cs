using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    public class TranssacionController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public TranssacionController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        private readonly logTransacción _datos= new logTransacción();
        public IActionResult Listar()
        {
            var listar = _datos.ListarTransacciones();
            return View(listar);
        }
        public IActionResult Guardar()
        {
            logMetodoPago met = new logMetodoPago();
            logCuenta logCuenta = new logCuenta();

            // Debug or log information about the lists
            var metodosPagoList = met.ListarMetodosPago() ?? new List<entMetodoPago>();
            var cuentasList = logCuenta.ListarCuenta() ?? new List<entCuenta>();

            // Check the data in the Output or log
            // Console.WriteLine($"MetodosPago Count: {metodosPagoList.Count}");
            // Console.WriteLine($"Cuentas Count: {cuentasList.Count}");

            ViewBag.MetodosPago = metodosPagoList;
            ViewBag.Cuentas = cuentasList;


            return View();
        }
    }
}
