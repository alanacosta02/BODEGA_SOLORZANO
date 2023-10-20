using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logPedido
    {
        public static logPedido Instancia = new logPedido();

        
        public bool CrearPedido(entPedido pe)
        {
            return datPedidos.Instancia.CrearPedido(pe);
        }

        public List<entPedido> ListarPedido()
        {
            return datPedidos.Instancia.ListarPedidos();
        }
    }
}
