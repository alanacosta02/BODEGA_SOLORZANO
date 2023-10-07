namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entTransaccion
    {
        private int idTransaccion;
        private string codTransaccion;
        private string tipoTransaccion;
        private double montoBruto;
        private double descuento;
        private double montoTotal;
        private DateTime fechaHora;
        private bool estadoTransaccion;
        private entCliente idCliente;
        private entProveedor idProveedor;
        private entMetodoPago idMetodo;
        private entUsuario idUsuario;

        public int IdTransaccion { get => idTransaccion; set => idTransaccion = value; }
        public string CodTransaccion { get => codTransaccion; set => codTransaccion = value; }
        public string TipoTransaccion { get => tipoTransaccion; set => tipoTransaccion = value; }
        public double MontoBruto { get => montoBruto; set => montoBruto = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public double MontoTotal { get => montoTotal; set => montoTotal = value; }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public bool EstadoTransaccion { get => estadoTransaccion; set => estadoTransaccion = value; }
        public entCliente IdCliente{ get => idCliente; set => idCliente = value; }
        public entProveedor IdProveedor { get => idProveedor; set => idProveedor = value; }
        public entUsuario IdUsuario { get => idUsuario; set => idUsuario = value; }
        public entMetodoPago IdMetodo { get => idMetodo; set => idMetodo = value; }

    }
}
