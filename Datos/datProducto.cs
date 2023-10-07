using BODEGA_SOLORZANO.Models.BoSolor;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BODEGA_SOLORZANO.Datos
{
    public class datProducto
    {
        public static datProducto Instancia = new ();


        #region CRUD
        //Crear
        public bool CrearProducto(entProducto prod)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", prod.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", prod.Descripcion);
                cmd.Parameters.AddWithValue("@codigo", prod.Codigo);
                cmd.Parameters.AddWithValue("@precioVenta", prod.PrecioVenta);
                cmd.Parameters.AddWithValue("@imagen", prod.Imagen);
                cmd.Parameters.AddWithValue("@activo", prod.Activo);
                cmd.Parameters.AddWithValue("@idCategoria", prod.IdCategoria);
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
        //Leer
        public List<entProducto> ListarProductos()
        {
            List<entProducto> lista = new List<entProducto>();

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("spListarProducto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                entProducto prod = new entProducto
                                {
                                    IdProducto = Convert.ToInt32(dr["idProducto"]),
                                    Nombre = dr["nombre"].ToString(),
                                    Descripcion = dr["descripcion"].ToString(),
                                    Codigo = dr["codigo"].ToString(),
                                    Stock = Convert.ToInt32(dr["stock"]),
                                    PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                                    Imagen = dr["imagen"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"])
                                };

                                // Verifica si la columna "Categoria" existe en el resultado del procedimiento almacenado
                                if (dr.GetOrdinal("Categoria") != -1)
                                {
                                    entCategoria categoria = new entCategoria
                                    {
                                        Nombre = dr["Categoria"].ToString()
                                    };
                                    prod.IdCategoria = categoria;
                                }

                                lista.Add(prod);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al listar productos: {e.Message}");
                // Log.Error($"Error al listar productos: {e.Message}", e);
                throw; // Lanza la excepción nuevamente para que puedas verla en el lugar que llama a este método.
            }

            return lista;
        }

        //Actualizar

        public bool ActualizarProducto(entProducto Prod)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spActualizarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idproducto", Prod.IdProducto);
                cmd.Parameters.AddWithValue("@nombre", Prod.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", Prod.Descripcion);
                cmd.Parameters.AddWithValue("@codigo", Prod.Codigo);
                cmd.Parameters.AddWithValue("@stock", Prod.Stock);
                cmd.Parameters.AddWithValue("@precioVenta", Prod.PrecioVenta);
                cmd.Parameters.AddWithValue("@imagen", Prod.Imagen);
                cmd.Parameters.AddWithValue("@activo", Prod.Activo);
                cmd.Parameters.AddWithValue("@fechaCreacion", Prod.FechaCreacion);
                cmd.Parameters.AddWithValue("@idCategoria", Prod.IdCategoria); 
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    actualiza = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { cmd.Connection.Close(); }
            return actualiza;
        }

        //Eliminar - Deshabilitar
        public bool EliminarProducto(int id)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spEliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", id);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                return i > 0;
            }
            catch (Exception e)
            {
                throw new Exception("ProductoReferenciadoException", e);
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                }
            }
        }
        #endregion CRUD

        public List<entProducto> BuscarProducto(string busqueda)
        {
            List<entProducto> lista = new List<entProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spBuscarProducto", cn);
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
                    entProducto Prod = new entProducto
                    {
                        IdProducto = Convert.ToInt32(dr["idProducto"]),
                        Nombre = dr["nombre"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        Codigo = dr["codigo"].ToString(),
                        Stock = Convert.ToInt32(dr["stock"]),
                        PrecioVenta = Convert.ToDouble(dr["precioVenta"]),
                        Imagen = dr["imagen"].ToString(),
                        Activo = Convert.ToBoolean(dr["activo"]),
                        FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]),
                        IdCategoria = idCategoria
                    };
                    lista.Add(Prod);
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
            return lista;
        }

        // Actualmente solo se puede ordenar por nombre de forma asc = 1 y desc = 0
        public List<entProducto> Ordenar(int categoriaOrden)
        {
            List<entProducto> lista = new List<entProducto>();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spOrdenarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategoria", categoriaOrden);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProducto Prod = new entProducto();
                    Prod.IdProducto = Convert.ToInt32(dr["idProducto"]);
                    Prod.Nombre = dr["nombre"].ToString();
                    Prod.Descripcion = dr["descripcion"].ToString();
                    Prod.Codigo = dr["codigo"].ToString();
                    Prod.Stock = Convert.ToInt32(dr["stock"]);
                    Prod.PrecioVenta = Convert.ToDouble(dr["precioVenta"]);
                    Prod.Imagen = dr["imagen"].ToString();
                    Prod.Activo = Convert.ToBoolean(dr["activo"]);
                    Prod.FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);
                    entCategoria idCategoria = new entCategoria();
                    idCategoria.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                    Prod.IdCategoria = idCategoria;
                    lista.Add(Prod);
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
            return lista;
        }
        public entProducto BuscarProductoId(int idProd)
        {
            SqlCommand cmd = null;
            entProducto Prod = new entProducto();
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spBuscarProductoId", cn);
                cmd.Parameters.AddWithValue("@idProducto", idProd);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Prod.IdProducto = Convert.ToInt32(dr["idProducto"]);
                    Prod.Nombre = dr["nombre"].ToString();
                    Prod.Descripcion = dr["descripcion"].ToString();
                    Prod.Codigo = dr["codigo"].ToString();
                    Prod.Stock = Convert.ToInt32(dr["stock"]);
                    Prod.PrecioVenta = Convert.ToDouble(dr["precioVenta"]);
                    Prod.Imagen = dr["imagen"].ToString();
                    Prod.Activo = Convert.ToBoolean(dr["activo"]);
                    Prod.FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"]);
                    entCategoria idCategoria = new entCategoria();
                    idCategoria.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                    Prod.IdCategoria = idCategoria;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("El producto no se encontro", ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Prod;
        }

    }
}
