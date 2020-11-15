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
    public partial class frmTiposDeIngredientesAE : Form
    {
        public frmTiposDeIngredientesAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmTiposDeIngredientesAE(frmTiposDeIngredientes frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoDeIngrediente != null)
            {
                txtTipoDeIngrediente.Text = tipoDeIngrediente.TipoDeIngredientes;
                _esEdicion = true;
            }
        }

        private TipoDeIngrediente tipoDeIngrediente;
        public void SetTipoDeIngrediente(TipoDeIngrediente tipoDeIngrediente)
        {
            this.tipoDeIngrediente = tipoDeIngrediente;
        }

        public TipoDeIngrediente GetTipoDeIngrediente()
        {
            return tipoDeIngrediente;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtTipoDeIngrediente.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtTipoDeIngrediente.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeIngrediente, "Debe ingresar una tipoDeIngrediente");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioTipoDeIngrediente _servicio = new ServicioTipoDeIngrediente();
        private frmTiposDeIngredientes frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDeIngrediente == null)
                {
                    tipoDeIngrediente = new TipoDeIngrediente();
                }

                tipoDeIngrediente.TipoDeIngredientes = txtTipoDeIngrediente.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(tipoDeIngrediente);
                            if (frm != null)
                            {
                                frm.AgregarFila(tipoDeIngrediente);

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
            txtTipoDeIngrediente.Clear();
            txtTipoDeIngrediente.Focus();
            tipoDeIngrediente = null;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(tipoDeIngrediente))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDeIngrediente, "Tipo de ingredientes repetido");
            }

            return valido;
        }

    }
}
