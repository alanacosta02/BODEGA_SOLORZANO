using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logCuenta
    {
        public static logCuenta Instancia = new();
        public bool CrearCuenta(entCuenta cuenta)
        {
            return datCuenta.Instancia.CrearCuenta(cuenta);
        }
        public List<entCuenta> ListarCuenta()
        {
            return datCuenta.Instancia.ListarCuentas();
        }
        public bool ActualizarCuenta(entCuenta cuenta)
        {
            return datCuenta.Instancia.ActualizarCuenta(cuenta);
        } 
    }
}
