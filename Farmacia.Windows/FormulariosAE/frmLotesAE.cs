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
    public partial class frmLotesAE : Form
    {

        public frmLotesAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmLotesAE(frmLotes frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarComboMedicamentos(ref cmbMedicamento);

            if (lote != null)
            {
                cmbMedicamento.SelectedValue = lote.Medicamento.MedicamentoId;
                txtIdentificacion.Text = lote.Identificacion;
                txtFechaDeIngreso.Text = lote.FechaDeIngreso.ToString();
                txtVencimiento.Text = lote.Vencimiento;
                txtCantidad.Text = lote.Cantidad.ToString();

                _esEdicion = true;
            }



        }

        private Lote lote;
        public void SetLote(Lote lote)
        {
            this.lote = lote;
        }

        public Lote GetLote()
        {
            return lote;
        }



        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(txtIdentificacion.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtIdentificacion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtIdentificacion, "Debe ingresar una identificafion");
            }
            if (string.IsNullOrEmpty(txtFechaDeIngreso.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtFechaDeIngreso.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtFechaDeIngreso, "Debe ingresar una fecha");
            }
            DateTime ingreso;
            if (!DateTime.TryParse(txtFechaDeIngreso.Text, out ingreso))
            {
                valido = false;
                errorProvider1.SetError(txtFechaDeIngreso, "Debe ingresar una fecha valida");
            }
            if (ingreso>DateTime.Today)
            {
                valido = false;
                errorProvider1.SetError(txtFechaDeIngreso, "La fecha ingresada no puede superar la fecha actual");
            }
            if (string.IsNullOrEmpty(txtVencimiento.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtVencimiento.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtVencimiento, "Debe ingresar un vencimiento");
            }
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtCantidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCantidad, "Debe ingresar una cantidad");
            }
            int cantidad = 0;
            if (!int.TryParse(txtCantidad.Text,out cantidad))
            {
                valido = false;
                errorProvider1.SetError(txtCantidad, "Debe ingresar una cantidad valida en números");
            }
            if (cantidad<=0)
            {
                valido = false;
                errorProvider1.SetError(txtCantidad, "Debe ingresar una cantidad valida");
            }
            if (cmbMedicamento.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbMedicamento, "Debe seleccionar un medicamento");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioLote _servicio = new ServicioLote();
        private frmLotes frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (lote == null)
                {
                    lote = new Lote();
                }

                lote.Identificacion = txtIdentificacion.Text;
                lote.FechaDeIngreso = Convert.ToDateTime( txtFechaDeIngreso.Text);
                lote.Vencimiento = txtVencimiento.Text;
                lote.Cantidad =int.Parse( txtCantidad.Text);

                lote.Medicamento = (Medicamento)cmbMedicamento.SelectedItem;


                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(lote);
                            if (frm != null)
                            {
                                frm.AgregarFila(lote);

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
            txtIdentificacion.Clear();
            txtFechaDeIngreso.Clear();
            txtVencimiento.Clear();
            txtCantidad.Clear();
            cmbMedicamento.SelectedIndex = 0;
            cmbMedicamento.Focus();
            lote = null;

        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(lote))
            {
                valido = false;
                errorProvider1.SetError(txtIdentificacion, "Lote repetido");
            }

            return valido;
        }


    }
}
