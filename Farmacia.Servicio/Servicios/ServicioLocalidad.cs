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
    public class ServicioLocalidad
    {
        private RepositorioLocalidades _repositorioLocalidades;
        private RepositorioProvincias _repositorioProvincias;
        private ConexionBd _conexion;
        public Localidad GetLocalidadPorId(int id)
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
            var p = _repositorioLocalidades.GetLocalidadPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Localidad> GetLista()
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
            var lista = _repositorioLocalidades.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Localidad localidad)
        {
            _conexion = new ConexionBd();
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion());
            _repositorioLocalidades.Guardar(localidad);
            _conexion.CerrarConexion();
        }

        public void Borrar(int id)
        {
            _conexion = new ConexionBd();
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion());
            _repositorioLocalidades.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Localidad localidad)
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());

            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
            var Existe = _repositorioLocalidades.Existe(localidad);
            _conexion.CerrarConexion();

            return Existe;
        }

        public bool EstaRelacionado(Localidad localidad)
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());

            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
            var Relacionado = _repositorioLocalidades.EstaRelacionado(localidad);
            _conexion.CerrarConexion();

            return Relacionado;
        }


  
    }
}
