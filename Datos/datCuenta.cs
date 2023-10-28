using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;

namespace BODEGA_SOLORZANO.Datos
{
    public class datCuenta
    {
        public static datCuenta Instancia = new();
        #region CRUD
        // Crear
        public bool CrearCuenta(entCuenta cuenta)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearCuenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", cuenta.DNI);
                cmd.Parameters.AddWithValue("@telefono", cuenta.Telefono);
                cmd.Parameters.AddWithValue("@correo", cuenta.Correo);
                cmd.Parameters.AddWithValue("@userName", cuenta.UserName);
                cmd.Parameters.AddWithValue("@pass", cuenta.Password);
                cmd.Parameters.AddWithValue("@idRol", cuenta.IdRol.IdRoll);
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
        public List<entCuenta> ListarCuentas()
        {
            List<entCuenta> lista = new List<entCuenta>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spListarCuenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                 

                    entCuenta cuenta = new entCuenta
                    {
                        IdCuenta = Convert.ToInt32(dr["IdCuenta"]),
                        DNI = dr["DNI"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        UserName = dr["UserName"].ToString(),
                        Activo = Convert.ToBoolean(dr["Activo"]),
                        FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                        FechaFin = dr["FechaFin"] is DBNull ? (DateTime?)null : Convert.ToDateTime(dr["FechaFin"]),
                   
                    };
                    // Verifica si la columna "Categoria" existe en el resultado del procedimiento almacenado
                    if (dr.GetOrdinal("userName") != -1)
                    {
                        entRoll rol = new entRoll
                        {
                            Nombre = dr["userName"].ToString()
                        };
                        cuenta.IdRol = rol;
                    }
                    lista.Add(cuenta);
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
        public bool ActualizarCuenta(entCuenta cuenta)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spActualizarCuenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCuenta", cuenta.IdCuenta);
                cmd.Parameters.AddWithValue("@dni", cuenta.DNI);
                cmd.Parameters.AddWithValue("@telefono", cuenta.Telefono);
                cmd.Parameters.AddWithValue("@correo", cuenta.Correo);
                cmd.Parameters.AddWithValue("@userName", cuenta.UserName);
                cmd.Parameters.AddWithValue("@pass", cuenta.Password);
                cmd.Parameters.AddWithValue("@activo", cuenta.Activo);
                cmd.Parameters.AddWithValue("@fechaInicio", cuenta.FechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", cuenta.FechaFin);
                cmd.Parameters.AddWithValue("@idRol", cuenta.IdRol.IdRoll);
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
        public bool DeshabilitarCuenta(int idCuenta)
        {
            SqlCommand cmd = null;
            bool deshabilitado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spDeshabilitarCuenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCuenta", idCuenta);
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
        public bool EliminarCuenta(int idCuenta)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spEliminarCuenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCuenta", idCuenta);
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


        public List<entCuenta> ListarCuentasRepartidor()
        {
            List<entCuenta> lista = new List<entCuenta>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCuentasSegunRol", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rol", "Repartidor");
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entRoll rol = new entRoll
                    {
                        IdRoll = Convert.ToInt32(dr["IdRoll"]),
                        Nombre = dr["Nombre"].ToString()
                    };

                    entCuenta cuenta = new entCuenta
                    {
                        IdCuenta = Convert.ToInt32(dr["IdCuenta"]),
                        DNI = dr["DNI"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        UserName = dr["UserName"].ToString(),
                        Activo = Convert.ToBoolean(dr["Activo"]),
                        FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                        FechaFin = dr["FechaFin"] is DBNull ? (DateTime?)null : Convert.ToDateTime(dr["FechaFin"]),
                        IdRol = rol

                    };
                    lista.Add(cuenta);
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
    }
}
