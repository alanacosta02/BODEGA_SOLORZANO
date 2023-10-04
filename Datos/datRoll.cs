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
    public class datRoll
    {
        private static readonly datRoll _instancia = new datRoll();
        public static datRoll Instancia
        {
            get { return _instancia; }
        }

        public List<entRoll> ListarRoll()
        {
            SqlCommand cmd = null;
            List<entRoll> lista = new List<entRoll>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarRol", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entRoll rol = new entRoll
                    {
                        IdRoll = Convert.ToInt32(dr["idRol"]),
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

