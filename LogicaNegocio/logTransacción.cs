using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logTransacción
    {
        public static logTransacción Instancia = new logTransacción();

        #region CRUD
        public bool CrearTransaccion(entTransacción transaccion)
        {
            return datTransaccion.Instancia.CrearTransaccion(transaccion);
        }

        public List<entTransacción> ListarTransacciones()
        {
            return datTransaccion.Instancia.ListarTransacciones();
        }

        public bool ActualizarTransaccion(entTransacción transaccion)
        {
            return datTransaccion.Instancia.ActualizarTransaccion(transaccion);
        }

        public bool DeshabilitarTransaccion(int idTransaccion)
        {
            return datTransaccion.Instancia.DeshabilitarTransaccion(idTransaccion);
        }
        #endregion CRUD

    }
}
