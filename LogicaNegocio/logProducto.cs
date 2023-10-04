using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logProducto
    {
        public static logProducto Instancia = new ();

        #region CRUD
        public bool CrearProducto(entProducto prod)
        {
            return datProducto.Instancia.CrearProducto(prod);
        }
        public List<entProducto> ListarProductos(string busqueda, string orden)
        {
            try
            {
                switch (orden)
                {
                    case "asc": return datProducto.Instancia.Ordenar(1);
                    case "desc": return datProducto.Instancia.Ordenar(2);
                    default:
                        break;
                }
                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    return datProducto.Instancia.ListarProductos();
                }
                else
                {
                    return datProducto.Instancia.BuscarProducto(busqueda);
                }
            }
            catch
            {
                throw new Exception("Algo salio mal durante el proceso");
            }
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
