using Farmacia.Entidades;
using Farmacia.Servicio;
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
    public partial class frmTiposDeMedicamentos : Form
    {
        public frmTiposDeMedicamentos()
        {
            InitializeComponent();
        }


        private List<TipoDeMedicamento> lista;
        private ServicioTipoDeMedicamento _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipoDeMedicamento in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDeMedicamento);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeMedicamento tipoDeMedicamento)
        {
            r.Cells[clmTipoDeMedicamento.Index].Value = tipoDeMedicamento.Descripcion;

            r.Tag = tipoDeMedicamento;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(TipoDeMedicamento tipoDeMedicamento)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, tipoDeMedicamento);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmTiposDeMedicamentos_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioTipoDeMedicamento();
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
            frmTiposDeMedicamentosAE frm = new frmTiposDeMedicamentosAE(this);
            frm.Text = "Nuevo Tipo de medicamento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeMedicamento tipoDeMedicamento = frm.GetTipoDeMedicamento();
                    if (!_servicio.Existe(tipoDeMedicamento))
                    {
                        _servicio.Guardar(tipoDeMedicamento);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, tipoDeMedicamento);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Tipo de medicamento repetido");
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
                TipoDeMedicamento tipoDeMedicamento = (TipoDeMedicamento)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja al tipo de medicamento {tipoDeMedicamento.Descripcion}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(tipoDeMedicamento.TipoDeMedicamentoId);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro borrado");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);

                    }
                }
            }
        }


        private void tslEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                TipoDeMedicamento tipoDeMedicamento = (TipoDeMedicamento)r.Tag;
                frmTiposDeMedicamentosAE frm = new frmTiposDeMedicamentosAE();
                frm.Text = "Editar TipoDeMedicamento";
                frm.SetTipoDeMedicamento(tipoDeMedicamento);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipoDeMedicamento = frm.GetTipoDeMedicamento();
                        if (!_servicio.Existe(tipoDeMedicamento))
                        {
                            _servicio.Guardar(tipoDeMedicamento);
                            SetearFila(r, tipoDeMedicamento);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("TipoDeMedicamento Repetida");
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
