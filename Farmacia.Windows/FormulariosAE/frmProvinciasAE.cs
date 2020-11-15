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
    public partial class frmProvinciasAE : Form
    {
        public frmProvinciasAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmProvinciasAE(frmProvincias frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (provincia != null)
            {
                txtProvincia.Text = provincia.NombreProvincia;
                _esEdicion = true;
            }
        }

        private Provincia provincia;
        public void SetProvincia(Provincia provincia)
        {
            this.provincia = provincia;
        }

        public Provincia GetProvincia()
        {
            return provincia;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtProvincia.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtProvincia.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtProvincia, "Debe ingresar una provincia");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioProvincia _servicio = new ServicioProvincia();
        private frmProvincias frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provincia == null)
                {
                    provincia = new Provincia();
                }

                provincia.NombreProvincia = txtProvincia.Text;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(provincia);
                            if (frm != null)
                            {
                                frm.AgregarFila(provincia);

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
            txtProvincia.Clear();
            txtProvincia.Focus();
            provincia = null;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(provincia))
            {
                valido = false;
                errorProvider1.SetError(txtProvincia, "Provincia repetida");
            }

            return valido;
        }


    }
}
