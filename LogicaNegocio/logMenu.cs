using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logMenu
    {
        public static logMenu Instancia { get; } = new();
        public List<entMenu> MostrarMenu(int numRol)
        {
            List<entMenu> lsMenuPadre = datMenu.Instancia.MostrarMenu(numRol, "PADRE");
            List<entMenu> lsMenuHijo = datMenu.Instancia.MostrarMenu(numRol, "HIJO");
            List<entMenu> lista = new List<entMenu>();

            foreach (var item in lsMenuPadre)
            {
                entMenu menu = new entMenu();
                menu.IdMenu = item.IdMenu;
                menu.Nombre = item.Nombre;
                menu.Icono = item.Icono;
                menu.Controlador = item.Controlador;
                menu.PaginaAccion = item.PaginaAccion;
                menu.IdMenuPadre = item.IdMenuPadre;
                menu.ListaMenu = new List<entMenu>();

                foreach (var itemHijo in lsMenuHijo)
                {
                    if (item.IdMenu == itemHijo.IdMenuPadre)
                    {
                        entMenu menuHijo = new entMenu();
                        menuHijo.IdMenu = itemHijo.IdMenu;
                        menuHijo.Nombre = itemHijo.Nombre;
                        menuHijo.Icono = itemHijo.Icono;
                        menuHijo.Controlador = itemHijo.Controlador;
                        menuHijo.PaginaAccion = itemHijo.PaginaAccion;
                        menuHijo.IdMenuPadre = itemHijo.IdMenuPadre;
                        menu.ListaMenu.Add(menuHijo);
                    }
                }
                lista.Add(menu);
            }

            return lista;
        }
    }
}
