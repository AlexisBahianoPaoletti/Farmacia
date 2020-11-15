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
    public class ServicioTipoDeIngrediente
    {
        private ConexionBd _conexion;
        private RepositorioTiposDeIngredientes _repositorio;


        public List<TipoDeIngrediente> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeIngrediente tipoDeIngrediente)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
                _repositorio.Guardar(tipoDeIngrediente);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public bool Existe(TipoDeIngrediente tipoDeIngrediente)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(tipoDeIngrediente);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeIngrediente tipoDeIngrediente)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(tipoDeIngrediente);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeIngrediente GetTipoDeIngrediente(string nombreTipoDeIngrediente)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
                var tipoDeIngrediente = _repositorio.GetTipoDeIngrediente(nombreTipoDeIngrediente);
                _conexion.CerrarConexion();
                return tipoDeIngrediente;
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
                _repositorio = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public TipoDeIngrediente GetTipoDeIngredientePorId(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
                var tipoDeIngrediente = _repositorio.GetTipoDeIngredientePorId(id);
                _conexion.CerrarConexion();
                return tipoDeIngrediente;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
