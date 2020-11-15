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
    public class ServicioObraSocial
    {
        private ConexionBd _conexion;
        private RepositorioObrasSociales _repositorio;


        public List<ObraSocial> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioObrasSociales(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(ObraSocial obraSocial)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioObrasSociales(_conexion.AbrirConexion());
                _repositorio.Guardar(obraSocial);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public bool Existe(ObraSocial obraSocial)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioObrasSociales(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(obraSocial);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(ObraSocial obraSocial)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioObrasSociales(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(obraSocial);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ObraSocial GetObraSocial(string nombreObraSocial)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioObrasSociales(_conexion.AbrirConexion());
                var obraSocial = _repositorio.GetObraSocial(nombreObraSocial);
                _conexion.CerrarConexion();
                return obraSocial;
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
                _repositorio = new RepositorioObrasSociales(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public ObraSocial GetObraSocialPorId(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioObrasSociales(_conexion.AbrirConexion());
                var obraSocial = _repositorio.GetObraSocialPorId(id);
                _conexion.CerrarConexion();
                return obraSocial;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
