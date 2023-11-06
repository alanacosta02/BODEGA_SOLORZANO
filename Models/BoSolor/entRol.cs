using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public class entRol
    {
        private int idRol;
        private string nombre;
        private string descripcion;
        private bool activo;
        private DateTime fechaCreacion;

        public int IdRol { get => idRol; set => idRol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Activo { get => activo; set => activo = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    }
}
