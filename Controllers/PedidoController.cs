using BODEGA_SOLORZANO.LogicaNegocio;
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
    }
}
