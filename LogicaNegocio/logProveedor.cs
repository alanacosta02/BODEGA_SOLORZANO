﻿using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logProveedor
    {
        public static logProveedor Instancia = new ();


        #region CRUD
        public bool CrearProveedor(entProveedor pro)
        {
            return datProveedor.Instancia.CrearProveedor(pro);
        }
        public List<entProveedor> ListarProveedor(string dato, string orden)
        {
            // Si el parámetro "dato" no está vacío, buscar proveedores por su nombre o correo electrónico.
            if (!string.IsNullOrEmpty(dato))
            {
                return datProveedor.Instancia.BuscarProveedor(dato);
            }

            // Si el parámetro "orden" está vacío, devolver la lista de proveedores sin ordenar.
            if (string.IsNullOrEmpty(orden))
            {
                return datProveedor.Instancia.ListarProveedor();
            }

            // Determinar la dirección de ordenamiento.
            bool ordenAscendente = (orden.ToLower() == "asc");

            // Llamar al método "OrdenarProveedores()" con un valor entero (1 para ascendente, 0 para descendente).
            return datProveedor.Instancia.OrdenarProveedores(ordenAscendente ? 1 : 0);
        }
        public bool ActualizarProveedor(entProveedor pro)
        {
            return datProveedor.Instancia.ActualizarProveedor(pro);
        }
        public bool DeshabilitarProveedor(int id)
        {
            return datProveedor.Instancia.DeshabilitarProveedor(id);
        }
        #endregion CRUD
        public List<entProveedor> BuscarProveedor(string busqueda)
        {
            return datProveedor.Instancia.BuscarProveedor(busqueda);
        }
        public entProveedor BuscarIdProveedor(int idProveedor)
        {
            return datProveedor.Instancia.BuscarIdProveedor(idProveedor);
        }
    }
}
