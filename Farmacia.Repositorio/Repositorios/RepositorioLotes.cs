using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioLotes
    {
        private readonly SqlConnection _connection;
        private readonly RepositorioMedicamentos _repositorioMedicamentos;

        public RepositorioLotes(SqlConnection connection, RepositorioMedicamentos repositorioMedicamentos)
        {
            _connection = connection;
            _repositorioMedicamentos = repositorioMedicamentos;
        }

        public RepositorioLotes(SqlConnection connection)
        {
            _connection = connection;
        }


        public Lote GetLotePorId(int id)
        {
            Lote p = null;
            try
            {
                string cadenaComando =
                    "SELECT LoteId, MedicamentoId, Identificacion, FechaDeIngreso, Vencimiento, Cantidad FROM Lotes WHERE LoteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirLote(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Lote> GetLista()
        {
            List<Lote> lista = new List<Lote>();
            try
            {
                string cadenaComando =
                    "SELECT LoteId, MedicamentoId, Identificacion, FechaDeIngreso, Vencimiento, Cantidad FROM Lotes";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Lote lote = ConstruirLote(reader);
                    lista.Add(lote);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Lote ConstruirLote(SqlDataReader reader)
        {
            Lote lote = new Lote();
            lote.LoteId = reader.GetInt32(0);
            lote.Medicamento = _repositorioMedicamentos.GetMedicamentoPorId(reader.GetInt32(1));
            lote.Identificacion = reader.GetString(2);
            lote.FechaDeIngreso = reader.GetDateTime(3);
            lote.Vencimiento = reader.GetString(4);
            lote.Cantidad = reader.GetInt32(5);


            return lote;

        }

        public void Guardar(Lote lote)
        {

            if (lote.LoteId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Lotes (MedicamentoId, Identificacion, FechaDeIngreso, Vencimiento, " +
                        "Cantidad) VALUES (@medicamento, @identificacion, @fechaDeIngreso, @vencimiento, @cantidad)";
                    var comando = new SqlCommand(cadenaComando, _connection);

                    comando.Parameters.AddWithValue("@medicamento", lote.Medicamento.MedicamentoId);
                    comando.Parameters.AddWithValue("@identificacion", lote.Identificacion);
                    comando.Parameters.AddWithValue("@fechaDeIngreso", lote.FechaDeIngreso);
                    comando.Parameters.AddWithValue("@vencimiento", lote.Vencimiento);
                    comando.Parameters.AddWithValue("@cantidad", lote.Cantidad);
                   

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    lote.LoteId = id;


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
                    var cadenaDeComando = "UPDATE Lotes SET MedicamentoId=@medicamento, Identificacion=@identificacion, " +
                        "FechaDeIngreso=@fechaDeIngreso, Vencimiento=@vencimiento, Cantidad=@cantidad WHERE LoteId=@id";
                    var comando = new SqlCommand(cadenaDeComando, _connection);

                    comando.Parameters.AddWithValue("@medicamento", lote.Medicamento.MedicamentoId);
                    comando.Parameters.AddWithValue("@identificacion", lote.Identificacion);
                    comando.Parameters.AddWithValue("@fechaDeIngreso", lote.FechaDeIngreso);
                    comando.Parameters.AddWithValue("@vencimiento", lote.Vencimiento);
                    comando.Parameters.AddWithValue("@cantidad", lote.Cantidad);
                    comando.Parameters.AddWithValue("@id", lote.LoteId);


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
                string cadenaComando = "DELETE FROM Lotes WHERE LoteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Lote lote)
        {
            try
            {
                SqlCommand comando;
                if (lote.LoteId == 0)
                {
                    string cadenaComando = "SELECT LoteId FROM Lotes WHERE Identificacion=@identificacion";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@identificacion", lote.Identificacion);

                }
                else
                {
                    string cadenaComando = "SELECT LoteId FROM Lotes WHERE Identificacion=@identificacion AND LoteId<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@identificacion", lote.Identificacion);
                    comando.Parameters.AddWithValue("@id", lote.LoteId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Lote lote)
        {
            return false;
        }

    }
}
