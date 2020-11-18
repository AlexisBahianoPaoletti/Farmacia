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
    public class ServicioMedicamento
    {
        private RepositorioMedicamentos _repositorioMedicamentos;
        private RepositorioDrogas _repositorioDrogas;
        private RepositorioTiposDeMedicamentos _repositorioTiposDeMedicamentos;
        private RepositorioFormasFarmaceuticas _repositorioFormasFarmaceuticas;
        private RepositorioLaboratorios _repositorioLaboratorios;

        private ConexionBd _conexion;
        public Medicamento GetMedicamentoPorId(int id)
        {
            _conexion = new ConexionBd();
            _repositorioDrogas = new RepositorioDrogas(_conexion.AbrirConexion());
            _repositorioTiposDeMedicamentos = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
            _repositorioFormasFarmaceuticas = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
            _repositorioLaboratorios = new RepositorioLaboratorios(_conexion.AbrirConexion());
            _repositorioMedicamentos = new RepositorioMedicamentos(_conexion.AbrirConexion(), _repositorioDrogas,
                _repositorioTiposDeMedicamentos, _repositorioFormasFarmaceuticas, _repositorioLaboratorios);
            var p = _repositorioMedicamentos.GetMedicamentoPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Medicamento> GetLista()
        {
            _conexion = new ConexionBd();          
            _repositorioDrogas = new RepositorioDrogas(_conexion.AbrirConexion());
            _repositorioTiposDeMedicamentos = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
            _repositorioFormasFarmaceuticas = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
            _repositorioLaboratorios = new RepositorioLaboratorios(_conexion.AbrirConexion());
            _repositorioMedicamentos = new RepositorioMedicamentos(_conexion.AbrirConexion(), _repositorioDrogas,
                _repositorioTiposDeMedicamentos, _repositorioFormasFarmaceuticas, _repositorioLaboratorios); var lista = _repositorioMedicamentos.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Medicamento medicamento)
        {
            _conexion = new ConexionBd();
            _repositorioTiposDeMedicamentos = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
            _repositorioFormasFarmaceuticas = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
            _repositorioLaboratorios = new RepositorioLaboratorios(_conexion.AbrirConexion());
            _repositorioMedicamentos = new RepositorioMedicamentos(_conexion.AbrirConexion(), _repositorioDrogas,
                _repositorioTiposDeMedicamentos, _repositorioFormasFarmaceuticas, _repositorioLaboratorios);
            _repositorioMedicamentos.Guardar(medicamento);
            _conexion.CerrarConexion();
        }

        public void Borrar(int id)
        {
            _conexion = new ConexionBd();
            _repositorioTiposDeMedicamentos = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
            _repositorioFormasFarmaceuticas = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
            _repositorioLaboratorios = new RepositorioLaboratorios(_conexion.AbrirConexion());
            _repositorioMedicamentos = new RepositorioMedicamentos(_conexion.AbrirConexion(), _repositorioDrogas,
                _repositorioTiposDeMedicamentos, _repositorioFormasFarmaceuticas, _repositorioLaboratorios); _repositorioMedicamentos.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Medicamento medicamento)
        {
            _conexion = new ConexionBd();
            _repositorioDrogas = new RepositorioDrogas(_conexion.AbrirConexion());
            _repositorioTiposDeMedicamentos = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
            _repositorioFormasFarmaceuticas = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
            _repositorioLaboratorios = new RepositorioLaboratorios(_conexion.AbrirConexion());

            _repositorioMedicamentos = new RepositorioMedicamentos(_conexion.AbrirConexion(), _repositorioDrogas,
                _repositorioTiposDeMedicamentos, _repositorioFormasFarmaceuticas, _repositorioLaboratorios);
            var Existe = _repositorioMedicamentos.Existe(medicamento);
            _conexion.CerrarConexion();

            return Existe;
        }

        public bool EstaRelacionado(Medicamento medicamento)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorioTiposDeMedicamentos = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
                _repositorioFormasFarmaceuticas = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
                _repositorioLaboratorios = new RepositorioLaboratorios(_conexion.AbrirConexion());
                _repositorioMedicamentos = new RepositorioMedicamentos(_conexion.AbrirConexion(), _repositorioDrogas,
                    _repositorioTiposDeMedicamentos, _repositorioFormasFarmaceuticas, _repositorioLaboratorios); var estaRelacionado = _repositorioMedicamentos.EstaRelacionado(medicamento);
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
