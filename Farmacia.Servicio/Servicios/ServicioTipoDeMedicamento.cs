using Farmacia.Entidades;
using Farmacia.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Servicio
{
    public class ServicioTipoDeMedicamento
    {
        private ConexionBd _conexion;
        private RepositorioTiposDeMedicamentos _repositorio;


        public List<TipoDeMedicamento> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeMedicamento tipoDeMedicamento)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
                _repositorio.Guardar(tipoDeMedicamento);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public bool Existe(TipoDeMedicamento tipoDeMedicamento)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(tipoDeMedicamento);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeMedicamento tipoDeMedicamento)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(tipoDeMedicamento);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeMedicamento GetTipoDeMedicamento(string nombreTipoDeMedicamento)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
                var tipoDeMedicamento = _repositorio.GetTiposDeMedicamento(nombreTipoDeMedicamento);
                _conexion.CerrarConexion();
                return tipoDeMedicamento;
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
                _repositorio = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public TipoDeMedicamento GetTipoDeMedicamentoPorId(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioTiposDeMedicamentos(_conexion.AbrirConexion());
                var tipoDeMedicamento = _repositorio.GetTiposDeMedicamentoPorId(id);
                _conexion.CerrarConexion();
                return tipoDeMedicamento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
