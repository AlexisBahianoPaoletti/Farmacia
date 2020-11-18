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
    public class ServicioCliente
    {
        private RepositorioClientes _repositorioClientes;
        private RepositorioTiposDeDocumentos _repositorioTiposDeDocumentos;
        private RepositorioLocalidades _repositorioLocalidades;
        private RepositorioProvincias _repositorioProvincias;
        private ConexionBd _conexion;
        public Cliente GetClientePorId(int id)
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
            _repositorioTiposDeDocumentos = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
            _repositorioClientes = new RepositorioClientes(_conexion.AbrirConexion(), _repositorioTiposDeDocumentos, 
                _repositorioLocalidades, _repositorioProvincias);
            var p = _repositorioClientes.GetClientePorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Cliente> GetLista()
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(),_repositorioProvincias);
            _repositorioTiposDeDocumentos = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
            _repositorioClientes = new RepositorioClientes(_conexion.AbrirConexion(), _repositorioTiposDeDocumentos,
                _repositorioLocalidades, _repositorioProvincias);
            var lista = _repositorioClientes.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Cliente cliente)
        {
            _conexion = new ConexionBd();
            _repositorioClientes = new RepositorioClientes(_conexion.AbrirConexion());
            _repositorioClientes.Guardar(cliente);
            _conexion.CerrarConexion();
        }

        public void Borrar(int id)
        {
            _conexion = new ConexionBd();
            _repositorioClientes = new RepositorioClientes(_conexion.AbrirConexion());
            _repositorioClientes.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Cliente cliente)
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
            _repositorioTiposDeDocumentos = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());

            _repositorioClientes = new RepositorioClientes(_conexion.AbrirConexion(), _repositorioTiposDeDocumentos,
                _repositorioLocalidades, _repositorioProvincias);
            var Existe = _repositorioClientes.Existe(cliente);
            _conexion.CerrarConexion();

            return Existe;
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorioClientes = new RepositorioClientes(_conexion.AbrirConexion());
                var estaRelacionado = _repositorioClientes.EstaRelacionado(cliente);
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
