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
    public class ServicioFormaFarmaceutica
    {
        private ConexionBd _conexion;
        private RepositorioFormasFarmaceuticas _repositorio;


        public List<FormaFarmaceutica> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(FormaFarmaceutica formaFarmaceutica)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
                _repositorio.Guardar(formaFarmaceutica);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public bool Existe(FormaFarmaceutica formaFarmaceutica)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(formaFarmaceutica);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(FormaFarmaceutica formaFarmaceutica)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(formaFarmaceutica);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public FormaFarmaceutica GetFormaFarmaceutica(string nombreFormaFarmaceutica)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
                var formaFarmaceutica = _repositorio.GetFormaFarmaceutica(nombreFormaFarmaceutica);
                _conexion.CerrarConexion();
                return formaFarmaceutica;
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
                _repositorio = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public FormaFarmaceutica GetFormaFarmaceuticaPorId(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioFormasFarmaceuticas(_conexion.AbrirConexion());
                var formaFarmaceutica = _repositorio.GetFormaFarmaceuticaPorId(id);
                _conexion.CerrarConexion();
                return formaFarmaceutica;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
