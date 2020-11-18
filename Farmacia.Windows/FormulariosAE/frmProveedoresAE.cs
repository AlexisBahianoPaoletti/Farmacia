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
    public partial class frmProveedoresAE : Form
    {
        public frmProveedoresAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmProveedoresAE(frmProveedores frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarComboTiposDeIngredientes(ref cmbTipoDeIngrediente);
            Helper.CargarComboLocalidades(ref cmbLocalidad);
            Helper.CargarComboProvincias(ref cmbProvincia);
            if (proveedor != null)
            {
                txtCUIT.Text = proveedor.CUIT;
                txtRazonSocial.Text = proveedor.RazonSocial;
                txtPersonaDeContacto.Text = proveedor.PersonaDeContacto;
                txtDireccion.Text = proveedor.Direccion;
                txtTelefonoFijo.Text = proveedor.TelefonoFijo;
                txtTelefonoMovil.Text = proveedor.TelefonoMovil;
                txtCorreoElectronico.Text = proveedor.CorreoElectronico;
                cmbTipoDeIngrediente.SelectedValue = proveedor.TipoDeIngrediente.TipoDeIngredienteId;
                cmbLocalidad.SelectedValue = proveedor.Localidad.LocalidadId;
                cmbProvincia.SelectedValue = proveedor.Provincia.ProvinciaId;


                _esEdicion = true;
            }



        }

        private Proveedor proveedor;
        public void SetProveedor(Proveedor proveedor)
        {
            this.proveedor = proveedor;
        }

        public Proveedor GetProveedor()
        {
            return proveedor;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtCUIT.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtCUIT.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCUIT, "Debe ingresar un CUIT");
            }
            if (string.IsNullOrEmpty(txtRazonSocial.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtRazonSocial.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtRazonSocial, "Debe ingresar una razon social");
            }
            if (string.IsNullOrEmpty(txtPersonaDeContacto.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtPersonaDeContacto.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtPersonaDeContacto, "Debe ingresar una persona de contacto");
            }
            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtDireccion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDireccion, "Debe ingresar una direccion");
            }
            if (cmbTipoDeIngrediente.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbTipoDeIngrediente, "Debe seleccionar un tipo de ingrediente");
            }
            if (cmbLocalidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbLocalidad, "Debe seleccionar una localidad");
            }

            if (cmbProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbProvincia, "Debe seleccionar una provincia");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioProveedor _servicio = new ServicioProveedor();
        private frmProveedores frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedor == null)
                {
                    proveedor = new Proveedor();
                }

                proveedor.CUIT = txtCUIT.Text;
                proveedor.RazonSocial = txtRazonSocial.Text;
                proveedor.PersonaDeContacto = txtPersonaDeContacto.Text;
                proveedor.Direccion = txtDireccion.Text;
                proveedor.TelefonoFijo = txtTelefonoFijo.Text;
                proveedor.TelefonoMovil = txtTelefonoMovil.Text;
                proveedor.CorreoElectronico = txtCorreoElectronico.Text;                
                proveedor.Localidad = (Localidad)cmbLocalidad.SelectedItem;
                proveedor.Provincia = (Provincia)cmbProvincia.SelectedItem;
                proveedor.TipoDeIngrediente = (TipoDeIngrediente)cmbTipoDeIngrediente.SelectedItem;


                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(proveedor);
                            if (frm != null)
                            {
                                frm.AgregarFila(proveedor);

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
            txtCUIT.Clear();
            txtRazonSocial.Clear();
            txtPersonaDeContacto.Clear();
            txtDireccion.Clear();
            txtTelefonoFijo.Clear();
            txtTelefonoMovil.Clear();
            txtCorreoElectronico.Clear();
            cmbTipoDeIngrediente.SelectedIndex = 0;
            cmbLocalidad.SelectedIndex = 0;
            cmbProvincia.SelectedIndex = 0;
            txtCUIT.Focus();
            proveedor = null;

        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(proveedor))
            {
                valido = false;
                errorProvider1.SetError(txtCUIT, "Proveedor repetido");
            }

            return valido;
        }


    }
}
