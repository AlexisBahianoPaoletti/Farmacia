using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioClientes
    {
        private readonly SqlConnection _connection;
        private readonly RepositorioTiposDeDocumentos _repositorioTiposDeDocumentos;
        private readonly RepositorioLocalidades _repositorioLocalidades;
        private readonly RepositorioProvincias _repositorioProvincias;
        private SqlTransaction sqlTransaction;

        public RepositorioClientes(SqlConnection connection, RepositorioTiposDeDocumentos repositorioTiposDeDocumentos,
                RepositorioLocalidades repositorioLocalidades, RepositorioProvincias repositorioProvincias)
        {
            _connection = connection;
            _repositorioTiposDeDocumentos = repositorioTiposDeDocumentos;
            _repositorioLocalidades = repositorioLocalidades;
            _repositorioProvincias = repositorioProvincias;
        }

        public RepositorioClientes(SqlConnection connection)
        {
            _connection = connection;
        }

        public RepositorioClientes(SqlConnection _connection, SqlTransaction sqlTransaction)
        {
            this._connection = _connection;
            this.sqlTransaction = sqlTransaction;
        }

        public RepositorioClientes(SqlConnection _connection, RepositorioTiposDeDocumentos repositorioTiposDeDocumentos, RepositorioLocalidades repositorioLocalidades, RepositorioProvincias repositorioProvincias, SqlTransaction sqlTransaction1)
        {
            this._connection = _connection;
            this._repositorioTiposDeDocumentos = repositorioTiposDeDocumentos;
            this._repositorioLocalidades = repositorioLocalidades;
            this._repositorioProvincias = repositorioProvincias;
            this.sqlTransaction = sqlTransaction1;
        }

        public Cliente GetClientePorId(int id)
        {
            Cliente p = null;
            try
            {
                string cadenaComando =
                    "SELECT ClienteId, Nombre, Apellido, TipoDeDocumentoId, NroDocumento, Direccion, LocalidadId, " +
                    "ProvinciaId, TelefonoFijo, TelefonoMovil, CorreoElectronico FROM Clientes WHERE ClienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection, sqlTransaction);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirCliente(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Cliente> GetLista()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                string cadenaComando =
                    "SELECT ClienteId, Nombre, Apellido, TipoDeDocumentoId, NroDocumento, Direccion, LocalidadId, " +
                    "ProvinciaId, TelefonoFijo, TelefonoMovil, CorreoElectronico FROM Clientes";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection, sqlTransaction);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = ConstruirCliente(reader);
                    lista.Add(cliente);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Cliente ConstruirCliente(SqlDataReader reader)
        {
            Cliente cliente = new Cliente();
            cliente.ClienteId = reader.GetInt32(0);
            cliente.Nombre = reader.GetString(1);
            cliente.Apellido = reader.GetString(2);
            cliente.TipoDeDocumento = _repositorioTiposDeDocumentos.GetTipoDeDocumentoPorId(reader.GetInt32(3));
            cliente.NroDocumento = reader.GetString(4);
            cliente.Direccion = reader.GetString(5);
            cliente.Localidad = _repositorioLocalidades.GetLocalidadPorId(reader.GetInt32(6));
            cliente.Provincia = _repositorioProvincias.GetProvinciaPorId(reader.GetInt32(7));
            cliente.TelefonoFijo = reader.GetString(8);
            cliente.TelefonoMovil = reader.GetString(9);
            cliente.CorreoElectronico = reader.GetString(10);


            return cliente;

        }

        public void Guardar(Cliente cliente)
        {

            if (cliente.ClienteId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Clientes (Nombre, Apellido, TipoDeDocumentoId, NroDocumento, Direccion, LocalidadId, " +
                    "ProvinciaId, TelefonoFijo, TelefonoMovil, CorreoElectronico) VALUES (@nombre, @apellido, @tipoDocumento, @nroDocumento, " +
                    "@direccion, @localidad, @provincia, @telefonoFijo, @telefonoMovil, @correoElectronico)";
                    var comando = new SqlCommand(cadenaComando, _connection, sqlTransaction);

                    comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    comando.Parameters.AddWithValue("@tipoDocumento", cliente.TipoDeDocumento.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@nroDocumento", cliente.NroDocumento);
                    comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    comando.Parameters.AddWithValue("@localidad", cliente.Localidad.LocalidadId);
                    comando.Parameters.AddWithValue("@provincia", cliente.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@telefonoFijo", cliente.TelefonoFijo);
                    comando.Parameters.AddWithValue("@telefonoMovil", cliente.TelefonoMovil);
                    comando.Parameters.AddWithValue("@correoElectronico", cliente.CorreoElectronico);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection, sqlTransaction);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    cliente.ClienteId = id;


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
                    var cadenaDeComando = "UPDATE Clientes SET Nombre=@nombre, Apellido=@apellido, TipoDeDocumentoId=@tipoDocumento, " +
                        "NroDocumento=@nroDocumento, Direccion=@direccion, LocalidadId=@localidad, ProvinciaId=@provincia," +
                        "TelefonoFijo=@telefonoFijo, TelefonoMovil=@telefonoMovil, CorreoElectronico=@correoElectronico WHERE ClienteId=@id";
                    var comando = new SqlCommand(cadenaDeComando, _connection, sqlTransaction);

                    comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    comando.Parameters.AddWithValue("@tipoDocumento", cliente.TipoDeDocumento.TipoDeDocumentoId);
                    comando.Parameters.AddWithValue("@nroDocumento", cliente.NroDocumento);
                    comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
                    comando.Parameters.AddWithValue("@localidad", cliente.Localidad.LocalidadId);
                    comando.Parameters.AddWithValue("@provincia", cliente.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@telefonoFijo", cliente.TelefonoFijo);
                    comando.Parameters.AddWithValue("@telefonoMovil", cliente.TelefonoMovil);
                    comando.Parameters.AddWithValue("@correoElectronico", cliente.CorreoElectronico);
                    comando.Parameters.AddWithValue("@id", cliente.ClienteId);


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
                string cadenaComando = "DELETE FROM Clientes WHERE ClienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                SqlCommand comando;
                if (cliente.ClienteId == 0)
                {
                    string cadenaComando = "SELECT ClienteId FROM Clientes WHERE NroDocumento=@nroDocumento";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nroDocumento", cliente.NroDocumento);

                }
                else
                {
                    string cadenaComando = "SELECT ClienteId FROM Clientes WHERE NroDocumento=@nroDocumento AND ClienteId<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nroDocumento", cliente.NroDocumento);
                    comando.Parameters.AddWithValue("@id", cliente.ClienteId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            return false;
        }

    }
}
