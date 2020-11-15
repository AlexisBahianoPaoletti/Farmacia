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
    public class ServicioProvincia
    {
        private ConexionBd _conexion;
        private RepositorioProvincias _repositorio;


        public List<Provincia> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                _repositorio.Guardar(provincia);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public bool Existe(Provincia provincia)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(provincia);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(provincia);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Provincia GetProvincia(string nombreProvincia)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var provincia = _repositorio.GetProvincia(nombreProvincia);
                _conexion.CerrarConexion();
                return provincia;
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
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public Provincia GetProvinciaPorId(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioProvincias(_conexion.AbrirConexion());
                var provincia = _repositorio.GetProvinciaPorId(id);
                _conexion.CerrarConexion();
                return provincia;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
