using Farmacia.Entidades;
using Farmacia.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Servicio
{
    public class ServicioDroga
    {
        private ConexionBd _conexion;
        private RepositorioDrogas _repositorio;


        public List<Droga> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioDrogas(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Droga droga)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioDrogas(_conexion.AbrirConexion());
                _repositorio.Guardar(droga);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public bool Existe(Droga droga)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioDrogas(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(droga);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Droga droga)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioDrogas(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(droga);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Droga GetDroga(string nombreDroga)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioDrogas(_conexion.AbrirConexion());
                var droga = _repositorio.GetDroga(nombreDroga);
                _conexion.CerrarConexion();
                return droga;
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
                _repositorio = new RepositorioDrogas(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public Droga GetDrogaPorId(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioDrogas(_conexion.AbrirConexion());
                var droga = _repositorio.GetDrogaPorId(id);
                _conexion.CerrarConexion();
                return droga;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
