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
    public partial class frmDrogas : Form
    {
        public frmDrogas()
        {
            InitializeComponent();
        }


        private List<Droga> lista;
        private ServicioDroga _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var droga in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, droga);
                AñadirFila(r);
            }
        }

    

        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Droga droga)
        {
            r.Cells[clmDroga.Index].Value = droga.NombreDroga;

            r.Tag = droga;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos); 
            return r;
        }

        public void AgregarFila(Droga droga)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, droga);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmDrogas_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioDroga();
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
            frmDrogasAE frm = new frmDrogasAE(this);
            frm.Text = "Nueva Droga";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Droga droga = frm.GetDroga();
                    if (!_servicio.Existe(droga))
                    {
                        _servicio.Guardar(droga);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, droga);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Droga repetida");
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
                Droga droga = (Droga)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja a la droga {droga.NombreDroga}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(droga.DrogaId);
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
                Droga droga = (Droga)r.Tag;
                frmDrogasAE frm = new frmDrogasAE();
                frm.Text = "Editar Droga";
                frm.SetDroga(droga);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        droga = frm.GetDroga();
                        if (!_servicio.Existe(droga))
                        {
                            _servicio.Guardar(droga);
                            SetearFila(r, droga);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Droga Repetida");
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
