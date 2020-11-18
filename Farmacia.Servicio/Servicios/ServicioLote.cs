using Farmacia.Entidades.Entidades;
using Farmacia.Repositorio;
using Farmacia.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Servicio.Servicios
{
    public class ServicioLote
    {
        private RepositorioLotes _repositorioLotes;
        private RepositorioDrogas _repositorioDrogas;
        private RepositorioTiposDeMedicamentos _repositorioTiposDeMedicamentos;
        private RepositorioFormasFarmaceuticas _repositorioFormasFarmaceuticas;
        private RepositorioLaboratorios _repositorioLaboratorios;
        private RepositorioMedicamentos _repositorioMedicamentos;
        private ConexionBd _conexion;
        public Lote GetLotePorId(int id)
        {
            _conexion = new ConexionBd();
            _repositorioDrogas = new RepositorioDrogas(_conexion.AbrirConexion());
            _repositorioTiposDeMedicamentos = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
            _repositorioFormasFarmaceuticas = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
            _repositorioLaboratorios = new RepositorioLaboratorios(_conexion.AbrirConexion());
            _repositorioMedicamentos = new RepositorioMedicamentos(_conexion.AbrirConexion(), _repositorioDrogas, _repositorioTiposDeMedicamentos, 
                _repositorioFormasFarmaceuticas, _repositorioLaboratorios);
            _repositorioLotes = new RepositorioLotes(_conexion.AbrirConexion(), _repositorioMedicamentos);
            var p = _repositorioLotes.GetLotePorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Lote> GetLista()
        {
            _conexion = new ConexionBd();
            _repositorioDrogas = new RepositorioDrogas(_conexion.AbrirConexion());
            _repositorioTiposDeMedicamentos = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
            _repositorioFormasFarmaceuticas = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
            _repositorioLaboratorios = new RepositorioLaboratorios(_conexion.AbrirConexion());
            _repositorioMedicamentos = new RepositorioMedicamentos(_conexion.AbrirConexion(), _repositorioDrogas, _repositorioTiposDeMedicamentos,
                _repositorioFormasFarmaceuticas, _repositorioLaboratorios);
            _repositorioLotes = new RepositorioLotes(_conexion.AbrirConexion(), _repositorioMedicamentos); 
            var lista = _repositorioLotes.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Lote lote)
        {
            _conexion = new ConexionBd();
            _repositorioLotes = new RepositorioLotes(_conexion.AbrirConexion());
            _repositorioLotes.Guardar(lote);
            _conexion.CerrarConexion();
        }

        public void Borrar(int id)
        {
            _conexion = new ConexionBd();
            _repositorioLotes = new RepositorioLotes(_conexion.AbrirConexion());
            _repositorioLotes.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Lote lote)
        {
            _conexion = new ConexionBd();
            _repositorioDrogas = new RepositorioDrogas(_conexion.AbrirConexion());
            _repositorioTiposDeMedicamentos = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
            _repositorioFormasFarmaceuticas = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
            _repositorioLaboratorios = new RepositorioLaboratorios(_conexion.AbrirConexion());
            _repositorioMedicamentos = new RepositorioMedicamentos(_conexion.AbrirConexion(), _repositorioDrogas, _repositorioTiposDeMedicamentos,
                _repositorioFormasFarmaceuticas, _repositorioLaboratorios); _repositorioLotes = new RepositorioLotes(_conexion.AbrirConexion(), _repositorioMedicamentos);
            var Existe = _repositorioLotes.Existe(lote);
            _conexion.CerrarConexion();

            return Existe;
        }

        public bool EstaRelacionado(Lote lote)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorioLotes = new RepositorioLotes(_conexion.AbrirConexion());
                var estaRelacionado = _repositorioLotes.EstaRelacionado(lote);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }
}
