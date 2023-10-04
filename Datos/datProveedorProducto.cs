using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;

namespace BODEGA_SOLORZANO.Datos
{
    public class datProveedorProducto
    {
        private static datProveedorProducto _instancia = new datProveedorProducto();

        public static datProveedorProducto Instancia
        {
            get { return _instancia; }
        }

        public List<entProveedorProducto> ListarProveedorProducto()
        {
            SqlCommand cmd = null;
            List<entProveedorProducto> lista = new List<entProveedorProducto>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProveedorProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor p = new entProveedor
                    {
                        IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                        RazonSocial = dr["proveedor"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"])
                    };
                    entProducto prod = new entProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idProducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Codigo = dr["codigo"].ToString(),
                        Stock = Convert.ToInt32(dr["stock"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"])
                    };
                    entProveedorProducto obj = new entProveedorProducto
                    {
                        IdProveedorProducto = Convert.ToInt32(dr["idProveedor_Producto"]),
                        Proveedor = p,
                        Producto = prod,
                        PrecioCompra = Convert.ToDouble(dr["precioCompra"])
                    };
                    lista.Add(obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo listar los productos");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public List<entProveedorProducto> ListarProductoAdmin()
        {
            SqlCommand cmd = null;
            List<entProveedorProducto> lista = new List<entProveedorProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProductoAdmin", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProveedor provedor = new entProveedor
                    {
                        RazonSocial = dr["razonSocial"].ToString(),
                    };
                    entCategoria idCategoria = new entCategoria
                    {
                        IdCategoria = Convert.ToInt32(dr["idCategoria"]),
                    };
                    entProducto producto = new entProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idProducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Codigo = dr["codigo"].ToString(),
                        Stock = Convert.ToInt32(dr["stock"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        IdCategoria = idCategoria
                    };
                    entProveedorProducto prov = new entProveedorProducto
                    {
                        IdProveedorProducto = Convert.ToInt32(dr["idProveedor_Producto"]),
                        PrecioCompra = Convert.ToDouble(dr["precioCompra"]),
                        Producto = producto,
                        Proveedor = provedor
                    };

                    lista.Add(prov);
                }

            }
            catch (Exception e)
            {
                throw new Exception("No se pudo listar los productos");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public List<entProveedorProducto> BuscarProductoAdmin(string busqueda)
        {
            List<entProveedorProducto> lista = new List<entProveedorProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProductoAdmin", cn);
                cmd.Parameters.AddWithValue("@Campo", busqueda);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entCategoria idCategoria = new entCategoria
                    {
                        IdCategoria = Convert.ToInt32(dr["idCategoria"]),
                    };
                    entProveedor provedor = new entProveedor
                    {
                        RazonSocial = dr["razonSocial"].ToString(),
                    };
                    entProducto producto = new entProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idProducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Codigo = dr["codigo"].ToString(),
                        Stock = Convert.ToInt32(dr["stock"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        IdCategoria = idCategoria
                    };
                    entProveedorProducto prov = new entProveedorProducto
                    {
                        PrecioCompra = Convert.ToDouble(dr["precioCompra"]),
                        Producto = producto,
                        Proveedor = provedor
                    };

                    lista.Add(prov);
                }
            }
            catch (Exception e)
            {

                throw new Exception("No se pudo listar los productos");
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        
    }
}
