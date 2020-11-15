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
    public partial class frmObrasSocialesAE : Form
    {
        public frmObrasSocialesAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmObrasSocialesAE(frmObrasSociales frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (obraSocial != null)
            {
                txtObraSocial.Text = obraSocial.NombreObraSocial;
                txtPorcentajeDeDescuento.Text = obraSocial.PorcentajeDeDescuento.ToString();
                _esEdicion = true;
            }
        }

        private ObraSocial obraSocial;
        public void SetObraSocial(ObraSocial obraSocial)
        {
            this.obraSocial = obraSocial;
        }

        public ObraSocial GetObraSocial()
        {
            return obraSocial;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtObraSocial.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtObraSocial.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtObraSocial, "Debe ingresar una obra social");
            }
            if (string.IsNullOrEmpty(txtPorcentajeDeDescuento.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtPorcentajeDeDescuento.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtPorcentajeDeDescuento, "Debe ingresar un descuento");
            }

            double porcentaje = 0;
            if (!double.TryParse(txtPorcentajeDeDescuento.Text, out porcentaje))
            {
                valido = false;
                errorProvider1.SetError(txtPorcentajeDeDescuento, "Debe ingresar un descuento valido");
            }
            if (porcentaje<0 || porcentaje>100)
            {
                valido = false;
                errorProvider1.SetError(txtPorcentajeDeDescuento, "Debe ingresar un descuento valido");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioObraSocial _servicio = new ServicioObraSocial();
        private frmObrasSociales frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (obraSocial == null)
                {
                    obraSocial = new ObraSocial();
                }

                obraSocial.NombreObraSocial = txtObraSocial.Text;
                obraSocial.PorcentajeDeDescuento =double.Parse(txtPorcentajeDeDescuento.Text);
                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(obraSocial);
                            if (frm != null)
                            {
                                frm.AgregarFila(obraSocial);

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
            txtObraSocial.Clear();
            txtPorcentajeDeDescuento.Clear();
            txtObraSocial.Focus();
            obraSocial = null;
        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(obraSocial))
            {
                valido = false;
                errorProvider1.SetError(txtObraSocial, "Obra social repetida");
            }

            return valido;
        }

    }
}
