using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;

namespace BODEGA_SOLORZANO.Datos
{
    public class datProveedorProducto
    {
        public static datProveedorProducto Instancia { get; } = new();
        public bool CrearProveedorProducto(entProveedorProducto proveedorProducto)
        {
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearProveedorProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asegúrate de ajustar los nombres de los parámetros y las propiedades según tu modelo
                cmd.Parameters.AddWithValue("@idProveedor", proveedorProducto.Proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@idProducto", proveedorProducto.Producto.IdProducto);
                cmd.Parameters.AddWithValue("@precioCompra", proveedorProducto.PrecioCompra);


                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    creado = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

            return creado;
        }


        public List<entProveedorProducto> ListarProveedorProductos()
        {
            List<entProveedorProducto> lista = new List<entProveedorProducto>();

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("spListarProveedorProducto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                entProveedorProducto proveedorProducto = new entProveedorProducto
                                {

                                    PrecioCompra = Convert.ToDouble(dr["Precio"])
                                };

                                // Verifica si las columnas "Proveedor" y "Producto" existen en el resultado del procedimiento almacenado
                                if (dr.GetOrdinal("Proveedor") != -1)
                                {
                                    entProveedor proveedor = new entProveedor
                                    {
                                        RazonSocial = dr["PROVEEDOR"].ToString()
                                        // Ajusta según las propiedades reales de tu entidad Proveedor
                                    };
                                    proveedorProducto.Proveedor = proveedor;
                                }

                                if (dr.GetOrdinal("Producto") != -1)
                                {
                                    entProducto producto = new entProducto
                                    {
                                        Nombre = dr["PRODUCTO"].ToString()
                                        // Ajusta según las propiedades reales de tu entidad Producto
                                    };
                                    proveedorProducto.Producto = producto;
                                }

                                lista.Add(proveedorProducto);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al listar proveedor-producto: {e.Message}");
                // Log.Error($"Error al listar proveedor-producto: {e.Message}", e);
                throw; // Lanza la excepción nuevamente para que puedas verla en el lugar que llama a este método.
            }

            return lista;
        }

        public List<entProveedorProducto> ListarProductosCompra()
        {
            List<entProveedorProducto> lista = new List<entProveedorProducto>();

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("spListarProductosCompra", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                entProveedorProducto proveedorProducto = new entProveedorProducto
                                {
                                    PrecioCompra = Convert.ToDouble(dr["precioCompra"])
                                };

                                entProveedor proveedor = new entProveedor
                                {
                                    IdProveedor = Convert.ToInt32(dr["idProveedor"]),
                                    RazonSocial = dr["razonSocial"].ToString()
                                };

                                entProducto producto = new entProducto
                                {
                                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                                    Imagen = dr["Imagen"].ToString()
                                };
                                proveedorProducto.Producto = producto;
                                proveedorProducto.Proveedor = proveedor;

                                lista.Add(proveedorProducto);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return lista;

        }

        public List<entProveedorProducto> ListarProductoAdmin()
        {
            SqlCommand cmd = null;
            List<entProveedorProducto> lista = new List<entProveedorProducto>();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
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
                SqlConnection cn = Conexion.ObtenerConexion();
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
