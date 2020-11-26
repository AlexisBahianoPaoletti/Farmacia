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
    public partial class frmObrasSociales : Form
    {
        public frmObrasSociales()
        {
            InitializeComponent();
        }


        private List<ObraSocial> lista;
        private ServicioObraSocial _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var obraSocial in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, obraSocial);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ObraSocial obraSocial)
        {
            r.Cells[clmObraSocial.Index].Value = obraSocial.NombreObraSocial;
            r.Cells[clmPorcentajeDeDescuento.Index].Value = obraSocial.PorcentajeDeDescuento;

            r.Tag = obraSocial;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(ObraSocial obraSocial)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, obraSocial);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmObrasSociales_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioObraSocial();
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
            frmObrasSocialesAE frm = new frmObrasSocialesAE(this);
            frm.Text = "Nueva Obra social";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ObraSocial obraSocial = frm.GetObraSocial();
                    if (!_servicio.Existe(obraSocial))
                    {
                        _servicio.Guardar(obraSocial);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, obraSocial);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Obra social repetida");
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
                ObraSocial obraSocial = (ObraSocial)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja la obra social {obraSocial.NombreObraSocial}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(obraSocial.ObraSocialId);
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
                ObraSocial obraSocial = (ObraSocial)r.Tag;
                obraSocial = _servicio.GetObraSocialPorId(obraSocial.ObraSocialId);
                frmObrasSocialesAE frm = new frmObrasSocialesAE();
                frm.Text = "Editar Obra social";
                frm.SetObraSocial(obraSocial);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        obraSocial = frm.GetObraSocial();
                        if (!_servicio.Existe(obraSocial))
                        {
                            _servicio.Guardar(obraSocial);
                            SetearFila(r, obraSocial);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Obra social Repetida");
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
