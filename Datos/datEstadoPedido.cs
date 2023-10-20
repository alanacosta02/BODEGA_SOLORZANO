using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data;
using System.Data.SqlClient;


namespace BODEGA_SOLORZANO.Datos
{
    public class datEstadoPedido
    {

        public static datEstadoPedido Instancia = new();
        #region CRUD 
        // Crear
        public bool CrearEstadoPedido(entEstadoPedido estadoPedido)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearEstadoPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreEstado", estadoPedido.NombreEstado);
                cmd.Parameters.AddWithValue("@descripcion", estadoPedido.Descripcion);
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
        public List<entEstadoPedido> ListarEstadosPedido()
        {
            List<entEstadoPedido> lista = new List<entEstadoPedido>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spListarEstadosPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entEstadoPedido estadoPedido = new entEstadoPedido
                    {
                        IdEstadoPedido = Convert.ToInt32(dr["IdEstadoPedido"]),
                        NombreEstado = dr["nombreEstado"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"])
                    };

                    lista.Add(estadoPedido);
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
            return lista;
        }

        // Actualizar
        public bool ActualizarEstadoPedido(entEstadoPedido estadoPedido)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spActualizarEstadoPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEstadoPedido", estadoPedido.IdEstadoPedido);
                cmd.Parameters.AddWithValue("@nombreEstado", estadoPedido.NombreEstado);
                cmd.Parameters.AddWithValue("@descripcion", estadoPedido.Descripcion);
                cmd.Parameters.AddWithValue("@fechaCreacion", estadoPedido.FechaCreacion);
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

        // Eliminar
        public bool EliminarEstadoPedido(int idEstadoPedido)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spEliminarEstadoPedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEstadoPedido", idEstadoPedido);
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
