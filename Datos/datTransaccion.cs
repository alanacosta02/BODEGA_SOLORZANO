using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;
namespace BODEGA_SOLORZANO.Datos
{
    public class datTransaccion
    {

        public static datTransaccion Instancia = new datTransaccion();

        #region CRUD
        // Crear
        public bool CrearTransaccion(entTransacción transaccion)
        {
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearTransaccion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codTransaccion", transaccion.CodTransaccion);
                cmd.Parameters.AddWithValue("@tipoTransaccion", transaccion.TipoTransaccion);
                cmd.Parameters.AddWithValue("@montoBruto", transaccion.MontoBruto);
                cmd.Parameters.AddWithValue("@descuento", transaccion.Descuento);
                cmd.Parameters.AddWithValue("@montoTotal", transaccion.MontoTotal);
                cmd.Parameters.AddWithValue("@fechaHora", transaccion.FechaHora);
                cmd.Parameters.AddWithValue("@estadoTransaccion", transaccion.EstadoTransaccion);
                cmd.Parameters.AddWithValue("@idPersona", transaccion.IdPersona);
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

        // Leer
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
                    entCuenta cuenta = new entCuenta();
                    if (dr["cliente"] != DBNull.Value)
                    {
                        int idCuenta;
                        if (int.TryParse(dr["cliente"].ToString(), out idCuenta))
                        {
                            cuenta.IdCuenta = idCuenta;
                        }
                        else
                        {
                            // Maneja el error de conversión, por ahora, estableciendo un valor predeterminado
                            cuenta.IdCuenta = 0; // o cualquier valor predeterminado
                        }
                    }
                    // Establece otros campos en el objeto entCuenta

                    entMetodoPago metodoPago = new entMetodoPago
                    {
                        Nombre = dr["metodo"].ToString(),
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
                        IdPersona = dr["usuario"].ToString(),
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


        // Actualizar
        public bool ActualizarTransaccion(entTransacción transaccion)
        {
            SqlCommand cmd = null;
            bool actualiza = false;

            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spActualizarTransaccion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTransaccion", transaccion.IdTransaccion);
                cmd.Parameters.AddWithValue("@codTransaccion", transaccion.CodTransaccion);
                cmd.Parameters.AddWithValue("@tipoTransaccion", transaccion.TipoTransaccion);
                cmd.Parameters.AddWithValue("@montoBruto", transaccion.MontoBruto);
                cmd.Parameters.AddWithValue("@descuento", transaccion.Descuento);
                cmd.Parameters.AddWithValue("@montoTotal", transaccion.MontoTotal);
                cmd.Parameters.AddWithValue("@fechaHora", transaccion.FechaHora);
                cmd.Parameters.AddWithValue("@estadoTransaccion", transaccion.EstadoTransaccion);
                cmd.Parameters.AddWithValue("@idPersona", transaccion.IdPersona);
                cmd.Parameters.AddWithValue("@idMetodo", transaccion.IdMetodo.IdMetodo);
                cmd.Parameters.AddWithValue("@idCuenta", transaccion.IdCuenta.IdCuenta);

                cn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    actualiza = true;
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

            return actualiza;
        }

        // Deshabilitar
        public bool DeshabilitarTransaccion(int idTransaccion)
        {
            SqlCommand cmd = null;
            bool deshabilitado = false;

            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spDeshabilitarTransaccion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTransaccion", idTransaccion);

                cn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    deshabilitado = true;
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

            return deshabilitado;
        }

        // Eliminar
        public bool EliminarTransaccion(int idTransaccion)
        {
            SqlCommand cmd = null;

            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spEliminarTransaccion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTransaccion", idTransaccion);

                cn.Open();
                int i = cmd.ExecuteNonQuery();

                return i > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                }
            }
        }
        #endregion CRUD
    }
}
