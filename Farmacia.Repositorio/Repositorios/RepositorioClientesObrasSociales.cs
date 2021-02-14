using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioClientesObrasSociales
    {
        private SqlConnection sqlConnection;
        private SqlTransaction sqlTransaction;
        private RepositorioClientes repositorioClientes;
        private RepositorioObrasSociales repositorioObrasSociales;

        public RepositorioClientesObrasSociales(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public RepositorioClientesObrasSociales(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            this.sqlConnection = sqlConnection;
            this.sqlTransaction = sqlTransaction;
        }

        public RepositorioClientesObrasSociales(SqlConnection cn, RepositorioClientes repositorioClientes, RepositorioObrasSociales repositorioObrasSociales, SqlTransaction sqlTransaction1)
        {
            this.sqlConnection = cn;
            this.repositorioClientes = repositorioClientes;
            this.repositorioObrasSociales = repositorioObrasSociales;
            this.sqlTransaction = sqlTransaction1;
        }

        public bool VerificarObraSocial(Cliente cliente)
        {
            try
            {
                var cadenaComando = "Select * From ClientesObrasSociales Where ClienteId = @id";
                SqlCommand comando = new SqlCommand(cadenaComando, sqlConnection, sqlTransaction);
                comando.Parameters.AddWithValue("@id", cliente.ClienteId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Guardar(ClientesObrasSociales co)
        {
            try
            {
                var cadenaComando = "Insert into ClientesObrasSociales (ClienteId, ObraSocialId) Values (@cliente, @obraSocial)";
                SqlCommand comando = new SqlCommand(cadenaComando, sqlConnection, sqlTransaction);
                comando.Parameters.AddWithValue("@cliente", co.cliente.ClienteId);
                comando.Parameters.AddWithValue("@obraSocial", co.obraSocial.ObraSocialId);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<ClientesObrasSociales> GetLista(Cliente c)
        {
            List<ClientesObrasSociales> lista = new List<ClientesObrasSociales>();
            try
            {
                string cadenaComando =
                    "SELECT ClienteId, ObraSocialId FROM ClientesObrasSociales Where ClienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, sqlConnection, sqlTransaction);
                comando.Parameters.AddWithValue("@id", c.ClienteId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ClientesObrasSociales clienteobrasocial = ConstruirClienteObraSocial(reader);
                    lista.Add(clienteobrasocial);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private ClientesObrasSociales ConstruirClienteObraSocial(SqlDataReader reader)
        {
            ClientesObrasSociales clientesObrasSociales = new ClientesObrasSociales();
            clientesObrasSociales.cliente = repositorioClientes.GetClientePorId(reader.GetInt32(0));
            clientesObrasSociales.obraSocial = repositorioObrasSociales.GetObraSocialPorId(reader.GetInt32(1));
            return clientesObrasSociales;

        }
    }
}
