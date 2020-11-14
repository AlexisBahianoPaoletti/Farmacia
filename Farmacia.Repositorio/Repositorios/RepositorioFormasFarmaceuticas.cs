using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioFormasFarmaceuticas
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioFormasFarmaceuticas(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public FormaFarmaceutica GetFormaFarmaceuticaPorId(int id)
        {
            try
            {
                FormaFarmaceutica formaFarmaceutica = null;
                string cadenaComando = "SELECT FormaFarmaceuticaId, Descripcion FROM FormasFarmaceuticas WHERE FormaFarmaceuticaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    formaFarmaceutica = ConstruirFormaFarmaceutica(reader);
                    reader.Close();
                }

                return formaFarmaceutica;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<FormaFarmaceutica> GetLista()
        {
            List<FormaFarmaceutica> lista = new List<FormaFarmaceutica>();
            try
            {
                string cadenaComando = "SELECT FormaFarmaceuticaId, Descripcion FROM FormasFarmaceuticas";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    FormaFarmaceutica formaFarmaceutica = ConstruirFormaFarmaceutica(reader);
                    lista.Add(formaFarmaceutica);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private FormaFarmaceutica ConstruirFormaFarmaceutica(SqlDataReader reader)
        {
            return new FormaFarmaceutica
            {
                FormaFarmaceuticaId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public void Guardar(FormaFarmaceutica formaFarmaceutica)
        {
            if (formaFarmaceutica.FormaFarmaceuticaId == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO FormasFarmaceuticas VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", formaFarmaceutica.Descripcion);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    formaFarmaceutica.FormaFarmaceuticaId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE FormasFarmaceuticas SET Descripcion=@nombre WHERE FormaFarmaceuticaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", formaFarmaceutica.Descripcion);
                    comando.Parameters.AddWithValue("@id", formaFarmaceutica.FormaFarmaceuticaId);
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
                string cadenaComando = "DELETE FROM FormasFarmaceuticas WHERE FormaFarmaceuticaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

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
                SqlCommand comando;
                if (formaFarmaceutica.FormaFarmaceuticaId == 0)
                {
                    string cadenaComando = "SELECT FormaFarmaceuticaId, Descripcion FROM FormasFarmaceuticas WHERE Descripcion=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", formaFarmaceutica.Descripcion);

                }
                else
                {
                    string cadenaComando = "SELECT FormaFarmaceuticaId, Descripcion FROM FormasFarmaceuticas WHERE Descripcion=@nombre AND FormaFarmaceuticaid<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", formaFarmaceutica.Descripcion);
                    comando.Parameters.AddWithValue("@id", formaFarmaceutica.FormaFarmaceuticaId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
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
                var CadenaComando = "SELECT FormaFarmaceuticaId FROM Medicamentos WHERE FormaFarmaceuticaId=@id";
                var Comando = new SqlCommand(CadenaComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@id", formaFarmaceutica.FormaFarmaceuticaId);
                var reader = Comando.ExecuteReader();
                return reader.HasRows;
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
                FormaFarmaceutica formaFarmaceutica = null;
                string cadenaComando = "SELECT FormaFarmaceuticaId, Descripcion FROM FormasFarmaceuticas WHERE Descripcion=@nombre";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@nombre", nombreFormaFarmaceutica);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    formaFarmaceutica = ConstruirFormaFarmaceutica(reader);
                    reader.Close();
                }

                return formaFarmaceutica;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
