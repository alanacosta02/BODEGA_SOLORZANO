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

        public bool CrearTranssacion (entTransacción transaccion)
        {
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spIniciarTransaccion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codTransaccion", transaccion.CodTransaccion);
                cmd.Parameters.AddWithValue("@tipoTransaccion", transaccion.TipoTransaccion);
                cmd.Parameters.AddWithValue("@montoBruto", transaccion.MontoBruto);
                cmd.Parameters.AddWithValue("@descuento", transaccion.Descuento);
                cmd.Parameters.AddWithValue("@montoTotal", transaccion.MontoTotal);
                cmd.Parameters.AddWithValue("@estadoTransaccion", transaccion.EstadoTransaccion);
                cmd.Parameters.AddWithValue("@idPersona", transaccion.IdPersona.idCliente);
                cmd.Parameters.AddWithValue("@idMetodo", transaccion.IdMetodo.IdMetodo);
                cmd.Parameters.AddWithValue("@idCuenta", transaccion.IdCuenta.IdCuenta);


                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    creado = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

            return creado;
        }

    }
}
    