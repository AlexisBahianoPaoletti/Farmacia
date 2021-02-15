using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioVentasMedicamentos
    {
        private SqlConnection cn;
        private SqlTransaction sqlTransaction;

        public RepositorioVentasMedicamentos(SqlConnection cn, SqlTransaction sqlTransaction)
        {
            this.cn = cn;
            this.sqlTransaction = sqlTransaction;
        }

        public void Guardar(VentasMedicamentos vm)
        {
            try
            {
                var CadenaComando = "Insert into VentasMedicamentos (VentaId, MedicamentoId, Cantidad, Precio) Values (@ventaId, @medicamentoId, @cantidad, @precio)";
                var comando = new SqlCommand(CadenaComando, cn, sqlTransaction);
                comando.Parameters.AddWithValue("@ventaId", vm.venta.VentaId);
                comando.Parameters.AddWithValue("@medicamentoId", vm.medicamento.MedicamentoId);
                comando.Parameters.AddWithValue("@cantidad", vm.Cantidad);
                comando.Parameters.AddWithValue("@precio", vm.Precio);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
