using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logProveedor
    {
        public static logProveedor Instancia = new ();


        #region CRUD
        public bool CrearProveedor(entProveedor pro)
        {
            return datProveedor.Instancia.CrearProveedor(pro);
        }
        public List<entProveedor> ListarProveedor()
        {
            return datProveedor.Instancia.ListarProveedor();

        }
        public bool ActualizarProveedor(entProveedor pro)
        {
            return datProveedor.Instancia.ActualizarProveedor(pro);
        }
        public bool DeshabilitarProveedor(int id)
        {
            return datProveedor.Instancia.DeshabilitarProveedor(id);
        }
        #endregion CRUD
        public List<entProveedor> BuscarProveedor(string busqueda)
        {
            return datProveedor.Instancia.BuscarProveedor(busqueda);
        }
        public entProveedor BuscarIdProveedor(int idProveedor)
        {
            return datProveedor.Instancia.BuscarIdProveedor(idProveedor);
        }
    }
}
