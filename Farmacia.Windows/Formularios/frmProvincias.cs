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
    public partial class frmProvincias : Form
    {
        public frmProvincias()
        {
            InitializeComponent();
        }


        private List<Provincia> lista;
        private ServicioProvincia _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var provincia in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, provincia);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Provincia provincia)
        {
            r.Cells[clmProvincia.Index].Value = provincia.NombreProvincia;

            r.Tag = provincia;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(Provincia provincia)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, provincia);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmProvincias_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioProvincia();
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
            frmProvinciasAE frm = new frmProvinciasAE(this);
            frm.Text = "Nueva Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Provincia provincia = frm.GetProvincia();
                    if (!_servicio.Existe(provincia))
                    {
                        _servicio.Guardar(provincia);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, provincia);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Provincia repetida");
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
                Provincia provincia = (Provincia)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja la provincia {provincia.NombreProvincia}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(provincia.ProvinciaId);
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
                Provincia provincia = (Provincia)r.Tag;
                frmProvinciasAE frm = new frmProvinciasAE();
                frm.Text = "Editar Provincia";
                frm.SetProvincia(provincia);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        provincia = frm.GetProvincia();
                        if (!_servicio.Existe(provincia))
                        {
                            _servicio.Guardar(provincia);
                            SetearFila(r, provincia);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Provincia Repetida");
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
