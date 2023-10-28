using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
   // [Authorize]
    public class TransaccionController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public TransaccionController(IWebHostEnvironment environment)
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
            logCuenta Cuenta = new logCuenta();
            logCliente cli = new logCliente();
      
            ViewBag.MetodosPago = met.ListarMetodosPago() ?? new List<entMetodoPago>(); 
            ViewBag.Cuentas = Cuenta.ListarCuenta() ?? new List<entCuenta>(); 
            ViewBag.Cliente = cli.ListarClientes() ?? new List<entCliente>(); 
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(entTransacción transacción, int Cliente, int Metodo, int cuenta, decimal Monto, decimal descuento)
        {

            if (ModelState.IsValid)
            {

                entCliente EntCliente = new entCliente();
                entMetodoPago EntmetodoPago = new entMetodoPago();
                entCuenta Entcuenta = new entCuenta();

                EntCliente.idCliente = Cliente;
                EntmetodoPago.IdMetodo = Metodo;
                Entcuenta.IdCuenta = cuenta;


                transacción.IdPersona = EntCliente;
                transacción.IdMetodo = EntmetodoPago;
                transacción.IdCuenta = Entcuenta;
                transacción.MontoBruto = Monto;

                decimal Descuento = descuento / 100;
                decimal Total = Monto - Descuento;

                transacción.Descuento = Descuento;
                transacción.MontoTotal = Total;
                transacción.EstadoTransaccion = "EN ESPERA";
                var respuesta = _datos.CrearTransaccions(transacción);

                if (respuesta)
                {
                    return RedirectToAction("Listar");
                }
            }
           return View();
        }
    }
}
