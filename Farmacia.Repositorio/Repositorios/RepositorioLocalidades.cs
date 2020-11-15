using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioLocalidades
    {
        private readonly SqlConnection _connection;
        private readonly RepositorioProvincias _repositorioProvincias;

        public RepositorioLocalidades(SqlConnection connection, RepositorioProvincias repositorioProvincias)
        {
            _connection = connection;
            _repositorioProvincias = repositorioProvincias;
        }

        public RepositorioLocalidades(SqlConnection connection)
        {
            _connection = connection;
        }


        public Localidad GetLocalidadPorId(int id)
        {
            Localidad p = null;
            try
            {
                string cadenaComando =
                    "SELECT LocalidadId, NombreLocalidad, ProvinciaId FROM Localidades WHERE LocalidadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirLocalidad(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Localidad> GetLista()
        {
            List<Localidad> lista = new List<Localidad>();
            try
            {
                string cadenaComando =
                    "SELECT LocalidadId, NombreLocalidad, ProvinciaId FROM Localidades";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Localidad localidad = ConstruirLocalidad(reader);
                    lista.Add(localidad);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Localidad ConstruirLocalidad(SqlDataReader reader)
        {
            Localidad localidad = new Localidad();
            localidad.LocalidadId = reader.GetInt32(0);
            localidad.NombreLocalidad = reader.GetString(1);
            localidad.Provincia =_repositorioProvincias.GetProvinciaPorId(reader.GetInt32(2));
            return localidad;

        }

        public void Guardar(Localidad localidad)
        {

                if (localidad.LocalidadId==0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Localidades (NombreLocalidad, ProvinciaId) VALUES (@nombre, @provincia)";
                    var comando = new SqlCommand(cadenaComando, _connection);

                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@provincia", localidad.Provincia.ProvinciaId);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    localidad.LocalidadId = id;


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
                    var cadenaDeComando = "UPDATE Localidades SET NombreLocalidad=@nombre, ProvinciaId=@provincia WHERE LocalidadId=@id";
                    var comando = new SqlCommand(cadenaDeComando, _connection);

                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@provincia", localidad.Provincia.ProvinciaId);
                    comando.Parameters.AddWithValue("@id", localidad.LocalidadId);


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
                string cadenaComando = "DELETE FROM Localidades WHERE LocalidadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                SqlCommand comando;
                if (localidad.LocalidadId == 0)
                {
                    string cadenaComando = "SELECT LocalidadId, NombreLocalidad, ProvinciaId FROM Localidades WHERE NombreLocalidad=@nombre";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);

                }
                else
                {
                    string cadenaComando = "SELECT LocalidadId, NombreLocalidad, ProvinciaId FROM Localidades WHERE NombreLocalidad=@nombre AND LocalidadId<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", localidad.NombreLocalidad);
                    comando.Parameters.AddWithValue("@id", localidad.LocalidadId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Localidad localidad)
        {
            try
            {
                var CadenaComando = "SELECT LocalidadId FROM Clientes WHERE LocalidadId=@id";
                var Comando = new SqlCommand(CadenaComando, _connection);
                Comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                var reader = Comando.ExecuteReader();
                if (!reader.HasRows)
                {
                    CadenaComando = "SELECT LocalidadId FROM Proveedores WHERE LocalidadId=@id";
                    Comando = new SqlCommand(CadenaComando, _connection);
                    Comando.Parameters.AddWithValue("@id", localidad.LocalidadId);
                    reader = Comando.ExecuteReader();

                }
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


    }
}
