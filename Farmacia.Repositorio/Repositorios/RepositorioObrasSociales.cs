using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioObrasSociales
    {
        private readonly SqlConnection _sqlConnection;
        private SqlTransaction sqlTransaction;

        public RepositorioObrasSociales(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public RepositorioObrasSociales(SqlConnection cn, SqlTransaction sqlTransaction)
        {
            this._sqlConnection = cn;
            this.sqlTransaction = sqlTransaction;
        }

        public ObraSocial GetObraSocialPorId(int id)
        {
            try
            {
                ObraSocial obraSocial = null;
                string cadenaComando = "SELECT ObraSocialId, NombreObraSocial, PorcentajeDeDescuento FROM ObrasSociales WHERE ObraSocialId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection, sqlTransaction);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    obraSocial = ConstruirObraSocial(reader);
                    reader.Close();
                }

                return obraSocial;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<ObraSocial> GetLista()
        {
            List<ObraSocial> lista = new List<ObraSocial>();
            try
            {
                string cadenaComando = "SELECT ObraSocialId, NombreObraSocial, PorcentajeDeDescuento FROM ObrasSociales";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ObraSocial obraSocial = ConstruirObraSocial(reader);
                    lista.Add(obraSocial);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private ObraSocial ConstruirObraSocial(SqlDataReader reader)
        {
            return new ObraSocial
            {
                ObraSocialId = reader.GetInt32(0),
                NombreObraSocial = reader.GetString(1),
                PorcentajeDeDescuento=(double)reader.GetDecimal(2)
            };
        }

        public void Guardar(ObraSocial obraSocial)
        {
            if (obraSocial.ObraSocialId == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO ObrasSociales VALUES(@nombre, @descuento)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", obraSocial.NombreObraSocial);
                    comando.Parameters.AddWithValue("@descuento", obraSocial.PorcentajeDeDescuento);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    obraSocial.ObraSocialId = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE ObrasSociales SET NombreObraSocial=@nombre, PorcentajeDeDescuento=@descuento WHERE ObraSocialId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", obraSocial.NombreObraSocial);
                    comando.Parameters.AddWithValue("@id", obraSocial.ObraSocialId);
                    comando.Parameters.AddWithValue("@descuento", obraSocial.PorcentajeDeDescuento);

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
                string cadenaComando = "DELETE FROM ObrasSociales WHERE ObraSocialId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ObraSocial obraSocial)
        {
            try
            {
                SqlCommand comando;
                if (obraSocial.ObraSocialId == 0)
                {
                    string cadenaComando = "SELECT ObraSocialId, NombreObraSocial, PorcentajeDeDescuento FROM ObrasSociales WHERE NombreObraSocial=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", obraSocial.NombreObraSocial);

                }
                else
                {
                    string cadenaComando = "SELECT ObraSocialId, NombreObraSocial, PorcentajeDeDescuento FROM ObrasSociales WHERE NombreObraSocial=@nombre AND ObraSocialid<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", obraSocial.NombreObraSocial);
                    comando.Parameters.AddWithValue("@id", obraSocial.ObraSocialId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(ObraSocial obraSocial)
        {
            return false;
        }

        public ObraSocial GetObraSocial(string nombreObraSocial)
        {
            try
            {
                ObraSocial obraSocial = null;
                string cadenaComando = "SELECT ObraSocialId, NombreObraSocial, PorcentajeDeDescuento FROM ObrasSociales WHERE NombreObraSocial=@nombre";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@nombre", nombreObraSocial);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    obraSocial = ConstruirObraSocial(reader);
                    reader.Close();
                }

                return obraSocial;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
