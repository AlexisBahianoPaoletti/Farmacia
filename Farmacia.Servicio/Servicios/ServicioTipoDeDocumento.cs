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
    public class ServicioTipoDeDocumento
    {
        private ConexionBd _conexion;
        private RepositorioTiposDeDocumentos _repositorio;


        public List<TipoDeDocumento> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
                _repositorio.Guardar(tipoDeDocumento);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public bool Existe(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(tipoDeDocumento);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(tipoDeDocumento);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeDocumento GetTipoDeDocumento(string nombreTipoDeDocumento)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
                var tipoDeDocumento = _repositorio.GetTipoDeDocumento(nombreTipoDeDocumento);
                _conexion.CerrarConexion();
                return tipoDeDocumento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public void Borrar(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public TipoDeDocumento GetTipoDeDocumentoPorId(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeDocumentos(_conexion.AbrirConexion());
                var tipoDeDocumento = _repositorio.GetTipoDeDocumentoPorId(id);
                _conexion.CerrarConexion();
                return tipoDeDocumento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
