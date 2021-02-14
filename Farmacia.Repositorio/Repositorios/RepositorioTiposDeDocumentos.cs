using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioTiposDeDocumentos
    {
        private readonly SqlConnection _sqlConnection;
        private SqlTransaction sqlTransaction;

        public RepositorioTiposDeDocumentos(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public RepositorioTiposDeDocumentos(SqlConnection _sqlConnection, SqlTransaction sqlTransaction)
        {
            this._sqlConnection = _sqlConnection;
            this.sqlTransaction = sqlTransaction;
        }

        public TipoDeDocumento GetTipoDeDocumentoPorId(int id)
        {
            try
            {
                TipoDeDocumento tipoDeDocumento = null;
                string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos WHERE TipoDeDocumentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection, sqlTransaction);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipoDeDocumento = ConstruirTipoDeDocumento(reader);
                    reader.Close();
                }

                return tipoDeDocumento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDeDocumento> GetLista()
        {
            List<TipoDeDocumento> lista = new List<TipoDeDocumento>();
            try
            {
                string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoDeDocumento tipoDeDocumento = ConstruirTipoDeDocumento(reader);
                    lista.Add(tipoDeDocumento);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private TipoDeDocumento ConstruirTipoDeDocumento(SqlDataReader reader)
        {
            return new TipoDeDocumento
            {
                TipoDeDocumentoId = reader.GetInt32(0),
                Descripcion = reader.GetString(1)
            };
        }

        public void Guardar(TipoDeDocumento tipoDeDocumento)
        {
            if (tipoDeDocumento.TipoDeDocumentoId == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO TiposDeDocumentos VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDeDocumento.Descripcion);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    tipoDeDocumento.TipoDeDocumentoId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE TiposDeDocumentos SET Descripcion=@nombre WHERE TipoDeDocumentoId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDeDocumento.Descripcion);
                    comando.Parameters.AddWithValue("@id", tipoDeDocumento.TipoDeDocumentoId);
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
                string cadenaComando = "DELETE FROM TiposDeDocumentos WHERE TipoDeDocumentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                SqlCommand comando;
                if (tipoDeDocumento.TipoDeDocumentoId == 0)
                {
                    string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos WHERE Descripcion=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDeDocumento.Descripcion);

                }
                else
                {
                    string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos WHERE Descripcion=@nombre AND TipoDeDocumentoid<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDeDocumento.Descripcion);
                    comando.Parameters.AddWithValue("@id", tipoDeDocumento.TipoDeDocumentoId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                var CadenaComando = "SELECT TipoDeDocumentoId FROM Clientes WHERE TipoDeDocumentoId=@id";
                var Comando = new SqlCommand(CadenaComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@id", tipoDeDocumento.TipoDeDocumentoId);
                var reader = Comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoDeDocumento GetTipoDeDocumento(string nombreTipoDeDocumento)
        {
            try
            {
                TipoDeDocumento tipoDeDocumento = null;
                string cadenaComando = "SELECT TipoDeDocumentoId, Descripcion FROM TiposDeDocumentos WHERE Descripcion=@nombre";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@nombre", nombreTipoDeDocumento);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipoDeDocumento = ConstruirTipoDeDocumento(reader);
                    reader.Close();
                }

                return tipoDeDocumento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
