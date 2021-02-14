using Farmacia.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Repositorio.Repositorios
{
    public class RepositorioMedicamentos
    {
        private readonly SqlConnection _connection;
        private readonly RepositorioDrogas _repositorioDrogas;
        private readonly RepositorioTiposDeMedicamentos _repositorioTiposDeMedicamentos;
        private readonly RepositorioFormasFarmaceuticas _repositorioFormasFarmaceuticas;
        private readonly RepositorioLaboratorios _repositorioLaboratorios;
        private SqlTransaction transaction;

        public RepositorioMedicamentos(SqlConnection connection, RepositorioDrogas repositorioDrogas,
                RepositorioTiposDeMedicamentos repositorioTiposDeMedicamentos, RepositorioFormasFarmaceuticas repositorioFormasFarmaceuticas, 
                RepositorioLaboratorios repositorioLaboratorios)
        {
            _connection = connection;
            _repositorioDrogas = repositorioDrogas;
            _repositorioTiposDeMedicamentos = repositorioTiposDeMedicamentos;
            _repositorioFormasFarmaceuticas = repositorioFormasFarmaceuticas;
            _repositorioLaboratorios = repositorioLaboratorios;
        }

        public RepositorioMedicamentos(SqlConnection connection)
        {
            _connection = connection;
        }

        public RepositorioMedicamentos(SqlConnection _connection, SqlTransaction transaction)
        {
            this._connection = _connection;
            this.transaction = transaction;
        }

        public void ModificarStok(int cantidad, int id)
        {
            try
            {
                var cadenaComando = "Update Medicamentos set UnidadesEnStok += @cantidad where MedicamentoId = @id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection, transaction);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Medicamento GetMedicamentoPorId(int id)
        {
            Medicamento p = null;
            try
            {
                string cadenaComando =
                    "SELECT MedicamentoId, NombreComercial, DrogaId, TipoDeMedicamentoId, FormaFarmaceuticaId, LaboratorioId, PrecioVenta, " +
                    "UnidadesEnStok, NivelDeReposicion, CantidadesPorUnidad, Suspendido FROM Medicamentos WHERE MedicamentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirMedicamento(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Medicamento> GetLista()
        {
            List<Medicamento> lista = new List<Medicamento>();
            try
            {
                string cadenaComando =
                    "SELECT MedicamentoId, NombreComercial, DrogaId, TipoDeMedicamentoId, FormaFarmaceuticaId, LaboratorioId, PrecioVenta, " +
                    "UnidadesEnStok, NivelDeReposicion, CantidadesPorUnidad, Suspendido FROM Medicamentos";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Medicamento medicamento = ConstruirMedicamento(reader);
                    lista.Add(medicamento);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Medicamento ConstruirMedicamento(SqlDataReader reader)
        {
            Medicamento medicamento = new Medicamento();

            medicamento.MedicamentoId = reader.GetInt32(0);
            medicamento.NombreComercial = reader.GetString(1);
            medicamento.Droga = _repositorioDrogas.GetDrogaPorId(reader.GetInt32(2));
            medicamento.TipoDeMedicamento = _repositorioTiposDeMedicamentos.GetTiposDeMedicamentoPorId(reader.GetInt32(3));
            medicamento.FormaFarmaceutica = _repositorioFormasFarmaceuticas.GetFormaFarmaceuticaPorId(reader.GetInt32(4));
            medicamento.Laboratorio = _repositorioLaboratorios.GetLaboratorioPorId(reader.GetInt32(5));
            medicamento.PrecioVenta =(double) reader.GetDecimal(6);
            medicamento.UnidadesEnStok = reader.GetInt32(7);
            medicamento.NivelDeReposicion = reader.GetInt32(8);
            medicamento.CantidadesPorUnidad = reader.GetString(9);
            medicamento.Suspendido = reader.GetBoolean(10);


            return medicamento;

        }

        public void Guardar(Medicamento medicamento)
        {

            if (medicamento.MedicamentoId == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Medicamentos (NombreComercial, DrogaId, TipoDeMedicamentoId, FormaFarmaceuticaId, LaboratorioId, PrecioVenta, " +
                    "UnidadesEnStok, NivelDeReposicion, CantidadesPorUnidad, Suspendido) VALUES (@nombreComercial, @droga, @tipoDeMedicamento, @formaFarmaceutica, " +
                    "@laboratorio, @precioVenta, @unidadesEnStok, @nivelDeReposicion, @cantidadesPorUnidad, @suspendido)";
                    var comando = new SqlCommand(cadenaComando, _connection);

                    comando.Parameters.AddWithValue("@nombreComercial", medicamento.NombreComercial);
                    comando.Parameters.AddWithValue("@droga", medicamento.Droga.DrogaId);
                    comando.Parameters.AddWithValue("@tipoDeMedicamento", medicamento.TipoDeMedicamento.TipoDeMedicamentoId);
                    comando.Parameters.AddWithValue("@formaFarmaceutica", medicamento.FormaFarmaceutica.FormaFarmaceuticaId);
                    comando.Parameters.AddWithValue("@laboratorio", medicamento.Laboratorio.LaboratorioId);
                    comando.Parameters.AddWithValue("@precioVenta", medicamento.PrecioVenta);
                    comando.Parameters.AddWithValue("@unidadesEnStok", medicamento.UnidadesEnStok);
                    comando.Parameters.AddWithValue("@nivelDeReposicion", medicamento.NivelDeReposicion);
                    comando.Parameters.AddWithValue("@cantidadesPorUnidad", medicamento.CantidadesPorUnidad);
                    comando.Parameters.AddWithValue("@suspendido", medicamento.Suspendido);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    medicamento.MedicamentoId = id;


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
                    var cadenaDeComando = "UPDATE Medicamentos SET NombreComercial=@nombreComercial, DrogaId=@droga, TipoDeMedicamentoId=@tipoDeMedicamento, " +
                        "FormaFarmaceuticaId=@formaFarmaceutica, LaboratorioId=@laboratorio, PrecioVenta=@precioVenta, UnidadesEnStok=@unidadesEnStok," +
                        "NivelDeReposicion=@nivelDeReposicion, CantidadesPorUnidad=@cantidadesPorUnidad, Suspendido=@suspendido WHERE MedicamentoId=@id";
                    var comando = new SqlCommand(cadenaDeComando, _connection);

                    comando.Parameters.AddWithValue("@nombreComercial", medicamento.NombreComercial);
                    comando.Parameters.AddWithValue("@droga", medicamento.Droga.DrogaId);
                    comando.Parameters.AddWithValue("@tipoDeMedicamento", medicamento.TipoDeMedicamento.TipoDeMedicamentoId);
                    comando.Parameters.AddWithValue("@formaFarmaceutica", medicamento.FormaFarmaceutica.FormaFarmaceuticaId);
                    comando.Parameters.AddWithValue("@laboratorio", medicamento.Laboratorio.LaboratorioId);
                    comando.Parameters.AddWithValue("@precioVenta", medicamento.PrecioVenta);
                    comando.Parameters.AddWithValue("@unidadesEnStok", medicamento.UnidadesEnStok);
                    comando.Parameters.AddWithValue("@nivelDeReposicion", medicamento.NivelDeReposicion);
                    comando.Parameters.AddWithValue("@cantidadesPorUnidad", medicamento.CantidadesPorUnidad);
                    comando.Parameters.AddWithValue("@suspendido", medicamento.Suspendido);
                    comando.Parameters.AddWithValue("@id", medicamento.MedicamentoId);


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
                string cadenaComando = "DELETE FROM Medicamentos WHERE MedicamentoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Medicamento medicamento)
        {
            try
            {
                SqlCommand comando;
                if (medicamento.MedicamentoId == 0)
                {
                    string cadenaComando = "SELECT MedicamentoId FROM Medicamentos WHERE NombreComercial=@nombreComercial";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombreComercial", medicamento.NombreComercial);

                }
                else
                {
                    string cadenaComando = "SELECT MedicamentoId FROM Medicamentos WHERE NombreComercial=@nombreComercial AND MedicamentoId<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombreComercial", medicamento.NombreComercial);
                    comando.Parameters.AddWithValue("@id", medicamento.MedicamentoId);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Medicamento medicamento)
        {
            try
            {
                var CadenaComando = "SELECT MedicamentoId FROM Lotes WHERE MedicamentoId=@id";
                var Comando = new SqlCommand(CadenaComando, _connection);
                Comando.Parameters.AddWithValue("@id", medicamento.MedicamentoId);
                var reader = Comando.ExecuteReader();

                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
