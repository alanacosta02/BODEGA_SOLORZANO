using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logCategoria
    {
        private static readonly logCategoria _instancia = new logCategoria();

        public static logCategoria Instancia
        {
            get { return _instancia; }
        }

        #region CRUD
        public bool CrearCategoria(entCategoria cat)
        {
            return datCategoria.Instancia.CrearCategoria(cat);
        }
        public List<entCategoria> ListarCategoria(string dato, string orden)
        {
            // Si el parámetro "dato" no está vacío, buscar Categoriaes por su nombre o correo electrónico.
            if (!string.IsNullOrEmpty(dato))
            {
                return datCategoria.Instancia.BuscarCategoria(dato);
            }

            // Si el parámetro "orden" está vacío, devolver la lista de Categoriaes sin ordenar.
            if (string.IsNullOrEmpty(orden))
            {
                return datCategoria.Instancia.ListarCategoria();
            }

            // Determinar la dirección de ordenamiento.
            bool ordenAscendente = (orden.ToLower() == "asc");

            // Llamar al método "OrdenarCategoriaes()" con un valor entero (1 para ascendente, 0 para descendente).
            return datCategoria.Instancia.OrdenarCategoria(ordenAscendente ? 1 : 0);
        }
        public bool ActualizarCategoria(entCategoria cat)
        {
            return datCategoria.Instancia.ActualizarCategoria(cat);
        }
        public bool DeshabilitarCategoria(int id)
        {
            return datCategoria.Instancia.DeshabilitarCategoria(id);
        }
        #endregion CRUD
        public List<entCategoria> BuscarCategoria(string busqueda)
        {
            return datCategoria.Instancia.BuscarCategoria(busqueda);
        }
        public entCategoria BuscarIdCategoria(int idCategoria)
        {
            return datCategoria.Instancia.BuscarIdCategoria(idCategoria);
        }
    }
}
