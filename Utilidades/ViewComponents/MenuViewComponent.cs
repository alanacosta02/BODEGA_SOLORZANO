using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BODEGA_SOLORZANO.Models.BoSolor;
using BODEGA_SOLORZANO.LogicaNegocio;

namespace SISTEMA_WEB.Utilidades.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            List<entMenu> listaMenus;

            if (claimUser.Identity.IsAuthenticated)
            {
                string idRol = claimUser.Claims.Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .SingleOrDefault();
                listaMenus = logMenu.Instancia.MostrarMenu(Convert.ToInt32(idRol));
                string userName = claimUser.Claims.Where(c => c.Type == ClaimTypes.Name).ToString();
                ViewBag.NombreUsuario = userName;
            }
            else
            {
                listaMenus = new List<entMenu> { };
            }
            return View(listaMenus);

        }
    }
}
