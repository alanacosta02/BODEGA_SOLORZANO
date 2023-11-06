using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BODEGA_SOLORZANO.Models.BoSolor;
using BODEGA_SOLORZANO.Datos;

namespace BODEGA_SOLORZANO.Datos
{
    public class logRol
    {
        public static logRol Instancia = new ();

        public List<entRol> ListarRol()
        {
            return datRol.Instancia.ListarRol();
        }
    }
}
