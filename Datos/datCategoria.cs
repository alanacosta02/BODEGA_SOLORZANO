using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;

namespace BODEGA_SOLORZANO.Datos
{
    public class datCategoria
    {
        public static datCategoria Instancia = new ();

        #region CRUD
        //Crear
        public bool CrearCategoria(entCategoria cat)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", cat.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", cat.Descripcion);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
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
        //Leer
        public List<entCategoria> ListarCategoria()
        {
            SqlCommand cmd = null;
            List<entCategoria> list = new List<entCategoria>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spListarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entCategoria cat = new entCategoria();
                    cat.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                    cat.Nombre = dr["nombre"].ToString();
                    cat.Descripcion = dr["descripcion"].ToString();
                    cat.Activo = Convert.ToBoolean(dr["activo"]);
                    cat.FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);
                    list.Add(cat);
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
            return list;
        }
        //Actualizar
        public bool ActualizarCategoria(entCategoria cat)
        {
            SqlCommand cmd = null;
            bool actualizado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spActualizarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategoria", cat.IdCategoria);
                cmd.Parameters.AddWithValue("@nombre", cat.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", cat.Descripcion);
                cmd.Parameters.AddWithValue("@activo", cat.Activo);
                cmd.Parameters.AddWithValue("@fechaCreacion", cat.FechaCreacion);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    actualizado = true;
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
            return actualizado;
        }
        //Eliminar
        public bool DeshabilitarCategoria(int idCategoria)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spDeshabilitarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
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
            finally
            {
                cmd.Connection.Close();
            }
            return eliminado;
        }
        #endregion CRUD

        #region OTROS
        public List<entCategoria> BuscarCategoria(string busqueda)
        {
            List<entCategoria> list = new List<entCategoria>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spBuscarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entCategoria cat = new entCategoria();
                    cat.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                    cat.Nombre = dr["nombre"].ToString();
                    cat.Descripcion = dr["descripcion"].ToString();
                    cat.Activo = Convert.ToBoolean(dr["activo"]);
                    cat.FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);
                    list.Add(cat);
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
            return list;
        }
        public entCategoria BuscarIdCategoria(int idCategoria)
        {
            SqlCommand cmd = null;
            entCategoria cat = new entCategoria();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spBuscarIdCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cat.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                    cat.Nombre = dr["nombre"].ToString();
                    cat.Descripcion = dr["descripcion"].ToString();
                    cat.Activo = Convert.ToBoolean(dr["activo"]);
                    cat.FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);
                }
            }
            catch (Exception e)
            { throw e; }
            finally { cmd.Connection.Close(); }
            return cat;
        }
        public List<entCategoria> OrdenarCategoria(int orden)
        {
            SqlCommand cmd = null;
            List<entCategoria> list = new List<entCategoria>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spOrdenarCategoria", cn);
                cmd.Parameters.AddWithValue("@orden", orden);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entCategoria cat = new entCategoria();
                    cat.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                    cat.Nombre = dr["nombre"].ToString();
                    cat.Descripcion = dr["descripcion"].ToString();
                    cat.Activo = Convert.ToBoolean(dr["activo"]);
                    cat.FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);
                    list.Add(cat);
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
            return list;
        }
        #endregion
    }
}
