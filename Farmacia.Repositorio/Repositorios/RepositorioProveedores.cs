using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioProveedores
    {
        private readonly SqlConnection _connection;
        private readonly RepositorioLocalidades _repositorioLocalidades;
        private readonly RepositorioProvincias _repositorioProvincias;
        private readonly RepositorioTiposDeIngredientes _repositorioTiposDeIngredientes;

        public RepositorioProveedores(SqlConnection connection, RepositorioTiposDeIngredientes repositorioTiposDeIngredientes,
                RepositorioLocalidades repositorioLocalidades, RepositorioProvincias repositorioProvincias)
        {
            _connection = connection;
            _repositorioLocalidades = repositorioLocalidades;
            _repositorioProvincias = repositorioProvincias;
            _repositorioTiposDeIngredientes = repositorioTiposDeIngredientes;
        }

        public RepositorioProveedores(SqlConnection connection)
        {
            _connection = connection;
        }


        public Proveedor GetProveedorPorId(int id)
        {
            Proveedor p = null;
            try
            {
                string cadenaComando =
                    "SELECT ProveedorId, CUIT, RazonSocial, PersonaDeContacto, Direccion, LocalidadId, " +
                    "ProvinciaId, TelefonoFijo, TelefonoMovil, CorreoElectronico, TipoDeIngredienteId FROM Proveedores WHERE ProveedorId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirProveedor(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Proveedor> GetLista()
        {
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                string cadenaComando =
                    "SELECT ProveedorId, CUIT, RazonSocial, PersonaDeContacto, Direccion, LocalidadId, " +
                    "ProvinciaId, TelefonoFijo, TelefonoMovil, CorreoElectronico, TipoDeIngredienteId FROM Proveedores";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Proveedor proveedor = ConstruirProveedor(reader);
                    lista.Add(proveedor);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Proveedor ConstruirProveedor(SqlDataReader reader)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.ProveedorId = reader.GetInt32(0);
            proveedor.CUIT = reader.GetString(1);
            proveedor.RazonSocial = reader.GetString(2);
            proveedor.PersonaDeContacto = reader.GetString(3);
            proveedor.Direccion = reader.GetString(4);
            proveedor.Localidad = _repositorioLocalidades.GetLocalidadPorId(reader.GetInt32(5));
            proveedor.Provincia = _repositorioProvincias.GetProvinciaPorId(reader.GetInt32(6));
            proveedor.TelefonoFijo = reader.GetString(7);
            proveedor.TelefonoMovil = reader.GetString(8);
            proveedor.CorreoElectronico = reader.GetString(9);
            proveedor.TipoDeIngrediente = _repositorioTiposDeIngredientes.GetTipoDeIngredientePorId(reader.GetInt32(10));


            return proveedor;

        }

        public void Guardar(Proveedor proveedor)
        {

            if (proveedor.ProveedorId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Proveedores (CUIT, RazonSocial, PersonaDeContacto, Direccion, LocalidadId, " +
                    "ProvinciaId, TelefonoFijo, TelefonoMovil, CorreoElectronico, TipoDeIngredienteId) VALUES (@cuit, @razonSocial, " +
                    "@personaDeContacto, @direccion, @localidad, @provincia, @telefonoFijo, @telefonoMovil, @correoElectronico, @tipoDeingrediente)";

                    var comando = new SqlCommand(cadenaComando, _connection);

                    comando.Parameters.AddWithValue("@cuit", proveedor.CUIT);
                    comando.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);     
                    comando.Parameters.AddWithValue("@personaDeContacto", proveedor.PersonaDeContacto);
                    comando.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                    comando.Parameters.AddWithValue("@localidad", proveedor.Localidad.LocalidadId);
                    comando.Parameters.AddWithValue("@provincia", proveedor.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@telefonoFijo", proveedor.TelefonoFijo);
                    comando.Parameters.AddWithValue("@telefonoMovil", proveedor.TelefonoMovil);
                    comando.Parameters.AddWithValue("@correoElectronico", proveedor.CorreoElectronico);
                    comando.Parameters.AddWithValue("@tipoDeingrediente", proveedor.TipoDeIngrediente.TipoDeIngredienteId);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    proveedor.ProveedorId = id;


                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {
                    var cadenaDeComando = "UPDATE Proveedores SET CUIT=@cuit, RazonSocial=@razonSocial, PersonaDeContacto=@personaDeContacto, " +
                        "Direccion=@direccion, LocalidadId=@localidad, ProvinciaId=@provincia, TelefonoFijo=@telefonoFijo, " +
                        "TelefonoMovil=@telefonoMovil, CorreoElectronico=@correoElectronico, TipoDeIngredienteId=@tipoDeingrediente WHERE ProveedorId=@id";
                    var comando = new SqlCommand(cadenaDeComando, _connection);

                    comando.Parameters.AddWithValue("@cuit", proveedor.CUIT);
                    comando.Parameters.AddWithValue("@razonSocial", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@personaDeContacto", proveedor.PersonaDeContacto);
                    comando.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                    comando.Parameters.AddWithValue("@localidad", proveedor.Localidad.LocalidadId);
                    comando.Parameters.AddWithValue("@provincia", proveedor.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@telefonoFijo", proveedor.TelefonoFijo);
                    comando.Parameters.AddWithValue("@telefonoMovil", proveedor.TelefonoMovil);
                    comando.Parameters.AddWithValue("@correoElectronico", proveedor.CorreoElectronico);
                    comando.Parameters.AddWithValue("@tipoDeingrediente", proveedor.TipoDeIngrediente.TipoDeIngredienteId);
                    comando.Parameters.AddWithValue("@id", proveedor.ProveedorId);


                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }


            }


        }

        public void Borrar(int id)
        {
            try
            {
                string cadenaComando = "DELETE FROM Proveedores WHERE ProveedorId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                SqlCommand comando;
                if (proveedor.ProveedorId == 0)
                {
                    string cadenaComando = "SELECT ProveedorId FROM Proveedores WHERE CUIT=@cuit";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@cuit", proveedor.CUIT);

                }
                else
                {
                    string cadenaComando = "SELECT ProveedorId FROM Proveedores WHERE CUIT=@cuit AND ProveedorId<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@cuit", proveedor.CUIT);
                    comando.Parameters.AddWithValue("@id", proveedor.ProveedorId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            return false;
        }


    }
}
