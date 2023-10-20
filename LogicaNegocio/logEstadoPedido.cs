using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logEstadoPedido
    {
        public static logEstadoPedido Instancia = new logEstadoPedido();

        #region CRUD para entEstadoPedido
        // Crear
        public bool CrearEstadoPedido(entEstadoPedido estadoPedido)
        {
            return datEstadoPedido.Instancia.CrearEstadoPedido(estadoPedido);
        }

        // Listar
        public List<entEstadoPedido> ListarEstadosPedido()
        {
            return datEstadoPedido.Instancia.ListarEstadosPedido();
        }

        // Actualizar
        public bool ActualizarEstadoPedido(entEstadoPedido estadoPedido)
        {
            return datEstadoPedido.Instancia.ActualizarEstadoPedido(estadoPedido);
        }

     
        #endregion CRUD para entEstadoPedido
    }
}
