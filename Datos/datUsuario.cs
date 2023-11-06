using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BODEGA_SOLORZANO.Datos;


namespace BODEGA_SOLORZANO.Datos
{
    public class datUsuario 
    {
        public static datUsuario Instancia { get; } = new ();

        #region CRUD
        //Crear
        public bool CrearUsuario(entUsuario Usu)
        {
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", Usu.Dni);
                cmd.Parameters.AddWithValue("@telefono", Usu.Telefono);
                cmd.Parameters.AddWithValue("@correo", Usu.Correo);
                cmd.Parameters.AddWithValue("@userName", Usu.UserName);
                cmd.Parameters.AddWithValue("@pass", Usu.Pass);
                cmd.Parameters.AddWithValue("@activo", Usu.Activo);
                cmd.Parameters.AddWithValue("@correo", Usu.Correo);
                cmd.Parameters.AddWithValue("@fechaInicio", Usu.FechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", Usu.FechaFin);
                cmd.Parameters.AddWithValue("@idRol", Usu.Rol.IdRol);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    creado = true;
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

        //Leer
        public List<entUsuario> ListarUsuarios()
        {
            SqlCommand cmd = null;
            List<entUsuario> lista = new List<entUsuario>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spListarUsuarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entUsuario usu = new entUsuario
                    {
                        IdCuenta = Convert.ToInt32(dr["idCuenta"]),
                        Dni = dr["dni"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"]),
                        FechaInicio = Convert.ToDateTime(dr["fechaInicio"]),
                        FechaFin = Convert.ToDateTime(dr["fechaFin"])
                    };
                    entRol r = new entRol
                    {
                        Nombre = dr["nombre"].ToString()
                    };
                    usu.Rol = r;
                    lista.Add(usu);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Se produjo un error inesperado");

            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }
        public List<entUsuario> ListarAdministradores()
        {
            SqlCommand cmd = null;
            List<entUsuario> lista = new List<entUsuario>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spListarAdministradores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entRol rol = new entRol()
                    {
                        Descripcion = dr["descripcion"].ToString(),
                    };
                    entUsuario usu = new entUsuario
                    {
                        IdCuenta = Convert.ToInt32(dr["idCuenta"]),
                        Dni = dr["dni"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"]),
                        FechaInicio = Convert.ToDateTime(dr["fechaInicio"]),
                        FechaFin = Convert.ToDateTime(dr["fechaFin"]),
                        Rol = rol
                    };
                    lista.Add(usu);
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

        //Actualizar


        //Eliminar - Activo
        public bool DeshabilitarUsuario(int id)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spDeshabilitarUsuario", cn);
                cmd.Parameters.AddWithValue("@idCuenta", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    eliminado = true;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally { cmd.Connection.Close(); }
            return eliminado;
        }
        public bool HabilitarUsuario(int id)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spHabilitarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCuenta", id);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    eliminado = true;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally { cmd.Connection.Close(); }
            return eliminado;
        }
        #endregion CRUD

        #region OTROS
        public entUsuario IniciarSesion(string campo, string contra)
        {
            SqlCommand cmd = null;
            entUsuario u = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spIniciarSesion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userName", campo);
                cmd.Parameters.AddWithValue("@pass", contra);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        u = new entUsuario
                        {
                            IdRol = Convert.ToInt32(dr["idRol"]),
                            UserName = dr["userName"].ToString(),
                            Activo = Convert.ToBoolean(dr["activo"]),
                            IdCuenta = Convert.ToInt32(dr["idCuenta"]),
               
                        };
                    }
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
            return u;
        }
        public List<entUsuario> BuscarAdministrador(string dato)
        {
            SqlCommand cmd = null;
            List<entUsuario> lista = new List<entUsuario>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spBuscarAdministrador", cn);
                cmd.Parameters.AddWithValue("@Campo", dato);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entRol rol = new entRol()
                    {
                        Descripcion = dr["descripcion"].ToString(),
                    };
                    entUsuario usu = new entUsuario
                    {
                        IdCuenta = Convert.ToInt32(dr["idCuenta"]),
                        Dni = dr["dni"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"]),
                        FechaInicio = Convert.ToDateTime(dr["fechaInicio"]),
                        FechaFin = Convert.ToDateTime(dr["fechaFin"]),
                        Rol = rol
                    };
                    lista.Add(usu);
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
        public List<entUsuario> BuscarUsuario(string campo)
        {
            List<entUsuario> lista = new List<entUsuario>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spBuscarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@campo", campo);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entUsuario user = new entUsuario
                    {
                        IdCuenta = Convert.ToInt32(dr["idCuenta"]),
                        Dni = dr["dni"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"]),
                        FechaInicio = Convert.ToDateTime(dr["fechaInicio"]),
                        FechaFin = Convert.ToDateTime(dr["fechaFin"]),

                    };
                    
                    entRol r = new entRol
                    {
                        Descripcion = dr["descripcion"].ToString()
                    };
                    user.Rol = r;
                    lista.Add(user);
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
        public List<entUsuario> OrdenarAdministradores(int orden)
        {
            SqlCommand cmd = null;
            List<entUsuario> lista = new List<entUsuario>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spOrdenarAdministrador", cn);
                cmd.Parameters.AddWithValue("@orden", orden);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entRol rol = new entRol()
                    {
                        Descripcion = dr["descripcion"].ToString(),
                    };
                    entUsuario usu = new entUsuario
                    {
                        IdCuenta = Convert.ToInt32(dr["idCuenta"]),
                        Dni = dr["dni"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Correo = dr["correo"].ToString(),
                        UserName = dr["userName"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"]),
                        FechaInicio = Convert.ToDateTime(dr["fechaInicio"]),
                        FechaFin = Convert.ToDateTime(dr["fechaFin"]),
                        Rol = rol
                    };
                    lista.Add(usu);
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
        public bool CrearSesionUsuario(entUsuario u)
        {
            bool creado = false;

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("spCrearSesionUsuario", cn))
                    {
                        cmd.Parameters.AddWithValue("@userName", u.UserName);
                        cmd.Parameters.AddWithValue("@correo", u.Correo);
                        cmd.Parameters.AddWithValue("@pass", u.Pass);
                        cmd.Parameters.AddWithValue("@idRol", u.Rol.IdRol);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        creado = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("UQ_USUARIO_USERNAME"))
                {
                    throw new Exception($"El nombre de usuario {u.UserName} ya esta asociado a una cuenta existente");
                }
                if (ex.Message.ToUpper().Contains("CHK_USUARIO_USERNAME"))
                {
                    throw new Exception($"El nombre de usuario {u.UserName} no cumple con el formato establecido");
                }
                if (ex.Message.ToUpper().Contains("CHK_USUARIO_CORREO"))
                {
                    throw new Exception($"El correo {u.Correo} no cumple con el formato establecido");
                }
                if (ex.Message.ToUpper().Contains("UQ_USUARIO_CORREO"))
                {
                    throw new Exception($"El correo {u.Correo} ya esta asociado a una cuenta existente");
                }
            }
            return creado;
        }
        public bool RestablecerPassword(int idCuenta, string pass, string correo)
        {
            bool restablecer = false;
            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    using (var cmd = new SqlCommand("spRestablecerPassword", cn))
                    {
                        cmd.Parameters.AddWithValue("@idCuenta", idCuenta);
                        cmd.Parameters.AddWithValue("@pass", pass);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        int i = cmd.ExecuteNonQuery();
                        restablecer = i > 0;
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception($"Se produjo el siguiente error {e.Message}");
            }
            return restablecer;
        }
    }
    #endregion OTROS
}
