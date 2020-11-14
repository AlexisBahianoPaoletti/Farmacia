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
    public partial class frmFormasFarmaceuticasAE : Form
    {
        public frmFormasFarmaceuticasAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmFormasFarmaceuticasAE(frmFormaFarmaceuticas frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (formaFarmaceutica != null)
            {
                txtFormaFarmaceutica.Text = formaFarmaceutica.Descripcion;
                _esEdicion = true;
            }
        }

        private FormaFarmaceutica formaFarmaceutica;
        public void SetFormaFarmaceutica(FormaFarmaceutica formaFarmaceutica)
        {
            this.formaFarmaceutica = formaFarmaceutica;
        }

        public FormaFarmaceutica GetFormaFarmaceutica()
        {
            return formaFarmaceutica;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtFormaFarmaceutica.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtFormaFarmaceutica.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtFormaFarmaceutica, "Debe ingresar una formaFarmaceutica");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioFormaFarmaceutica _servicio = new ServicioFormaFarmaceutica();
        private frmFormaFarmaceuticas frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (formaFarmaceutica == null)
                {
                    formaFarmaceutica = new FormaFarmaceutica();
                }

                formaFarmaceutica.Descripcion = txtFormaFarmaceutica.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(formaFarmaceutica);
                            if (frm != null)
                            {
                                frm.AgregarFila(formaFarmaceutica);

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
            txtFormaFarmaceutica.Clear();
            txtFormaFarmaceutica.Focus();
            formaFarmaceutica = null;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(formaFarmaceutica))
            {
                valido = false;
                errorProvider1.SetError(txtFormaFarmaceutica, "FormaFarmaceutica repetida");
            }

            return valido;
        }

    }
}
