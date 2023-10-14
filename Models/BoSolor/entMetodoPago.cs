namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entMetodoPago
    {
        public int IdMetodo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
