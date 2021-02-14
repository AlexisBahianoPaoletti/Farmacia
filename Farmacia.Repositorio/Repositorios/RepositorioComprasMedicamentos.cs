using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioComprasMedicamentos
    {
        private SqlConnection cn;
        private SqlTransaction transaction;

        public RepositorioComprasMedicamentos(SqlConnection cn, SqlTransaction transaction)
        {
            this.cn = cn;
            this.transaction = transaction;
        }

        public void Guardar(ComprasMedicamentos cm)
        {
            try
            {
                var CadenaComando = "Insert into ComprasMedicamentos (CompraId, MedicamentoId, Cantidad, Precio) Values (@compraId, @medicamentoId, @cantidad, @precio)";
                var comando = new SqlCommand(CadenaComando, cn, transaction);
                comando.Parameters.AddWithValue("@compraId", cm.Compra.CompraId);
                comando.Parameters.AddWithValue("@medicamentoId", cm.Medicamento.MedicamentoId);
                comando.Parameters.AddWithValue("@cantidad", cm.Cantidad);
                comando.Parameters.AddWithValue("@precio", cm.Precio);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }
    }
}
