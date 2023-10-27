namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entPedido
    {
        public int IdPedido { get; set; }
        public string DireccionEntrega { get; set; }
        public string Referencia { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public entCliente IdCliente { get; set; }
        public entTransacción IdTransaccion { get; set; }
        public entEstadoPedido IdEstadoPedido { get; set; }
        public entCuenta IdRepartidor { get; set; }
    }
}
