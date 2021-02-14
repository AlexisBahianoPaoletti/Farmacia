using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioCompras
    {
        private SqlConnection cn;
        private SqlTransaction transaction;

        public RepositorioCompras(SqlConnection cn, SqlTransaction transaction)
        {
            this.cn = cn;
            this.transaction = transaction;
        }

        public void Guardar(Compra compra)
        {
            try
            {
                var CadenaComando = "Insert into Compras (ProveedorId, Fecha) Values (@proveedorId, @fecha)";
                var comando = new SqlCommand(CadenaComando, cn, transaction);
                comando.Parameters.AddWithValue("@proveedorId", compra.Proveedor.ProveedorId);
                comando.Parameters.AddWithValue("@fecha", compra.Fecha);
                comando.ExecuteNonQuery();
                CadenaComando = "Select @@Identity"; 
                comando = new SqlCommand(CadenaComando, cn, transaction);
                compra.CompraId = (int)(decimal)comando.ExecuteScalar();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
