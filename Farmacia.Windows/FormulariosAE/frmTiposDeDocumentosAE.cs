using Farmacia.Entidades.Entidades;
using Farmacia.Servicio.Servicios;
using Farmacia.Windows.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia.Windows.FormulariosAE
{
    public partial class frmTiposDeDocumentosAE : Form
    {
        public frmTiposDeDocumentosAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmTiposDeDocumentosAE(frmTiposDeDocumentos frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoDeDocumento != null)
            {
                txtTipoDeDocumento.Text = tipoDeDocumento.Descripcion;
                _esEdicion = true;
            }
        }

        private TipoDeDocumento tipoDeDocumento;
        public void SetTipoDeDocumento(TipoDeDocumento tipoDeDocumento)
        {
            this.tipoDeDocumento = tipoDeDocumento;
        }

        public TipoDeDocumento GetTipoDeDocumento()
        {
            return tipoDeDocumento;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtTipoDeDocumento.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtTipoDeDocumento.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeDocumento, "Debe ingresar una tipoDeDocumento");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioTipoDeDocumento _servicio = new ServicioTipoDeDocumento();
        private frmTiposDeDocumentos frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDeDocumento == null)
                {
                    tipoDeDocumento = new TipoDeDocumento();
                }

                tipoDeDocumento.Descripcion = txtTipoDeDocumento.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(tipoDeDocumento);
                            if (frm != null)
                            {
                                frm.AgregarFila(tipoDeDocumento);

                            }
                            MessageBox.Show("Registro Guardado", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult dr = MessageBox.Show("¿Desea dar de alta otro registro?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.Cancel;
                            }
                            else
                            {
                                InicializarControles();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }

                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            }

        }

        private void InicializarControles()
        {
            txtTipoDeDocumento.Clear();
            txtTipoDeDocumento.Focus();
            tipoDeDocumento = null;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(tipoDeDocumento))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeDocumento, "TipoDeDocumento repetida");
            }

            return valido;
        }

    }
}
