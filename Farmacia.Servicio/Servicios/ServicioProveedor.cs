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
    public class ServicioProveedor
    {
        private RepositorioProveedores _repositorioProveedores;       
        private RepositorioLocalidades _repositorioLocalidades;
        private RepositorioProvincias _repositorioProvincias;
        private RepositorioTiposDeIngredientes _repositorioTiposDeIngredientes;
        private ConexionBd _conexion;
        public Proveedor GetProveedorPorId(int id)
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(),_repositorioProvincias);
            _repositorioTiposDeIngredientes = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
            _repositorioProveedores = new RepositorioProveedores(_conexion.AbrirConexion(), _repositorioTiposDeIngredientes, _repositorioLocalidades, _repositorioProvincias);
            var p = _repositorioProveedores.GetProveedorPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Proveedor> GetLista()
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
            _repositorioTiposDeIngredientes = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
            _repositorioProveedores = new RepositorioProveedores(_conexion.AbrirConexion(), _repositorioTiposDeIngredientes, _repositorioLocalidades, _repositorioProvincias); var lista = _repositorioProveedores.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Proveedor proveedor)
        {
            _conexion = new ConexionBd();
            _repositorioProveedores = new RepositorioProveedores(_conexion.AbrirConexion());
            _repositorioProveedores.Guardar(proveedor);
            _conexion.CerrarConexion();
        }

        public void Borrar(int id)
        {
            _conexion = new ConexionBd();
            _repositorioProveedores = new RepositorioProveedores(_conexion.AbrirConexion());
            _repositorioProveedores.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Proveedor proveedor)
        {
            _conexion = new ConexionBd();
            _repositorioProvincias = new RepositorioProvincias(_conexion.AbrirConexion());
            _repositorioLocalidades = new RepositorioLocalidades(_conexion.AbrirConexion(), _repositorioProvincias);
            _repositorioTiposDeIngredientes = new RepositorioTiposDeIngredientes(_conexion.AbrirConexion());
            _repositorioProveedores = new RepositorioProveedores(_conexion.AbrirConexion(), _repositorioTiposDeIngredientes, _repositorioLocalidades, _repositorioProvincias);
            var Existe = _repositorioProveedores.Existe(proveedor);
            _conexion.CerrarConexion();

            return Existe;
        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            try
            {
                _conexion = new ConexionBd();
                _repositorioProveedores = new RepositorioProveedores(_conexion.AbrirConexion());
                var estaRelacionado = _repositorioProveedores.EstaRelacionado(proveedor);
                _conexion.CerrarConexion();
                return estaRelacionado;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }
}
