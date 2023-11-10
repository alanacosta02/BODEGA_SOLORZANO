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
        public bool CrearTransaccion(entTransacción trans, List<entDetalleTransaccion> lsProducto)
        {
            try
            {
                if (trans == null)
                {
                       throw new ArgumentException("La transaccion no puede ser nula");
                }
                if (lsProducto == null)
                {
                    throw new ArgumentException("La lista de productos no puede ser nula");
                }
                if (lsProducto.Count == 0)
                {
                    throw new ArgumentException("La lista de productos no puede estar vacia");
                }
                if (trans.TipoTransaccion != "Compra" || trans.TipoTransaccion != "Venta" || trans.TipoTransaccion != "Pedido")
                {
                    throw new ArgumentException("El tipo de transaccion no es valido");
                }

                int id = 0;
                id = datTransaccion.Instancia.CrearTranssacion(trans);

                if (id > 0)
                {
                    foreach (var item in lsProducto)
                    {
                        bool exito = CrearDetalleCompra(lsProducto);
                        if (!exito)
                        {
                            throw new Exception($"Error al crear el detalle del producto con id: {item.IdProducto}");
                        }
                    }
                }
                else
                {
                    throw new Exception("No se pudo crear la transaccion");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public bool CrearDetalleCompra(List<entDetalleTransaccion> lsProducto)
        {
            return datTransaccion.Instancia.CrearDetalleTransaccion(lsProducto);
        }
    }
}
