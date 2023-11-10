using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BODEGA_SOLORZANO.Controllers
{
    [Authorize]
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

        //[HttpPost]
        //public IActionResult Guardar(entTransacción transacción, int Cliente, int Metodo, decimal Monto, decimal descuento)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        ClaimsPrincipal claimUser = HttpContext.User;
        //        int idCuenta = Convert.ToInt32(claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
        //            .Select(c => c.Value).SingleOrDefault());


        //        entCliente EntCliente = new entCliente();
        //        entMetodoPago EntmetodoPago = new entMetodoPago();
        //        entCuenta Entcuenta = new entCuenta();

        //        EntCliente.idCliente = Cliente;
        //        EntmetodoPago.IdMetodo = Metodo;
        //        Entcuenta.IdCuenta = idCuenta;


        //        transacción.IdPersona = EntCliente;
        //        transacción.IdMetodo = EntmetodoPago;
        //        transacción.IdCuenta = Entcuenta;
        //        transacción.MontoBruto = Monto;

        //        decimal Descuento = descuento / 100;
        //        decimal Total = Monto - Descuento;

        //        transacción.Descuento = Descuento;
        //        transacción.MontoTotal = Total;
        //        transacción.EstadoTransaccion = "EN ESPERA";
        //        var respuesta = _datos.CrearTransaccion(transacción);

        //        if (respuesta)
        //        {
        //            return RedirectToAction("Listar");
        //        }
        //    }
        //   return View();
        //}
    }
}
