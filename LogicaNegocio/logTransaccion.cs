using BODEGA_SOLORZANO.Models.BoSolor;
using BODEGA_SOLORZANO.Datos;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logTransaccion
    {
        public static logTransaccion Instancia { get; } = new();

        //public bool RegistrarTransaccion(entTransaccion transaccion, List<entProducto> lsProducto, int idUser)
        //{
        //    int idTransaccion = 0;
        //    bool registrado = datTransaccion.Instancia.RegistrarTransaccion(transaccion, out idTransaccion, idUser);

        //    if (registrado)
        //    {
        //        foreach (var item in lsProducto)
        //        {

        //            bool creado = datTransaccion.Instancia.RegistrarDetalleTransaccion(lsProducto, idTransaccion);
        //        }
        //    }
        //}
    }
}
