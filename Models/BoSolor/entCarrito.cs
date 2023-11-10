namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entCarrito
    {
        public int IdCarrito { get; set; }
        public int IdProducto { get; set; } = 0;
        public string Producto { get; set; } = null!;
        public int IdUsuario { get; set; } = 0;
        public int Cantidad { get; set; } = 0;
    }
}
