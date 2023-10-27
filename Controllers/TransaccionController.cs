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
            logCuenta logCuenta = new logCuenta();
            logCliente cli = new logCliente();
            // Debug or log information about the lists
            var metodosPagoList = met.ListarMetodosPago() ?? new List<entMetodoPago>();
            var cuentasList = logCuenta.ListarCuenta() ?? new List<entCuenta>();
            var ClienteList = cli.ListarClientes() ?? new List<entCliente>();

            // Check the data in the Output or log
            // Console.WriteLine($"MetodosPago Count: {metodosPagoList.Count}");
            // Console.WriteLine($"Cuentas Count: {cuentasList.Count}");

            ViewBag.MetodosPago = metodosPagoList;
            ViewBag.Cuentas = cuentasList;
            ViewBag.Cliente = ClienteList;
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(entTransacción transacción, int Cliente, int Metodo, int cuenta, int Monto, int descuento)
        {
            if (ModelState.IsValid)
            {
                entCliente EntCliente = new entCliente();   
                entMetodoPago   EntmetodoPago = new entMetodoPago();
                entCuenta Entcuenta = new entCuenta();
              
                EntCliente.idCliente = Cliente;
                EntmetodoPago.IdMetodo = Metodo;
                Entcuenta.IdCuenta = cuenta;


                transacción.IdPersona = EntCliente;
                transacción.IdMetodo = EntmetodoPago;
                transacción.IdCuenta = Entcuenta;

                decimal Descuento = descuento / (100);
                decimal Total = Monto - Descuento;

                transacción.Descuento = Descuento;
                transacción.MontoTotal = Total;

                var respuesta=true ; //= _datosProveedorProducto.CrearProveedorProductos(proveedorProducto);

                if (respuesta)
                {
                    return RedirectToAction("Listar");
                }
            }
            // En caso de que ModelState.IsValid sea falso, regresa la vista actual con el modelo
            return View();
        }
    }
}
