using Farmacia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio
{
    public class RepositorioDrogas
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioDrogas(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Droga GetDrogaPorId(int id)
        {
            try
            {
                Droga droga = null;
                string cadenaComando = "SELECT DrogaId, NombreDroga FROM Drogas WHERE DrogaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    droga = ConstruirDroga(reader);
                    reader.Close();
                }

                return droga;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Droga> GetLista()
        {
            List<Droga> lista = new List<Droga>();
            try
            {
                string cadenaComando = "SELECT DrogaId, NombreDroga FROM Drogas";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Droga droga = ConstruirDroga(reader);
                    lista.Add(droga);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Droga ConstruirDroga(SqlDataReader reader)
        {
            return new Droga
            {
                DrogaId = reader.GetInt32(0),
                NombreDroga = reader.GetString(1)
            };
        }

        public void Guardar(Droga droga)
        {
            if (droga.DrogaId == 0)
            {
                
                try
                {
                    string cadenaComando = "INSERT INTO Drogas VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", droga.NombreDroga);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    droga.DrogaId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Drogas SET NombreDroga=@nombre WHERE DrogaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", droga.NombreDroga);
                    comando.Parameters.AddWithValue("@id", droga.DrogaId);
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
                string cadenaComando = "DELETE FROM Drogas WHERE DrogaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Droga droga)
        {
            try
            {
                SqlCommand comando;
                if (droga.DrogaId == 0)
                {
                    string cadenaComando = "SELECT DrogaId, NombreDroga FROM Drogas WHERE NombreDroga=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", droga.NombreDroga);

                }
                else
                {
                    string cadenaComando = "SELECT DrogaId, NombreDroga FROM Drogas WHERE NombreDroga=@nombre AND Drogaid<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", droga.NombreDroga);
                    comando.Parameters.AddWithValue("@id", droga.DrogaId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Droga droga)
        {
            try
            {
                var CadenaComando = "SELECT DrogaId FROM Medicamentos WHERE DrogaId=@id";
                var Comando = new SqlCommand(CadenaComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@id", droga.DrogaId);
                var reader = Comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Droga GetDroga(string nombreDroga)
        {
            try
            {
                Droga droga = null;
                string cadenaComando = "SELECT DrogaId, NombreDroga FROM Drogas WHERE NombreDroga=@nombre";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@nombre", nombreDroga);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    droga = ConstruirDroga(reader);
                    reader.Close();
                }

                return droga;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
