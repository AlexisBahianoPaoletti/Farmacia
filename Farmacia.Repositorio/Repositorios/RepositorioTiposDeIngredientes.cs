using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioTiposDeIngredientes
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioTiposDeIngredientes(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public TipoDeIngrediente GetTipoDeIngredientePorId(int id)
        {
            try
            {
                TipoDeIngrediente tipoDeIngrediente = null;
                string cadenaComando = "SELECT TipoDeIngredienteId, TipoDeIngrediente FROM TiposDeIngredientes WHERE TipoDeIngredienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipoDeIngrediente = ConstruirTipoDeIngrediente(reader);
                    reader.Close();
                }

                return tipoDeIngrediente;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDeIngrediente> GetLista()
        {
            List<TipoDeIngrediente> lista = new List<TipoDeIngrediente>();
            try
            {
                string cadenaComando = "SELECT TipoDeIngredienteId, TipoDeIngrediente FROM TiposDeIngredientes";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoDeIngrediente tipoDeIngrediente = ConstruirTipoDeIngrediente(reader);
                    lista.Add(tipoDeIngrediente);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private TipoDeIngrediente ConstruirTipoDeIngrediente(SqlDataReader reader)
        {
            return new TipoDeIngrediente
            {
                TipoDeIngredienteId = reader.GetInt32(0),
                TipoDeIngredientes = reader.GetString(1)
            };
        }

        public void Guardar(TipoDeIngrediente tipoDeIngrediente)
        {
            if (tipoDeIngrediente.TipoDeIngredienteId == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO TiposDeIngredientes VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDeIngrediente.TipoDeIngredientes);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    tipoDeIngrediente.TipoDeIngredienteId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE TiposDeIngredientes SET TipoDeIngrediente=@nombre WHERE TipoDeIngredienteId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDeIngrediente.TipoDeIngredientes);
                    comando.Parameters.AddWithValue("@id", tipoDeIngrediente.TipoDeIngredienteId);
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
                string cadenaComando = "DELETE FROM TiposDeIngredientes WHERE TipoDeIngredienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeIngrediente tipoDeIngrediente)
        {
            try
            {
                SqlCommand comando;
                if (tipoDeIngrediente.TipoDeIngredienteId == 0)
                {
                    string cadenaComando = "SELECT TipoDeIngredienteId, TipoDeIngrediente FROM TiposDeIngredientes WHERE TipoDeIngrediente=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDeIngrediente.TipoDeIngredientes);

                }
                else
                {
                    string cadenaComando = "SELECT TipoDeIngredienteId, TipoDeIngrediente FROM TiposDeIngredientes WHERE TipoDeIngrediente=@nombre AND TipoDeIngredienteid<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDeIngrediente.TipoDeIngredientes);
                    comando.Parameters.AddWithValue("@id", tipoDeIngrediente.TipoDeIngredienteId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeIngrediente tipoDeIngrediente)
        {
            try
            {
                var CadenaComando = "SELECT TipoDeIngredienteId FROM Proveedores WHERE TipoDeIngredienteId=@id";
                var Comando = new SqlCommand(CadenaComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@id", tipoDeIngrediente.TipoDeIngredienteId);
                var reader = Comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeIngrediente GetTipoDeIngrediente(string TipoDeIngredientes)
        {
            try
            {
                TipoDeIngrediente tipoDeIngrediente = null;
                string cadenaComando = "SELECT TipoDeIngredienteId, TipoDeIngrediente FROM TiposDeIngredientes WHERE TipoDeIngrediente=@nombre";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@nombre", TipoDeIngredientes);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipoDeIngrediente = ConstruirTipoDeIngrediente(reader);
                    reader.Close();
                }

                return tipoDeIngrediente;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

    }
}
