using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioLaboratorios
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioLaboratorios(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Laboratorio GetLaboratorioPorId(int id)
        {
            try
            {
                Laboratorio laboratorio = null;
                string cadenaComando = "SELECT LaboratorioId, NombreLaboratorio FROM Laboratorios WHERE LaboratorioId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    laboratorio = ConstruirLaboratorio(reader);
                    reader.Close();
                }

                return laboratorio;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Laboratorio> GetLista()
        {
            List<Laboratorio> lista = new List<Laboratorio>();
            try
            {
                string cadenaComando = "SELECT LaboratorioId, NombreLaboratorio FROM Laboratorios";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Laboratorio laboratorio = ConstruirLaboratorio(reader);
                    lista.Add(laboratorio);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Laboratorio ConstruirLaboratorio(SqlDataReader reader)
        {
            return new Laboratorio
            {
                LaboratorioId = reader.GetInt32(0),
                NombreLaboratorio = reader.GetString(1)
            };
        }

        public void Guardar(Laboratorio laboratorio)
        {
            if (laboratorio.LaboratorioId == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO Laboratorios VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", laboratorio.NombreLaboratorio);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    laboratorio.LaboratorioId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Laboratorios SET NombreLaboratorio=@nombre WHERE LaboratorioId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", laboratorio.NombreLaboratorio);
                    comando.Parameters.AddWithValue("@id", laboratorio.LaboratorioId);
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
                string cadenaComando = "DELETE FROM Laboratorios WHERE LaboratorioId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Laboratorio laboratorio)
        {
            try
            {
                SqlCommand comando;
                if (laboratorio.LaboratorioId == 0)
                {
                    string cadenaComando = "SELECT LaboratorioId, NombreLaboratorio FROM Laboratorios WHERE NombreLaboratorio=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", laboratorio.NombreLaboratorio);

                }
                else
                {
                    string cadenaComando = "SELECT LaboratorioId, NombreLaboratorio FROM Laboratorios WHERE NombreLaboratorio=@nombre AND Laboratorioid<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", laboratorio.NombreLaboratorio);
                    comando.Parameters.AddWithValue("@id", laboratorio.LaboratorioId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Laboratorio laboratorio)
        {
            try
            {
                var CadenaComando = "SELECT LaboratorioId FROM Medicamentos WHERE LaboratorioId=@id";
                var Comando = new SqlCommand(CadenaComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@id", laboratorio.LaboratorioId);
                var reader = Comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Laboratorio GetLaboratorio(string nombreLaboratorio)
        {
            try
            {
                Laboratorio laboratorio = null;
                string cadenaComando = "SELECT LaboratorioId, NombreLaboratorio FROM Laboratorios WHERE NombreLaboratorio=@nombre";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@nombre", nombreLaboratorio);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    laboratorio = ConstruirLaboratorio(reader);
                    reader.Close();
                }

                return laboratorio;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
