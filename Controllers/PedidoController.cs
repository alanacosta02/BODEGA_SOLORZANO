using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly logPedido _datosPedido = new logPedido();

        public PedidoController(IWebHostEnvironment environment)
        {
            _environment = environment ;
        }

        public IActionResult Listar()
        {
            var listaPedidos = _datosPedido.ListarPedido();
            return View(listaPedidos);
        }
        public IActionResult Guardar()
        {
       
            logCliente cli = new logCliente();
            logTransacción tra =new logTransacción();
            logEstadoPedido es = new logEstadoPedido();
            logCuenta Cuenta = new logCuenta();


            ViewBag.Cuentas = Cuenta.ListarCuentaRepartidor()?? new List<entCuenta>();
            ViewBag.Cliente = cli.ListarClientes() ?? new List<entCliente>();
            ViewBag.transaccion =tra.ListarTransacciones() ?? new List<entTransacción>();
            ViewBag.estado = es.ListarEstadosPedido() ?? new List<entEstadoPedido>();
         

            return View();
        }
    }
}
