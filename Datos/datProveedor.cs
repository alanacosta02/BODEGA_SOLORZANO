using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;

namespace BODEGA_SOLORZANO.Datos
{
    public class datProveedor
    {
        public static datProveedor Instancia = new ();


        #region CRUD
        //Crear
        public bool CrearProveedor(entProveedor pro)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razonSocial", pro.RazonSocial);
                cmd.Parameters.AddWithValue("@numDocumento", pro.NumDocumento);
                cmd.Parameters.AddWithValue("@Contacto", pro.contacto);
         
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
        public List<entProveedor> ListarProveedor()
        {
            SqlCommand cmd = null;
            List<entProveedor> list = new List<entProveedor>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spListarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor pro = new entProveedor();
                    pro.IdProveedor = Convert.ToInt32(dr["idProveedor"]);
                    pro.RazonSocial = dr["razonSocial"].ToString();
                    pro.NumDocumento = dr["numDocumento"].ToString();
                    pro.contacto= dr["Contacto"].ToString();
                    pro.Activo = Convert.ToBoolean(dr["activo"]);
                    list.Add(pro);
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
        public bool ActualizarProveedor(entProveedor pro)
        {
            SqlCommand cmd = null;
            bool actualizado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spActualizarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", pro.IdProveedor);
                cmd.Parameters.AddWithValue("@razonSocial", pro.RazonSocial);
                cmd.Parameters.AddWithValue("@numDocumento", pro.NumDocumento);
                cmd.Parameters.AddWithValue("@telefono", pro.contacto);
                cmd.Parameters.AddWithValue("@activo", pro.Activo);
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
        public bool DeshabilitarProveedor(int idProveedor)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spDeshabilitarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
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
        public List<entProveedor> BuscarProveedor(string busqueda)
        {
            List<entProveedor> list = new List<entProveedor>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spBuscarProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Campo", busqueda);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor pro = new entProveedor();
                    pro.IdProveedor = Convert.ToInt32(dr["idProveedor"]);
                    pro.RazonSocial = dr["razonSocial"].ToString();
                    pro.NumDocumento = dr["numDocumento"].ToString();
                    pro.contacto = dr["telefono"].ToString();
                    pro.Activo = Convert.ToBoolean(dr["activo"]);
                    list.Add(pro);
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
        public entProveedor BuscarIdProveedor(int idProveedor)
        {
            SqlCommand cmd = null;
            entProveedor pro = new entProveedor();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spBuscarIdProveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pro.IdProveedor = Convert.ToInt32(dr["idProveedor"]);
                    pro.RazonSocial = dr["razonSocial"].ToString();
                    pro.NumDocumento = dr["numDocumento"].ToString();
                    pro.contacto = dr["telefono"].ToString();
                    pro.Activo = Convert.ToBoolean(dr["activo"]);
                }
            }
            catch (Exception e)
            { throw e; }
            finally { cmd.Connection.Close(); }
            return pro;
        }
        public List<entProveedor> OrdenarProveedores(int orden)
        {
            SqlCommand cmd = null;
            List<entProveedor> list = new List<entProveedor>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spOrdenarProveedor", cn);
                cmd.Parameters.AddWithValue("@orden", orden);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor pro = new entProveedor();
                    pro.IdProveedor = Convert.ToInt32(dr["idProveedor"]);
                    pro.RazonSocial = dr["razonSocial"].ToString();
                    pro.NumDocumento = dr["numDocumento"].ToString();
                    pro.contacto = dr["telefono"].ToString();
                    pro.Activo = Convert.ToBoolean(dr["activo"]);
                    list.Add(pro);
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
