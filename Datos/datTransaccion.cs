using BODEGA_SOLORZANO.Models.BoSolor;
using System.Data;
using System.Data.SqlClient;

namespace BODEGA_SOLORZANO.Datos
{
    public class datTransaccion
    {
        public static datTransaccion Instancia { get; } = new();

        public bool RegistrarTransaccion(entTransaccion objTran, out int idGenerado, int idUser)
        {
            SqlTransaction tran = null;
            idGenerado = -1;
            bool creado = false;
            try
            {
                using var cn = Conexion.ObtenerConexion();
                using var cmd = new SqlCommand("spIniciarTransaccion", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Iniciar la transacción
                tran = cn.BeginTransaction();

                cmd.Parameters.AddWithValue("@codTransaccion", objTran.CodTransaccion);
                cmd.Parameters.AddWithValue("@tipoTransaccion", objTran.TipoTransaccion);
                cmd.Parameters.AddWithValue("@montoBruto", objTran.MontoBruto);
                cmd.Parameters.AddWithValue("@descuento", objTran.Descuento);
                cmd.Parameters.AddWithValue("@montoTotal", objTran.MontoTotal);
                cmd.Parameters.AddWithValue("@estadoTransaccion", objTran.EstadoTransaccion);
                cmd.Parameters.AddWithValue("@descuento", objTran.Descuento);
                cmd.Parameters.AddWithValue("@montoTotal", objTran.MontoTotal);
                cmd.Parameters.AddWithValue("@estadoTransaccion", objTran.EstadoTransaccion);
                cmd.Parameters.AddWithValue("@idMetodoPago", objTran.IdMetodo.IdMetodoPago);
                if (objTran.IdCliente.IdCliente > 0)
                {
                    cmd.Parameters.AddWithValue("@idPersona", objTran.IdCliente.IdCliente);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idPersona", objTran.IdProveedor.IdProveedor);
                }
                cmd.Parameters.AddWithValue("@idUsuario", idUser);
                SqlParameter id = new SqlParameter("@idTransaccion", 0);
                id.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id);

                cn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    idGenerado = Convert.ToInt32(cmd.Parameters["@idTransaccion"].Value);
                    creado = true;
                }

                if (idGenerado == -1)
                {
                    throw new ApplicationException("id Generado");
                }
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                creado = false;
                throw new ApplicationException("Error al generar la transacción");
            }
            return creado;
        }

        public bool RegistrarDetalleTransaccion(entDetalleTransaccion objDetTran, int idTransaccion)
        {
            bool creado = false;
            try
            {
                using var cn = Conexion.ObtenerConexion();
                using var cmd = new SqlCommand("spRegistrarDetalleTransaccion", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@idTransaccion", idTransaccion);
                cmd.Parameters.AddWithValue("@idProducto", objDetTran.Producto.IdProducto);
                cmd.Parameters.AddWithValue("@cantidad", objDetTran.Cantidad);
                cmd.Parameters.AddWithValue("@subtotal", objDetTran.SubTotal);

                cn.Open();
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    creado = true;
                }
            }
            catch (Exception e)
            {
                creado = false;
                throw new ApplicationException("Error al generar la transacción");
            }
            return creado;
        }
    }
}
