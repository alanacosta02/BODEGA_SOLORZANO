using BODEGA_SOLORZANO.Models.BoSolor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace BODEGA_SOLORZANO.Datos
{
    public class datCliente
    {
    
        public static datCliente instancia = new datCliente();

        //Crear
        public bool CrearCliente(entCliente cliente)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spCrearCliente", cn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombres", cliente.nombres);
                cmd.Parameters.AddWithValue("@apellidos", cliente.apellidos);
                cmd.Parameters.AddWithValue("@numDocumento", cliente.numDocumento);

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
                cmd?.Connection.Close();
            }
            return creado;
        }

        //Leer
        public List<entCliente> ListarClientes()
        {
            List<entCliente> lista = new List<entCliente>();

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("spListarClientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                entCliente cliente = new entCliente
                                {
                                    idCliente = Convert.ToInt32(dr["idCliente"]),
                                    nombres = dr["nombres"].ToString(),
                                    apellidos = dr["apellidos"].ToString(),
                                    numDocumento = dr["numDocumento"].ToString(),
                                };

                                lista.Add(cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al listar clientes: {e.Message}");
                throw;
            }

            return lista;
        }

        //Actualizar
        public bool ActualizarCliente(entCliente cliente)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spActualizarCliente", cn); // Reemplaza "spActualizarCliente" con el nombre correcto del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);
                cmd.Parameters.AddWithValue("@nombres", cliente.nombres);
                cmd.Parameters.AddWithValue("@apellidos", cliente.apellidos);
                cmd.Parameters.AddWithValue("@numDocumento", cliente.numDocumento);

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
            finally { cmd?.Connection.Close(); }
            return actualiza;
        }

        //Eliminar - Deshabilitar
        public bool EliminarCliente(int id)
        {
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.ObtenerConexion();
                cmd = new SqlCommand("spEliminarCliente", cn); // Reemplaza "spEliminarCliente" con el nombre correcto del procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", id);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                return i > 0;
            }
            catch (Exception e)
            {
                throw new Exception("ClienteReferenciadoException", e);
            }
            finally
            {
                cmd?.Connection.Close();
            }
        }

    }
}
