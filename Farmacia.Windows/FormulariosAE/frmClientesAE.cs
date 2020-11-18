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
    public partial class frmClientesAE : Form
    {


        public frmClientesAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmClientesAE(frmClientes frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarComboTiposDeDocumentos(ref cmbTipoDeDocumento);
            Helper.CargarComboLocalidades(ref cmbLocalidad);
            Helper.CargarComboProvincias(ref cmbProvincia);
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtNroDocumento.Text = cliente.NroDocumento;
                txtDireccion.Text = cliente.Direccion;
                txtTelefonoFijo.Text = cliente.TelefonoFijo;
                txtTelefonoMovil.Text = cliente.TelefonoMovil;
                txtCorreoElectronico.Text = cliente.CorreoElectronico;
                cmbTipoDeDocumento.SelectedValue = cliente.TipoDeDocumento.TipoDeDocumentoId;
                cmbLocalidad.SelectedValue = cliente.Localidad.LocalidadId;
                cmbProvincia.SelectedValue = cliente.Provincia.ProvinciaId;
                _esEdicion = true;
            }



        }

        private Cliente cliente;
        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public Cliente GetCliente()
        {
            return cliente;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtNombre.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "Debe ingresar un nombre");
            }
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtApellido.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Debe ingresar un apellido");
            }
            if (string.IsNullOrEmpty(txtNroDocumento.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtNroDocumento.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtNroDocumento, "Debe ingresar un nro de documento");
            }
            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtDireccion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDireccion, "Debe ingresar una direccion");
            }
            if (cmbTipoDeDocumento.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbTipoDeDocumento, "Debe seleccionar un tipo de documento");
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
        private ServicioCliente _servicio = new ServicioCliente();
        private frmClientes frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cliente == null)
                {
                    cliente = new Cliente();
                }

                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.NroDocumento = txtNroDocumento.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.TelefonoFijo = txtTelefonoFijo.Text;
                cliente.TelefonoMovil = txtTelefonoMovil.Text;
                cliente.CorreoElectronico = txtCorreoElectronico.Text;
                cliente.TipoDeDocumento = (TipoDeDocumento)cmbTipoDeDocumento.SelectedItem;
                cliente.Localidad = (Localidad)cmbLocalidad.SelectedItem;
                cliente.Provincia = (Provincia)cmbProvincia.SelectedItem;


                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(cliente);
                            if (frm != null)
                            {
                                frm.AgregarFila(cliente);

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
            txtNombre.Clear();
            txtApellido.Clear();
            txtNroDocumento.Clear();
            txtDireccion.Clear();
            txtTelefonoFijo.Clear();
            txtTelefonoMovil.Clear();
            txtCorreoElectronico.Clear();
            cmbTipoDeDocumento.SelectedIndex = 0;
            cmbLocalidad.SelectedIndex = 0;
            cmbProvincia.SelectedIndex = 0;
            txtNombre.Focus();
            cliente = null;

        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(cliente))
            {
                valido = false;
                errorProvider1.SetError(txtNroDocumento, "Cliente repetido");
            }

            return valido;
        }


    }
}
