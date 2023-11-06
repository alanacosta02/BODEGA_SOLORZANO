using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.Datos
{
    public class datRol
    {
        public static datRol Instancia { get; } = new ();

        public List<entRol> ListarRol()
        {
            SqlCommand cmd = null;
            List<entRol> lista = new List<entRol>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spListarRol", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entRol rol = new entRol
                    {
                        IdRol = Convert.ToInt32(dr["idRol"]),
                        Nombre = dr["nombre"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"]),
                        FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]),
                    };

                    lista.Add(rol);
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

