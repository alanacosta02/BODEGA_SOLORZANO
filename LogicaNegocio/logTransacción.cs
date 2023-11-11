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
        public bool CrearTransaccion(List<entCarrito> lsCarrito, string tipoTransaccion)
        {
            try
            {
                List<entDetalleTransaccion> lsProducto = new List<entDetalleTransaccion>();
                var transaccion = new entTransacción();
                transaccion.CodTransaccion = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
                transaccion.TipoTransaccion = tipoTransaccion;
                transaccion.Descuento = 0;

                int id = 0;
                //id = datTransaccion.Instancia.CrearTranssacion(trans);

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

        private bool CrearDetalleCompra(List<entDetalleTransaccion> lsProducto)
        {
            return datTransaccion.Instancia.CrearDetalleTransaccion(lsProducto);
        }
    }
}
