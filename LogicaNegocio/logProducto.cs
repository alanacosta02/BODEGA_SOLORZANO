using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logProducto
    {
        public static logProducto Instancia { get; } = new logProducto();

        #region CRUD
        public bool CrearProducto(entProducto prod)
        {
            return datProducto.Instancia.CrearProducto(prod);
        }
        public List<entProducto> ListarProductos()
        {
          return datProducto.Instancia.ListarProductos();
            
        }
        public bool ActualizarProducto(entProducto prod)
        {
            return datProducto.Instancia.ActualizarProducto(prod);
        }
        public bool EliminarProducto(int id)
        {
            try
            {
                return datProducto.Instancia.EliminarProducto(id);
            }
            catch (Exception e)
            {
                throw new Exception("El producto no se puede eliminar", e);
            }
        }
        #endregion CRUD

        public entProducto BuscarProductoId(int prod)
        {
            return datProducto.Instancia.BuscarProductoId(prod);
        }
    }
}
