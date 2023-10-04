namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entProducto
    {
        private int idProducto;
        private string nombre;
        private string descripcion;
        private string codigo;
        private int stock;
        private double precioVenta;
        private string imagen;
        private bool activo;
        private DateTime fechaCreacion;
        private entCategoria idCategoria;

        #region Get and Set
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public double PrecioVenta
        {
            get { return precioVenta; }
            set { precioVenta = value; }
        }
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        public entCategoria IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        #endregion

        public string mostrarDatos()
        {
            return nombre + " " + codigo + " " + stock + " " + precioVenta;
        }
    }
}
