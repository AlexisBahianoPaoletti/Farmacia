using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioVentas
    {
        private SqlConnection cn;
        private SqlTransaction sqlTransaction;

        public RepositorioVentas(SqlConnection cn, SqlTransaction sqlTransaction)
        {
            this.cn = cn;
            this.sqlTransaction = sqlTransaction;
        }

        public void Guardar(Venta venta)
        {
            try
            {
                var CadenaComando = "Insert into Ventas (ClienteId, PrecioTotal, Fecha) Values (@clienteId, @precioTotal, @fecha)";
                var comando = new SqlCommand(CadenaComando, cn, sqlTransaction);
                comando.Parameters.AddWithValue("@clienteId", venta.Cliente.ClienteId);
                comando.Parameters.AddWithValue("@precioTotal", venta.PrecioTotal);
                comando.Parameters.AddWithValue("@fecha", venta.Fecha);
                comando.ExecuteNonQuery();
                CadenaComando = "Select @@Identity";
                comando = new SqlCommand(CadenaComando, cn, sqlTransaction);
                venta.VentaId = (int)(decimal)comando.ExecuteScalar();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
