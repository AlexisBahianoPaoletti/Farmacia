using Farmacia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio
{
    public class RepositorioTiposDeMedicamentos
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioTiposDeMedicamentos(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        
        public TipoDeMedicamento GetTiposDeMedicamentoPorId(int id)
        {
            try
            {
                TipoDeMedicamento tiposDeMedicamento = null;
                string cadenaComando = "SELECT TipoDeMedicamentoId, Descripcion FROM TiposDeMedicamentos WHERE TipoDeMedicamentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tiposDeMedicamento = ConstruirTiposDeMedicamento(reader);
                    reader.Close();
                }

                return tiposDeMedicamento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDeMedicamento> GetLista()
        {
            List<TipoDeMedicamento> lista = new List<TipoDeMedicamento>();
            try
            {
                string cadenaComando = "SELECT TipoDeMedicamentoId, Descripcion FROM TiposDeMedicamentos";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoDeMedicamento tiposDeMedicamento = ConstruirTiposDeMedicamento(reader);
                    lista.Add(tiposDeMedicamento);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private TipoDeMedicamento ConstruirTiposDeMedicamento(SqlDataReader reader)
        {
            return new TipoDeMedicamento
            {
                TipoDeMedicamentoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public void Guardar(TipoDeMedicamento tiposDeMedicamento)
        {
            if (tiposDeMedicamento.TipoDeMedicamentoId == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO TiposDeMedicamentos VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tiposDeMedicamento.Descripcion);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    tiposDeMedicamento.TipoDeMedicamentoId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE TiposDeMedicamentos SET Descripcion=@nombre WHERE TipoDeMedicamentoId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tiposDeMedicamento.Descripcion);
                    comando.Parameters.AddWithValue("@id", tiposDeMedicamento.TipoDeMedicamentoId);
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
                string cadenaComando = "DELETE FROM TiposDeMedicamentos WHERE TipoDeMedicamentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeMedicamento tiposDeMedicamento)
        {
            try
            {
                SqlCommand comando;
                if (tiposDeMedicamento.TipoDeMedicamentoId == 0)
                {
                    string cadenaComando = "SELECT TipoDeMedicamentoId, Descripcion FROM TiposDeMedicamentos WHERE Descripcion=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tiposDeMedicamento.Descripcion);

                }
                else
                {
                    string cadenaComando = "SELECT TipoDeMedicamentoId, Descripcion FROM TiposDeMedicamentos WHERE Descripcion=@nombre AND TipoDeMedicamentoid<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tiposDeMedicamento.Descripcion);
                    comando.Parameters.AddWithValue("@id", tiposDeMedicamento.Descripcion);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeMedicamento tiposDeMedicamento)
        {
            try
            {
                var CadenaComando = "SELECT TipoDeMedicamentoId FROM Medicamentos WHERE TipoDeMedicamentoId=@id";
                var Comando = new SqlCommand(CadenaComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@id", tiposDeMedicamento.TipoDeMedicamentoId);
                var reader = Comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeMedicamento GetTiposDeMedicamento(string nombreTiposDeMedicamento)
        {
            try
            {
                TipoDeMedicamento tiposDeMedicamento = null;
                string cadenaComando = "SELECT TipoDeMedicamentoId, Descripcion FROM TiposDeMedicamentos WHERE Descripcion=@nombre";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@nombre", nombreTiposDeMedicamento);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tiposDeMedicamento = ConstruirTiposDeMedicamento(reader);
                    reader.Close();
                }

                return tiposDeMedicamento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
