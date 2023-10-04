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

        private static readonly string? cadenaSQL;

        static Conexion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaSQL);
        }
    }
}

