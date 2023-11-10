using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BODEGA_SOLORZANO.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly logPedido _datosPedido = new logPedido();
        List<entDetalleTransaccion> lsDetalleProducto = new();
        public PedidoController(IWebHostEnvironment environment)
        {
            _environment = environment ;
        }

        public IActionResult Index()
        {
            var listaPedidos = _datosPedido.ListarPedido();
            return View(listaPedidos);
        }

        public IActionResult Pendientes()
        {
            return View();
        }
        public IActionResult Entregados()
        {
            return View();
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
        [HttpPost]
        public IActionResult Guardar(entPedido pedido, int idCliente, int idEstado,int idRepartidor,int idTransaccion )
        {
          
                entCliente cliente = new entCliente();
                entTransacción tra = new entTransacción();

                cliente.idCliente = idCliente;
                tra.IdTransaccion = idTransaccion;

                pedido.IdCliente = cliente;

                pedido.IdTransaccion = tra;

                var respuesta = _datosPedido.CrearPedido(pedido);
                if (respuesta)
                {
                    return RedirectToAction("Listar");
                }

            
               return View();
        }
        [HttpGet]
        public IActionResult AgregarProducto(entDetalleTransaccion detalle)
        {
            lsDetalleProducto.Add(detalle);
            return View();
        }
        [HttpPost]
        public IActionResult GuardarTransaccion()
        {
            return View();
        }

    }
}
