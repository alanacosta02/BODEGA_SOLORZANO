using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logCategoria
    {
        public static logCategoria Instancia = new ();


        #region CRUD
        public bool CrearCategoria(entCategoria cat)
        {
            return datCategoria.Instancia.CrearCategoria(cat);
        }
        public List<entCategoria> ListarCategoria()
        {
            return datCategoria.Instancia.ListarCategoria();
        }
        public bool ActualizarCategoria(entCategoria cat)
        {
            return datCategoria.Instancia.ActualizarCategoria(cat);
        }
        public bool DeshabilitarCategoria(int id)
        {
            return datCategoria.Instancia.DeshabilitarCategoria(id);
        }
        #endregion CRUD
        public List<entCategoria> BuscarCategoria(string busqueda)
        {
            return datCategoria.Instancia.BuscarCategoria(busqueda);
        }
        public entCategoria BuscarIdCategoria(int idCategoria)
        {
            return datCategoria.Instancia.BuscarIdCategoria(idCategoria);
        }
    }
}
