using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BODEGA_SOLORZANO.Models.BoSolor
{
    public enum entRol
    {
        // enum permite poner constantes listadas con nombre y valor
        Administrador = 1, Jefe = 2

    }
    public class entRoll
    {
        private int idRoll;
        private string nombre;
        private string descripcion;
        private bool activo;
        private DateTime fechaCreacion;

        public int IdRoll { get => idRoll; set => idRoll = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Activo { get => activo; set => activo = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    }
}
