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
    public partial class frmTiposDeDocumentos : Form
    {
        public frmTiposDeDocumentos()
        {
            InitializeComponent();
        }


        private List<TipoDeDocumento> lista;
        private ServicioTipoDeDocumento _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipoDeDocumento in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDeDocumento);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDeDocumento tipoDeDocumento)
        {
            r.Cells[clmTipoDeDocumento.Index].Value = tipoDeDocumento.Descripcion;

            r.Tag = tipoDeDocumento;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(TipoDeDocumento tipoDeDocumento)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, tipoDeDocumento);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmTipoDeDocumentos_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioTipoDeDocumento();
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
            frmTiposDeDocumentosAE frm = new frmTiposDeDocumentosAE(this);
            frm.Text = "Nuevo tipo de documento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeDocumento tipoDeDocumento = frm.GetTipoDeDocumento();
                    if (!_servicio.Existe(tipoDeDocumento))
                    {
                        _servicio.Guardar(tipoDeDocumento);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, tipoDeDocumento);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Tipo de documento repetido");
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
                TipoDeDocumento tipoDeDocumento = (TipoDeDocumento)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el tipo de documento {tipoDeDocumento.Descripcion}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(tipoDeDocumento.TipoDeDocumentoId);
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
                TipoDeDocumento tipoDeDocumento = (TipoDeDocumento)r.Tag;
                frmTiposDeDocumentosAE frm = new frmTiposDeDocumentosAE();
                frm.Text = "Editar TipoDeDocumento";
                frm.SetTipoDeDocumento(tipoDeDocumento);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tipoDeDocumento = frm.GetTipoDeDocumento();
                        if (!_servicio.Existe(tipoDeDocumento))
                        {
                            _servicio.Guardar(tipoDeDocumento);
                            SetearFila(r, tipoDeDocumento);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("TipoDeDocumento Repetida");
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
