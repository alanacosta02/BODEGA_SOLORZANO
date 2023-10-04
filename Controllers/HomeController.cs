using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.LogicaNegocio;
using BODEGA_SOLORZANO.Models.BoSolor;
using BODEGA_SOLORZANO.Models.ViewModel;
using BODEGA_SOLORZANO.Permisos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BODEGA_SOLORZANO.Extenciones;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualBasic;
using System.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace BODEGA_SOLORZANO.Controllers
{
    public class HomeController : Controller
    {
        public static logUsuario Instancia = new();

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Vistas


        [PermisosRol(entRol.Administrador)]
        [Authorize]// No puede si es que no esta autorizado //Almacena la info en la memoria del navegador
        public IActionResult Admin()
        {
            // Almacenar objeto en la sesión
            var cliente = new entUsuario { UserName = "Nombre del Usuario" };
            HttpContext.Session.SetObject("Usuario", cliente);

            // Recuperar objeto de la sesión
            var usuarioGuardado = HttpContext.Session.GetObject<entUsuario>("Usuario");

            if (usuarioGuardado != null)
            {
                ViewBag.Usuario = usuarioGuardado.UserName;
                return View();
            }

            return RedirectToAction("Index");
        }

        [PermisosRol(entRol.Jefe)]
        [Authorize]// No puede si es que no esta autorizado
        public IActionResult Jefe()
        {
            if (HttpContext.Session.TryGetValue("Usuario", out byte[] usuarioBytes))
            {
                var usuarioJson = Encoding.UTF8.GetString(usuarioBytes);
                var cliente = JsonConvert.DeserializeObject<entUsuario>(usuarioJson);
                ViewBag.Usuario = cliente.UserName;
                return View();
            }

            return RedirectToAction("Index");
        }

        [PermisosRol(entRol.Compras)]
        [Authorize]// No puede si es que no esta autorizado //Almacena la info en la memoria del navegador
        public IActionResult Compras()
        {
            // Almacenar objeto en la sesión
            var cliente = new entUsuario { UserName = "Nombre del Usuario" };
            HttpContext.Session.SetObject("Usuario", cliente);

            // Recuperar objeto de la sesión
            var usuarioGuardado = HttpContext.Session.GetObject<entUsuario>("Usuario");

            if (usuarioGuardado != null)
            {
                ViewBag.Usuario = usuarioGuardado.UserName;
                return View();
            }

            return RedirectToAction("Index");
        }

        [PermisosRol(entRol.Ventas)]
        [Authorize]// No puede si es que no esta autorizado //Almacena la info en la memoria del navegador
        public IActionResult Ventas()
        {
            // Almacenar objeto en la sesión
            var cliente = new entUsuario { UserName = "Nombre del Usuario" };
            HttpContext.Session.SetObject("Usuario", cliente);

            // Recuperar objeto de la sesión
            var usuarioGuardado = HttpContext.Session.GetObject<entUsuario>("Usuario");

            if (usuarioGuardado != null)
            {
                ViewBag.Usuario = usuarioGuardado.UserName;
                return View();
            }

            return RedirectToAction("Index");
        }

        [PermisosRol(entRol.Pedidos)]
        [Authorize]// No puede si es que no esta autorizado //Almacena la info en la memoria del navegador
        public IActionResult Pedidos()
        {
            // Almacenar objeto en la sesión
            var cliente = new entUsuario { UserName = "Nombre del Usuario" };
            HttpContext.Session.SetObject("Usuario", cliente);

            // Recuperar objeto de la sesión
            var usuarioGuardado = HttpContext.Session.GetObject<entUsuario>("Usuario");

            if (usuarioGuardado != null)
            {
                ViewBag.Usuario = usuarioGuardado.UserName;
                return View();
            }

            return RedirectToAction("Index");
        }


        public ActionResult SinPermisos()
        {
            ViewBag.Message = "Usted no tiene permisos para acceder a esta pagina";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        #endregion Vistas

        #region Acceso, Crear cuenta
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerificarAcceso(string user, string pass)
        {
            try
            {
                entUsuario objCliente = logUsuario.Instancia.IniciarSesion(user, pass);
                if (objCliente != null)
                {
                    //var claims = new List<Claim>
                    //{
                    //    new Claim(ClaimTypes.Name, objCliente.UserName),
                    //    new Claim(ClaimTypes.Role, objCliente.Rol.ToString())
                    //};

                    //var claimsIdentity = new ClaimsIdentity(
                    //    claims, CookieAuthenticationDefaults.AuthenticationScheme);



                    //await HttpContext.SignInAsync(
                    //    CookieAuthenticationDefaults.AuthenticationScheme,
                    //    new ClaimsPrincipal(claimsIdentity));

                    // Almacena el objeto de usuario en la sesión si lo necesitas
                    //HttpContext.Session.Set<entUsuario>("Usuario", objCliente);

                    if (objCliente.Rol == entRol.Administrador)
                    {
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    TempData["Restablecer"] = "¿Olvidaste tu contraseña?";
                    TempData["Mensaje"] = "Usuario o contraseña incorrectos";
                    return RedirectToAction("Login");
                }
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Error");
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearSesionUsuario(string user, string correo, string pass, string confirmPass)
        {
            try
            {
                if (pass == confirmPass)
                {
                    List<string> errores = new List<string>();
                    bool creado = logUsuario.Instancia.CrearSesionUsuario(user, correo, pass, out errores);

                    if (creado)
                    {
                        return RedirectToAction("Index"); // Redireccionar al método "Index" si el usuario se creó correctamente
                    }
                    else
                    {
                        foreach (var error in errores)
                        {
                            TempData["Error"] += error; // Agregar mensajes de error al TempData
                        }

                        return RedirectToAction("Error"); // Redireccionar al método "Error" si ocurrió un error en la creación del usuario
                    }
                }
                else
                {
                    TempData["Error"] = "Las contraseñas no coinciden"; // Establecer un mensaje de error en TempData
                    return RedirectToAction("Error"); // Redireccionar al método "Error" si las contraseñas no coinciden
                }
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message; // Establecer un mensaje de error en TempData
                return RedirectToAction("Error"); // Redireccionar al método "Error" si ocurrió una excepción
            }
        }
        #endregion

        #region Otros

        [HttpGet]
        public ActionResult RestablecerPassword()
        {
            return View();
        }

        //public static bool enviado = false;
        //private static string correoValidado = string.Empty;
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RestablecerPassword(string correo, string newPassword, string codigo)
        //{
        //    string msjCorreoEnviado = $"Se ha enviado un correo electrónico a {correo} con instrucciones para restablecer su contraseña. Por favor, revise su bandeja de entrada y siga los pasos indicados en el correo electrónico para completar el proceso de restablecimiento de contraseña. Si no encuentra el correo electrónico, revise su carpeta de correo no deseado o spam.";
        //    string msjCodigoNoEnviado = "El correo no se pudo enviar a la direccion proporcionada";
        //    try
        //    {
        //        // Aún no se envio el codigo al correo
        //        if (!enviado)
        //        {
        //            // Intentar enviar el codigo de restablecimiento
        //            enviado = logUsuario.Instancia.EnviarCodigoRestablecerPass(correo);
        //        }
        //        else
        //        {
        //            // Seguir mostrando el mensaje
        //            TempData["TipoAlerta"] = "success";
        //            TempData["ContenidoAlerta"] = msjCorreoEnviado;

        //            // Verificar que se ingreso el codigo y la nueva contraseña
        //            if (!string.IsNullOrWhiteSpace(newPassword) && !string.IsNullOrWhiteSpace(codigo))

        //            {
        //                // Restablecer los datos con las con las credenciales
        //                bool restablecer = _logUsuario.RestablecerPassword(newPassword, codigo);
        //                if (restablecer)
        //                {
        //                    return RedirectToAction("Index");
        //                }
        //                else
        //                {
        //                    return View();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        TempData["TipoAlerta"] = "danger";
        //        TempData["ContenidoAlerta"] = e.Message;
        //    }
        //    return View();
        //}

        // Una sesion almacena toda la informacion de un objeto en el lado del servidor
        //public ActionResult Error()
        //{
        //    string mensaje = TempData["Error"] as string;
        //    TempData["Error"] = null; // Limpiar el mensaje de error de la TempData
        //    ViewBag.Error = mensaje;
        //    return View();
        //}

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // No necesitas limpiar la sesión en ASP.NET Core ya que no usamos Session["Usuario"]

            return RedirectToAction("Index");
        }
        #endregion
    }
}
