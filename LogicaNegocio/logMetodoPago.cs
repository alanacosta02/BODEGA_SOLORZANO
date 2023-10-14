using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logMetodoPago
    {
        public static logMetodoPago Instancia = new logMetodoPago();

        #region CRUD
        public bool CrearMetodoPago(entMetodoPago metodoPago)
        {
            return datMetodoPago.Instancia.CrearMetodoPago(metodoPago);
        }

        public List<entMetodoPago> ListarMetodosPago()
        {
            return datMetodoPago.Instancia.ListarMetodosPago();
        }

        public bool ActualizarMetodoPago(entMetodoPago metodoPago)
        {
            return datMetodoPago.Instancia.ActualizarMetodoPago(metodoPago);
        }

        public bool EliminarMetodoPago(int id)
        {
            try
            {
                return datMetodoPago.Instancia.EliminarMetodoPago(id);
            }
            catch (Exception e)
            {
                throw new Exception("El método de pago no se puede eliminar", e);
            }
        }
        #endregion CRUD

        
    }
}
