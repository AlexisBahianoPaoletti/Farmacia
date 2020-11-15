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
    public partial class frmLaboratorios : Form
    {
        public frmLaboratorios()
        {
            InitializeComponent();
        }


        private List<Laboratorio> lista;
        private ServicioLaboratorio _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var laboratorio in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, laboratorio);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Laboratorio laboratorio)
        {
            r.Cells[clmLaboratorio.Index].Value = laboratorio.NombreLaboratorio;

            r.Tag = laboratorio;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(Laboratorio laboratorio)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, laboratorio);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmLaboratorios_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioLaboratorio();
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
            frmLaboratoriosAE frm = new frmLaboratoriosAE(this);
            frm.Text = "Nuevo Laboratorio";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Laboratorio laboratorio = frm.GetLaboratorio();
                    if (!_servicio.Existe(laboratorio))
                    {
                        _servicio.Guardar(laboratorio);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, laboratorio);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Laboratorio repetido");
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
                Laboratorio laboratorio = (Laboratorio)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el laboratorio {laboratorio.NombreLaboratorio}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(laboratorio.LaboratorioId);
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
                Laboratorio laboratorio = (Laboratorio)r.Tag;
                frmLaboratoriosAE frm = new frmLaboratoriosAE();
                frm.Text = "Editar Laboratorio";
                frm.SetLaboratorio(laboratorio);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        laboratorio = frm.GetLaboratorio();
                        if (!_servicio.Existe(laboratorio))
                        {
                            _servicio.Guardar(laboratorio);
                            SetearFila(r, laboratorio);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Laboratorio Repetida");
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
