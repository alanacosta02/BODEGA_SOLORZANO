using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;
namespace BODEGA_SOLORZANO.LogicaNegocio
{
    
       public class logCliente
        {
            public static logCliente Instancia = new();

            public bool CrearCliente(entCliente cliente)
            {
                return datCliente.instancia.CrearCliente(cliente);
            }

            public List<entCliente> ListarClientes()
            {
                return datCliente.instancia.ListarClientes();
            }

            public bool ActualizarCliente(entCliente cliente)
            {
                return datCliente.instancia.ActualizarCliente(cliente);
            }
        }
 
}
