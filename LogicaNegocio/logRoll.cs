using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BODEGA_SOLORZANO.Models.BoSolor;
using BODEGA_SOLORZANO.Datos;

namespace BODEGA_SOLORZANO.Datos
{
    public class logRoll
    {
        private static readonly logRoll _instancia = new logRoll();
        public static logRoll Instancia
        {
            get { return _instancia; }
        }

        public List<entRoll> ListarRol()
        {
            return datRoll.Instancia.ListarRoll();
        }
    }
}
