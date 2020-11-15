using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioProvincias
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioProvincias(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Provincia GetProvinciaPorId(int id)
        {
            try
            {
                Provincia provincia = null;

                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    provincia = ConstruirProvincia(reader);
                    reader.Close();
                }

                return provincia;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Provincia> GetLista()
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Provincia provincia = ConstruirProvincia(reader);
                    lista.Add(provincia);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Provincia ConstruirProvincia(SqlDataReader reader)
        {
            return new Provincia
            {
                ProvinciaId = reader.GetInt32(0),
                NombreProvincia = reader.GetString(1)
            };
        }

        public void Guardar(Provincia provincia)
        {
            if (provincia.ProvinciaId == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO Provincias VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    provincia.ProvinciaId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Provincias SET NombreProvincia=@nombre WHERE ProvinciaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);
                    comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
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
                string cadenaComando = "DELETE FROM Provincias WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                SqlCommand comando;
                if (provincia.ProvinciaId == 0)
                {
                    string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);

                }
                else
                {
                    string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nombre AND Provinciaid<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", provincia.NombreProvincia);
                    comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                var CadenaComando = "SELECT ProvinciaId FROM Clientes WHERE ProvinciaId=@id";
                var Comando = new SqlCommand(CadenaComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                var reader = Comando.ExecuteReader();
                if (!reader.HasRows)
                {
                    CadenaComando = "SELECT ProvinciaId FROM Localidades WHERE ProvinciaId=@id";
                    Comando = new SqlCommand(CadenaComando, _sqlConnection);
                    Comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                    reader = Comando.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        CadenaComando = "SELECT ProvinciaId FROM Proveedores WHERE ProvinciaId=@id";
                        Comando = new SqlCommand(CadenaComando, _sqlConnection);
                        Comando.Parameters.AddWithValue("@id", provincia.ProvinciaId);
                        reader = Comando.ExecuteReader();
                    }
                }
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Provincia GetProvincia(string nombreProvincia)
        {
            try
            {
                Provincia provincia = null;
                string cadenaComando = "SELECT ProvinciaId, NombreProvincia FROM Provincias WHERE NombreProvincia=@nombre";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@nombre", nombreProvincia);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    provincia = ConstruirProvincia(reader);
                    reader.Close();
                }

                return provincia;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
