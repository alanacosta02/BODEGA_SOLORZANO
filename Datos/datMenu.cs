using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;

namespace BODEGA_SOLORZANO.Datos
{
    public class datMenu
    {
        public static datMenu Instancia { get; } = new();

        public List<entMenu> MostrarMenu(int idRol, string tipo)
        {
            var lsMenu = new List<entMenu>();
            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand("spMostrarMenu", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRol", idRol);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            try
            {
                cn.Open();
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var menu = new entMenu
                    {
                        IdMenu = dr.GetInt32(dr.GetOrdinal("IdMenu")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Icono = dr.GetString(dr.GetOrdinal("Icono")),
                        Controlador = dr.GetString(dr.GetOrdinal("Controlador")),
                        PaginaAccion = dr.GetString(dr.GetOrdinal("PaginaAccion")),
                        IdMenuPadre = dr.GetInt32(dr.GetOrdinal("IdMenuPadre"))
                    };
                    lsMenu.Add(menu);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lsMenu;
        }
    }
}
