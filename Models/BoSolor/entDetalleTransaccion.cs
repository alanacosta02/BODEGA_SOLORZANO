namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entDetalleTransaccion
    {
        public entTransacción Transaccion { get; set; }
        public entProducto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    }
}
