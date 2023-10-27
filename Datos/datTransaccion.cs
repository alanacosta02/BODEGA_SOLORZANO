using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;

namespace BODEGA_SOLORZANO.Datos
{
    public class datTransaccion
    {
        public static datTransaccion Instancia { get; } = new();

        public List<entTransacción> ListarTransacciones()
        {

            List<entTransacción> lista = new List<entTransacción>();
            SqlCommand cmd = null;

            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spListarTransaccionVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entCuenta cuenta  = new entCuenta
                    {
                        Correo = dr["usuarios"].ToString(),
                        // Otros campos de la entidad metodoPago
                    };


                    entMetodoPago metodoPago = new entMetodoPago
                    {
                        Nombre = dr["metodo"].ToString(),
                        // Otros campos de la entidad metodoPago
                    };
                    entCliente cliente = new entCliente
                    {
                        nombres = dr["clientes"].ToString(),
                        // Otros campos de la entidad metodoPago
                    };
                    entTransacción transaccion = new entTransacción
                    {
                        IdTransaccion = Convert.ToInt32(dr["IdTransaccion"]),
                        CodTransaccion = dr["CodTransaccion"].ToString(),
                        MontoBruto = Convert.ToDecimal(dr["MontoBruto"]),
                        Descuento = Convert.ToDecimal(dr["Descuento"]),
                        MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                        FechaHora = Convert.ToDateTime(dr["FechaHora"]),
                        EstadoTransaccion = dr["EstadoTransaccion"].ToString(),
                        IdPersona = cliente,
                        IdMetodo = metodoPago,
                        IdCuenta = cuenta
                    };

                    lista.Add(transaccion);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (cmd != null && cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }

            return lista;
        }


    }
}
    