using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;

namespace BODEGA_SOLORZANO.Datos
{
   
        public class datPedidos
        {
            public static datPedidos Instancia { get; } = new datPedidos();

            // Crear
            public bool CrearPedido(entPedido pedido)
            {
                SqlCommand cmd = null;
                bool creado = false;

                try
                {
                    using (SqlConnection cn = Conexion.ObtenerConexion())
                    {
                        cmd = new SqlCommand("spCrearPedido", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@direccionEntrega", pedido.DireccionEntrega);
                        cmd.Parameters.AddWithValue("@referencia", pedido.Referencia);
                        cmd.Parameters.AddWithValue("@detalle", pedido.Detalle);
                        cmd.Parameters.AddWithValue("@fechaRegistro", pedido.FechaRegistro);
                        cmd.Parameters.AddWithValue("@fechaRecepcion", pedido.FechaRecepcion);
                        cmd.Parameters.AddWithValue("@fechaEntrega", pedido.FechaEntrega);
                        cmd.Parameters.AddWithValue("@idCliente", pedido.IdCliente.idCliente);
                        cmd.Parameters.AddWithValue("@idTransaccion", pedido.IdTransaccion.IdTransaccion);
                        cmd.Parameters.AddWithValue("@idEstadoPedido", pedido.IdEstadoPedido.IdEstadoPedido);
                        cmd.Parameters.AddWithValue("@idRepartidor", pedido.IdRepartidor.IdCuenta);

                        cn.Open();
                        int i = cmd.ExecuteNonQuery();
                        creado = i != 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error al crear pedido: {e.Message}");
                    // Log.Error($"Error al crear pedido: {e.Message}", e);
                    throw; // Lanza la excepción nuevamente para que puedas verla en el lugar que llama a este método.
                }
                finally
                {
                    cmd?.Connection.Close();
                }

                return creado;
            }

        // Leer
        public List<entPedido> ListarPedidos()
        {
            List<entPedido> lista = new List<entPedido>();

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("spListarPedido", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                entPedido pedido = new entPedido
                                {
                                    IdPedido = Convert.ToInt32(dr["idPedido"]),
                                    DireccionEntrega = dr["direccionEntrega"].ToString(),
                                    Referencia = dr["referencia"].ToString(),
                                    Detalle = dr["detalle"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["fechaRegistro"]),
                                    FechaRecepcion = dr["fechaRecepcion"] != DBNull.Value ? Convert.ToDateTime(dr["fechaRecepcion"]) : DateTime.MinValue,
                                    FechaEntrega = dr["fechaEntrega"] != DBNull.Value ? Convert.ToDateTime(dr["fechaEntrega"]) : DateTime.MinValue,
                                    // ... otras propiedades
                                };

                                // Verifica si las columnas relacionadas existen en el resultado del procedimiento almacenado
                                if (dr.GetOrdinal("Cliente") != -1 && dr["Cliente"] != DBNull.Value)
                                {
                                    entCliente cliente = new entCliente
                                    {
                                        nombres = dr["Cliente"].ToString(),
                                        // ... asignar otras propiedades del cliente
                                    };
                                    pedido.IdCliente = cliente;
                                }

                                if (dr.GetOrdinal("codTransaccion") != -1 && dr["codTransaccion"] != DBNull.Value)
                                {
                                    entTransacción transaccion = new entTransacción
                                    {
                                        IdTransaccion = Convert.ToInt32(dr["codTransaccion"]),
                                        // ... asignar otras propiedades de la transacción
                                    };
                                    pedido.IdTransaccion = transaccion;
                                }

                                if (dr.GetOrdinal("estadoTransaccion") != -1 && dr["estadoTransaccion"] != DBNull.Value)
                                {
                                    entEstadoPedido estadoPedido = new entEstadoPedido
                                    {
                                        NombreEstado = dr["estadoTransaccion"].ToString(),
                                        // ... asignar otras propiedades del estado del pedido
                                    };
                                    pedido.IdEstadoPedido = estadoPedido;
                                }

                                if (dr.GetOrdinal("userName") != -1 && dr["userName"] != DBNull.Value)
                                {
                                    entCuenta repartidor = new entCuenta
                                    {
                                        UserName = dr["userName"] != DBNull.Value ? dr["userName"].ToString() : string.Empty,

                                        // ... asignar otras propiedades del repartidor
                                    };
                                    pedido.IdRepartidor = repartidor;
                                }

                                lista.Add(pedido);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al listar pedidos: {e.Message}");
                // Log.Error($"Error al listar pedidos: {e.Message}", e);
                throw; // Lanza la excepción nuevamente para que puedas verla en el lugar que llama a este método.
            }

            return lista;
        }

    }

}

