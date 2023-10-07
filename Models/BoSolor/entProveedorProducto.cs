namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entProveedorProducto
    {
        private int idProveedorProducto;
        private entProveedor proveedor;
        private entProducto producto;
        private double precioCompra;
        
        #region Get and Set
        public int IdProveedorProducto
        {
            get { return idProveedorProducto; }
            set { idProveedorProducto = value; }
        }

        public entProveedor Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        public entProducto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public double PrecioCompra
        {
            get { return precioCompra; }
            set { precioCompra = value; }
        }
        #endregion
    }

}
