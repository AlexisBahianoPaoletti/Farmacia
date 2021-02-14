using Farmacia.Entidades.Entidades;
using Farmacia.Repositorio;
using Farmacia.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Servicio.Servicios
{
    public class ServicioCompra
    {
        private ConexionBd _conexion;
        private SqlTransaction transaction;
        private RepositorioCompras Repositoriocompra;
        private RepositorioComprasMedicamentos RepositoriocompraMedicamento;
        private RepositorioMedicamentos Repositoriomedicamentos;
        public void Guardar(Compra compra)
        {
            try
            {
                _conexion = new ConexionBd();
                SqlConnection cn = _conexion.AbrirConexion();
                transaction = cn.BeginTransaction();
                Repositoriocompra = new RepositorioCompras(cn, transaction);
                RepositoriocompraMedicamento = new RepositorioComprasMedicamentos(cn, transaction);
                Repositoriomedicamentos = new RepositorioMedicamentos(cn, transaction);
                Repositoriocompra.Guardar(compra);
                foreach (var cm in compra.ComprasMedicamentos)
                {
                    cm.Compra = compra;
                    RepositoriocompraMedicamento.Guardar(cm);
                    Repositoriomedicamentos.ModificarStok(cm.Cantidad, cm.Medicamento.MedicamentoId);

                }
                transaction.Commit();
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
        }
    }
}
