using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace BODEGA_SOLORZANO.Datos
{
    public class Conexion
    {
        private static readonly Conexion _instancia = new Conexion();

        public static Conexion Instancia
        {
            get { return _instancia; }
        }

        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                //cn.ConnectionString = "Data Source =DESKTOP-K09GSCS\\SQLEXPRESS; Initial Catalog = BD_PRUEBAS_MADERERA; Integrated Security = true";
                //cn.ConnectionString = "Data Source =DESKTOP-K09GSCS\\SQLEXPRESS; Initial Catalog = BD_PRUEBAS_MADERERA; Integrated Security = true";
                cn.ConnectionString = "Data Source =database-server-1.cvfr9ma2ngux.us-east-2.rds.amazonaws.com; Initial Catalog = BoSolor; Integrated Security = true; User id= alan; Password = 2002";



                cn.Open();
                cn.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar conectarse al servidor");
            }
            return cn;
        }
    }
}

