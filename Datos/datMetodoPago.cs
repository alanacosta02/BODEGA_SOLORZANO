using BODEGA_SOLORZANO.Models.BoSolor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BODEGA_SOLORZANO.Datos
{
    public class datMetodoPago
    {
        public static datMetodoPago Instancia = new datMetodoPago();


        #region CRUD
        // Crear
        public bool CrearMetodoPago(entMetodoPago metodoPago)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearMetodoPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", metodoPago.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", metodoPago.Descripcion);
  
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

        // Leer
        public List<entMetodoPago> ListarMetodosPago()
        {
            List<entMetodoPago> lista = new List<entMetodoPago>();

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("spListarMetodoPago", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                entMetodoPago metodoPago = new entMetodoPago
                                {
                                    IdMetodo = Convert.ToInt32(dr["idMetodo"]),
                                    Nombre = dr["nombre"].ToString(),
                                    Descripcion = dr["descripcion"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    FechaCreacion = Convert.ToDateTime(dr["fechaCreacion"])
                                };

                                lista.Add(metodoPago);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al listar métodos de pago: {e.Message}");
                throw;
            }

            return lista;
        }

        // Actualizar
        public bool ActualizarMetodoPago(entMetodoPago metodoPago)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spActualizarMetodoPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMetodo", metodoPago.IdMetodo);
                cmd.Parameters.AddWithValue("@nombre", metodoPago.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", metodoPago.Descripcion);
                cmd.Parameters.AddWithValue("@activo", metodoPago.Activo);
                cmd.Parameters.AddWithValue("@fechaCreacion", metodoPago.FechaCreacion);
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

        // Eliminar - Deshabilitar
        public bool EliminarMetodoPago(int id)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spEliminarMetodoPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMetodo", id);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                return i > 0;
            }
            catch (Exception e)
            {
                throw new Exception("MetodoPagoReferenciadoException", e);
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



    }
}
