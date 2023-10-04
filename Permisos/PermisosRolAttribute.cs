using BODEGA_SOLORZANO.Models.BoSolor;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BODEGA_SOLORZANO.Datos;
using System.Text.Json;

namespace BODEGA_SOLORZANO.Permisos
{
    // Resumen:
    //      Valida que al momento que se ejecute una accion valida cierta acción.
    public class PermisosRolAttribute : ActionFilterAttribute //Le decimos que va a heredar de action filter
    {
        private entRol idRol;

        public PermisosRolAttribute(entRol idRol)
        {
            this.idRol = idRol;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Este método se ejecuta después de la acción del controlador.

            // Validar la sesión del usuario
            if (context.HttpContext.Session.TryGetValue("Usuario", out byte[] usuarioBytes))
            {
                // Deserializar el usuario desde los bytes de la sesión
                var usuario = JsonSerializer.Deserialize<entUsuario>(usuarioBytes);

                // Validar el rol del usuario
                if (usuario.Rol != idRol)
                {
                    context.Result = new RedirectToActionResult("NotFound", "Error", null);
                    // Con RedirectToActionResult, estamos redirigiendo a un método de un controlador específico.
                }
            }
            else
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}