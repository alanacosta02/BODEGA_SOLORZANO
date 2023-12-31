﻿using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;

namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logProveedorProducto
    {
        public static logProveedorProducto Instancia = new ();

        #region CRUD


        public bool CrearProveedorProductos(entProveedorProducto pro)
        {
            return datProveedorProducto.Instancia.CrearProveedorProducto(pro);
        }
        public List<entProveedorProducto> ListarProveedorProducto()
        {
            return datProveedorProducto.Instancia.ListarProveedorProductos();
        }
        #endregion
        public List<entProveedorProducto> ListarProductoAdmin(string dato, string orden)
        {
            try
            {
                //switch (orden)
                //{
                //    // Si quieren implementar ordenar usar eso
                //    case "asc": return datProveedorProducto.Instancia.Ordenar(1);
                //    case "desc": return datProveedorProducto.Instancia.Ordenar(2);
                //    default:
                //        break;
                //}
                if (string.IsNullOrWhiteSpace(dato))
                {
                    return datProveedorProducto.Instancia.ListarProductoAdmin();
                }
                else
                {
                    return datProveedorProducto.Instancia.BuscarProductoAdmin(dato);
                }
            }
            catch
            {
                throw new Exception("Algo salio mal durante el proceso");
            }
        }

        public List<entProveedorProducto> ListarProductosCompra()
        {
            return datProveedorProducto.Instancia.ListarProductosCompra();
        }
    }
}
