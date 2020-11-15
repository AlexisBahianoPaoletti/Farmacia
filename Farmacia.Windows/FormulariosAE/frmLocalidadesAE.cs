using Farmacia.Entidades.Entidades;
using Farmacia.Servicio.Servicios;
using Farmacia.Windows.Formularios;
using Farmacia.Windows.Helpers;
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
    public partial class frmLocalidadesAE : Form
    {
        public frmLocalidadesAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmLocalidadesAE(frmLocalidades frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarComboProvincias(ref cmbProvincia);
            if (localidad != null)
            {
                txtLocalidad.Text = localidad.NombreLocalidad;
                cmbProvincia.SelectedValue = localidad.Provincia.ProvinciaId;
                _esEdicion = true;
            }
        }

        private Localidad localidad;
        public void SetLocalidad(Localidad localidad)
        {
            this.localidad = localidad;
        }

        public Localidad GetLocalidad()
        {
            return localidad;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtLocalidad.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtLocalidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtLocalidad, "Debe ingresar una localidad");
            }
            if (cmbProvincia.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cmbProvincia, "Debe seleccionar una provincia");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioLocalidad _servicio = new ServicioLocalidad();
        private frmLocalidades frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidad == null)
                {
                    localidad = new Localidad();
                }

                localidad.NombreLocalidad = txtLocalidad.Text;
                localidad.Provincia = (Provincia)cmbProvincia.SelectedItem;
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(localidad);
                            if (frm != null)
                            {
                                frm.AgregarFila(localidad);

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
            txtLocalidad.Clear();
            cmbProvincia.SelectedIndex = 0;
            txtLocalidad.Focus();
            localidad = null;

        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(localidad))
            {
                valido = false;
                errorProvider1.SetError(txtLocalidad, "Localidad repetida");
            }

            return valido;
        }


    }
}
