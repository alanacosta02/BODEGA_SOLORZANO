namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entCuenta
    {
        public int IdCuenta { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; } // DateTime? para permitir valores nulos
        public entRoll IdRol { get; set; }
    }
}
