using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BODEGA_SOLORZANO.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        private readonly logCliente _datosCliente = new logCliente();

        public ClienteController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            var listaClientes = _datosCliente.ListarClientes();
            return View(listaClientes);
        }

        public IActionResult Listar()
        {
            var listaClientes = _datosCliente.ListarClientes();
            return View(listaClientes);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(entCliente cliente)
        {
            if (ModelState.IsValid)
            {
                // Lógica para validar y crear el cliente
                _datosCliente.CrearCliente(cliente);

                // Redireccionar a la acción de listar después de crear el cliente
                return RedirectToAction("Listar");
            }

            // Si el modelo no es válido, regresar a la vista de creación con errores
            return View(cliente);
        }

    }
}
