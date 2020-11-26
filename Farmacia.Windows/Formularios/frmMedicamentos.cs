using Farmacia.Entidades.Entidades;
using Farmacia.Servicio.Servicios;
using Farmacia.Windows.FormulariosAE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia.Windows.Formularios
{
    public partial class frmMedicamentos : Form
    {
        public frmMedicamentos()
        {
            InitializeComponent();
        }


        private List<Medicamento> lista;
        private ServicioMedicamento _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var medicamento in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, medicamento);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Medicamento medicamento)
        {
            r.Cells[clmNombre.Index].Value = medicamento.NombreComercial;
            r.Cells[clmDroga.Index].Value = medicamento.Droga.NombreDroga;
            r.Cells[clmTipoDeMedicamento.Index].Value = medicamento.TipoDeMedicamento.Descripcion;
            r.Cells[clmFormaFarmaceutica.Index].Value = medicamento.FormaFarmaceutica.Descripcion;
            r.Cells[clmLaboratorio.Index].Value = medicamento.Laboratorio.NombreLaboratorio;
            r.Cells[clmPrecioVenta.Index].Value = medicamento.PrecioVenta;
            r.Cells[clmUnidadesEnStok.Index].Value = medicamento.UnidadesEnStok;
            r.Cells[clmNivelDeReposicion.Index].Value = medicamento.NivelDeReposicion;
            r.Cells[clmCantidadesPorUnidad.Index].Value = medicamento.CantidadesPorUnidad;
            r.Cells[clmSuspendido.Index].Value = medicamento.Suspendido;

            r.Tag = medicamento;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(Medicamento medicamento)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, medicamento);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmMedicamentos_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioMedicamento();
                lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tslAgregar_Click(object sender, EventArgs e)
        {
            frmMedicamentosAE frm = new frmMedicamentosAE(this);
            frm.Text = "Nuevo Medicamento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Medicamento medicamento = frm.GetMedicamento();
                    if (!_servicio.Existe(medicamento))
                    {
                        _servicio.Guardar(medicamento);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, medicamento);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Medicamento repetido");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }

        private void tslBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Medicamento medicamento = (Medicamento)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el medicamento {medicamento.NombreComercial}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (!_servicio.EstaRelacionado(medicamento))
                    {
                        try
                        {
                            _servicio.Borrar(medicamento.MedicamentoId);
                            dgvDatos.Rows.Remove(r);
                            MessageBox.Show("Registro borrado");
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);

                        }
                    }
                    else
                    {
                        MessageBox.Show("El registro esta relacionado, no se puede borrar");
                    }
                }
            }
        }


        private void tslEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Medicamento medicamento = (Medicamento)r.Tag;
                medicamento = _servicio.GetMedicamentoPorId(medicamento.MedicamentoId);
                frmMedicamentosAE frm = new frmMedicamentosAE();
                frm.Text = "Editar Medicamento";
                frm.SetMedicamento(medicamento);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        medicamento = frm.GetMedicamento();
                        if (!_servicio.Existe(medicamento))
                        {
                            _servicio.Guardar(medicamento);
                            SetearFila(r, medicamento);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Medicamento Repetido");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }
    }
}
