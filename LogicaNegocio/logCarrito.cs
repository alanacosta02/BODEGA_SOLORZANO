using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logCarrito
    {
        public static logCarrito Instancia { get; } = new();

        public List<entCarrito> lsCarrito = new();
        private int idCarrito = 0;

        public bool AgregarCarrito(entCarrito carrito)
        {
            try
            {
                carrito.IdCarrito = ++idCarrito;
                foreach (var item in lsCarrito)
                {
                    if (item.IdProducto == carrito.IdProducto)
                    {
                        throw new Exception("El producto ya existe en el carrito");
                    }
                }
                lsCarrito.Add(carrito);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<entCarrito> ListarCarrito(int idUsuario)
        {
            return lsCarrito.Where(c => c.IdUsuario == idUsuario).ToList();
        }

        public bool ActualizarCarrito(entCarrito carrito)
        {
            try
            {
                foreach (var item in lsCarrito)
                {
                    if (item.IdCarrito == carrito.IdCarrito)
                    {
                        item.Cantidad = carrito.Cantidad;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EliminarCarrito(int id)
        {
            try
            {
                lsCarrito.Remove(lsCarrito.Where(c => c.IdCarrito == id).FirstOrDefault());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public entCarrito BuscarProductoCarrito(string producto)
        {
            return lsCarrito.Where(c => c.Producto == producto).FirstOrDefault();
        }
    }
}
