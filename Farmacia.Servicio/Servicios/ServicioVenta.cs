using Farmacia.Entidades.Entidades;
using Farmacia.Repositorio;
using Farmacia.Repositorio.Repositorios;
using System;
using System.Data.SqlClient;

namespace Farmacia.Servicio.Servicios
{
    public class ServicioVenta
    {
        private ConexionBd conexion;
        private SqlTransaction sqlTransaction;
        private RepositorioVentas repositorioVentas;
        private RepositorioVentasMedicamentos repositorioVentasMedicamentos;
        private RepositorioMedicamentos repositorioMedicamentos;
        public void Guardar(Venta venta)
        {
            
            try
            {
                conexion = new ConexionBd();
                SqlConnection cn = conexion.AbrirConexion();
                sqlTransaction = cn.BeginTransaction();
                repositorioVentas = new RepositorioVentas(cn, sqlTransaction);
                repositorioVentasMedicamentos = new RepositorioVentasMedicamentos(cn, sqlTransaction);
                repositorioMedicamentos = new RepositorioMedicamentos(cn, sqlTransaction);
                repositorioVentas.Guardar(venta);
                foreach (var vm in venta.ventasMedicamentos)
                {
                    vm.venta = venta;
                    repositorioVentasMedicamentos.Guardar(vm);
                    repositorioMedicamentos.ModificarStok(-vm.Cantidad, vm.medicamento.MedicamentoId);

                }
                sqlTransaction.Commit();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}
