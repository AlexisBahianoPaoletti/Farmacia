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
    public partial class frmFormaFarmaceuticas : Form
    {
        public frmFormaFarmaceuticas()
        {
            InitializeComponent();
        }


        private List<FormaFarmaceutica> lista;
        private ServicioFormaFarmaceutica _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var formaFarmaceutica in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, formaFarmaceutica);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, FormaFarmaceutica formaFarmaceutica)
        {
            r.Cells[clmFormaFarmaceutica.Index].Value = formaFarmaceutica.Descripcion;

            r.Tag = formaFarmaceutica;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(FormaFarmaceutica formaFarmaceutica)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, formaFarmaceutica);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmFormaFarmaceuticas_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioFormaFarmaceutica();
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
            frmFormasFarmaceuticasAE frm = new frmFormasFarmaceuticasAE(this);
            frm.Text = "Nueva FormaFarmaceutica";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    FormaFarmaceutica formaFarmaceutica = frm.GetFormaFarmaceutica();
                    if (!_servicio.Existe(formaFarmaceutica))
                    {
                        _servicio.Guardar(formaFarmaceutica);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, formaFarmaceutica);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("FormaFarmaceutica repetida");
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
                FormaFarmaceutica formaFarmaceutica = (FormaFarmaceutica)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja la forma farmaceutica {formaFarmaceutica.Descripcion}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(formaFarmaceutica.FormaFarmaceuticaId);
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
                FormaFarmaceutica formaFarmaceutica = (FormaFarmaceutica)r.Tag;
                frmFormasFarmaceuticasAE frm = new frmFormasFarmaceuticasAE();
                frm.Text = "Editar FormaFarmaceutica";
                frm.SetFormaFarmaceutica(formaFarmaceutica);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        formaFarmaceutica = frm.GetFormaFarmaceutica();
                        if (!_servicio.Existe(formaFarmaceutica))
                        {
                            _servicio.Guardar(formaFarmaceutica);
                            SetearFila(r, formaFarmaceutica);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("FormaFarmaceutica Repetida");
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
