using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logTransacción
    {
        public static logTransacción Instancia = new logTransacción();

       

        public List<entTransacción> ListarTransacciones()
        {
            return datTransaccion.Instancia.ListarTransacciones();
        }

     

    }
}
