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
    public class ServicioLaboratorio
    {
        private ConexionBd _conexion;
        private RepositorioLaboratorios _repositorio;


        public List<Laboratorio> GetLista()
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioLaboratorios(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Laboratorio laboratorio)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioLaboratorios(_conexion.AbrirConexion());
                _repositorio.Guardar(laboratorio);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public bool Existe(Laboratorio laboratorio)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioLaboratorios(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(laboratorio);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Laboratorio laboratorio)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioLaboratorios(_conexion.AbrirConexion());
                var estaRelacionado = _repositorio.EstaRelacionado(laboratorio);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Laboratorio GetLaboratorio(string nombreLaboratorio)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioLaboratorios(_conexion.AbrirConexion());
                var laboratorio = _repositorio.GetLaboratorio(nombreLaboratorio);
                _conexion.CerrarConexion();
                return laboratorio;
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
                _repositorio = new RepositorioLaboratorios(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public Laboratorio GetLaboratorioPorId(int id)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorio = new RepositorioLaboratorios(_conexion.AbrirConexion());
                var laboratorio = _repositorio.GetLaboratorioPorId(id);
                _conexion.CerrarConexion();
                return laboratorio;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
