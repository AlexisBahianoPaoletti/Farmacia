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
    public class ServicioCliente
    {
        private RepositorioClientes _repositorioClientes;
        private RepositorioTiposDeDocumentos _repositorioTiposDeDocumentos;
        private RepositorioLocalidades _repositorioLocalidades;
        private RepositorioProvincias _repositorioProvincias;
        private RepositorioClientesObrasSociales _repositorioClientesObrasSociales;
        private RepositorioObrasSociales _repositorioObrasSociales;
        private ConexionBd _conexion;
        private SqlTransaction sqlTransaction;

        public Cliente GetClientePorId(int id)
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
            _repositorioTiposDeDocumentos = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
            _repositorioClientes = new RepositorioClientes(_conexion.AbrirConexion(), _repositorioTiposDeDocumentos, 
                _repositorioLocalidades, _repositorioProvincias);
            _repositorioObrasSociales = new RepositorioObrasSociales(_conexion.AbrirConexion());
            _repositorioClientesObrasSociales = new RepositorioClientesObrasSociales(_conexion.AbrirConexion(), _repositorioClientes, _repositorioObrasSociales, sqlTransaction);

            var p = _repositorioClientes.GetClientePorId(id);
            if (_repositorioClientesObrasSociales.VerificarObraSocial(p))
            {
                p.ClientesObrasSociales = _repositorioClientesObrasSociales.GetLista(p);
            }
            _conexion.CerrarConexion();
            return p;

        }

        public List<Cliente> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                SqlConnection cn = _conexion.AbrirConexion();
                sqlTransaction = cn.BeginTransaction();
                _repositorioProvincias = new RepositorioProvincias(cn, sqlTransaction);
                _repositorioLocalidades = new RepositorioLocalidades(cn, _repositorioProvincias, sqlTransaction);
                _repositorioTiposDeDocumentos = new RepositorioTiposDeDocumentos(cn, sqlTransaction);
                _repositorioClientes = new RepositorioClientes(cn, _repositorioTiposDeDocumentos,
                    _repositorioLocalidades, _repositorioProvincias, sqlTransaction);
                _repositorioObrasSociales = new RepositorioObrasSociales(cn, sqlTransaction);
                _repositorioClientesObrasSociales = new RepositorioClientesObrasSociales(cn, _repositorioClientes, _repositorioObrasSociales, sqlTransaction);
                var lista = _repositorioClientes.GetLista();

                sqlTransaction.Commit();
                foreach (var c in lista)
                {
                    if (_repositorioClientesObrasSociales.VerificarObraSocial(c))
                    {
                        c.ClientesObrasSociales = _repositorioClientesObrasSociales.GetLista(c);
                    }

                }
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception ex) 
            {
                sqlTransaction.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public void Guardar(Cliente cliente)
        {
            try
            {
                _conexion = new ConexionBd();
                SqlConnection cn=_conexion.AbrirConexion();
                sqlTransaction = cn.BeginTransaction();
                _repositorioClientes = new RepositorioClientes(cn, sqlTransaction);
                _repositorioClientesObrasSociales = new RepositorioClientesObrasSociales(cn, sqlTransaction);
                _repositorioClientes.Guardar(cliente);
                foreach (var co in cliente.ClientesObrasSociales)
                {
                    _repositorioClientesObrasSociales.Guardar(co);
                }
                sqlTransaction.Commit();
                _conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw new Exception(ex.Message);                
            }
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

        public bool VerificarObraSocial(Cliente cliente)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorioClientesObrasSociales = new RepositorioClientesObrasSociales(_conexion.AbrirConexion());
                bool VerificarObraSocial=_repositorioClientesObrasSociales.VerificarObraSocial(cliente);
                _conexion.CerrarConexion();
                return VerificarObraSocial;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
