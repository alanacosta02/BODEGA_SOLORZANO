namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entCliente
    {
        private int idCliente;
        private string nombres;
        private string apellidos;
        private string numDocumento;

        #region Get and Set
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string NumDocumento
        {
            get { return numDocumento; }
            set { numDocumento = value; }
        }
        #endregion
    }
}
