﻿namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entProveedor
    {
        private int idProveedor;
        private string razonSocial;
        private string numDocumento;
        private string telefono;
        private bool activo;

        #region Get and Set
        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }
        public string NumDocumento
        {
            get { return numDocumento; }
            set { numDocumento = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        #endregion
    }
}
