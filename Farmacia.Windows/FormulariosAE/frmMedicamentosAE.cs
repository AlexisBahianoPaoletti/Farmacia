using Farmacia.Entidades;
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
    public partial class frmMedicamentosAE : Form
    {
        public frmMedicamentosAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        public frmMedicamentosAE(frmMedicamentos frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.CargarComboDrogas(ref cmbDroga);
            Helper.CargarComboTiposDeMedicamentos(ref cmbTipoDeMedicamento);
            Helper.CargarComboFormasFarmaceuticas(ref cmbFormaFarmaceutica);
            Helper.CargarComboLaboratorios(ref cmbLaboratorio);

            if (medicamento != null)
            {
                txtNombre.Text = medicamento.NombreComercial;
                cmbDroga.SelectedValue = medicamento.Droga.DrogaId;
                cmbTipoDeMedicamento.SelectedValue = medicamento.TipoDeMedicamento.TipoDeMedicamentoId;
                cmbFormaFarmaceutica.SelectedValue = medicamento.FormaFarmaceutica.FormaFarmaceuticaId;
                cmbLaboratorio.SelectedValue = medicamento.Laboratorio.LaboratorioId;
                txtPrecioVenta.Text = medicamento.PrecioVenta.ToString();
                txtUnidadesEnStok.Text = medicamento.UnidadesEnStok.ToString();
                txtNivelDeReposicion.Text = medicamento.NivelDeReposicion.ToString();
                txtCantidadesPorUnidad.Text = medicamento.CantidadesPorUnidad;
                chbSuspendido.Checked = medicamento.Suspendido;

                _esEdicion = true;
                txtUnidadesEnStok.Enabled = false;
            }



        }

        private Medicamento medicamento;
        public void SetMedicamento(Medicamento medicamento)
        {
            this.medicamento = medicamento;
        }

        public Medicamento GetMedicamento()
        {
            return medicamento;
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
            if (string.IsNullOrEmpty(txtPrecioVenta.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtPrecioVenta.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtPrecioVenta, "Debe ingresar un precio de venta");
            }
            double precio=0;
            if (!double.TryParse(txtPrecioVenta.Text, out precio))
            {
                valido = false;
                errorProvider1.SetError(txtPrecioVenta, "Debe ingresar un precio de venta en números");
            }


            if (string.IsNullOrEmpty(txtUnidadesEnStok.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtUnidadesEnStok.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtUnidadesEnStok, "Debe ingresar las unidades en stok");
            }
            int unidad = 0;
            if (!int.TryParse(txtUnidadesEnStok.Text, out unidad))
            {
                valido = false;
                errorProvider1.SetError(txtUnidadesEnStok, "Debe ingresar las unidades de stok en números");
            }


            if (string.IsNullOrEmpty(txtNivelDeReposicion.Text.Trim()) &&
                string.IsNullOrWhiteSpace(txtNivelDeReposicion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtNivelDeReposicion, "Debe ingresar el nivel de reposicion");
            }
            int nivelReposicion = 0;
            if (!int.TryParse(txtNivelDeReposicion.Text, out nivelReposicion))
            {
                valido = false;
                errorProvider1.SetError(txtNivelDeReposicion, "Debe ingresar el nivel de reposicion en números");
            }

            if (string.IsNullOrEmpty(txtCantidadesPorUnidad.Text.Trim()) &&
                  string.IsNullOrWhiteSpace(txtCantidadesPorUnidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCantidadesPorUnidad, "Debe ingresar las cantidades por unidad");
            }
            if (cmbDroga.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbDroga, "Debe seleccionar una droga");
            }
            if (cmbTipoDeMedicamento.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbTipoDeMedicamento, "Debe seleccionar un tipo de medicamento");
            }

            if (cmbFormaFarmaceutica.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbFormaFarmaceutica, "Debe seleccionar una forma farmaceutica");
            }

            if (cmbLaboratorio.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cmbLaboratorio, "Debe seleccionar un laboratorio");
            }

            return valido;
        }

        private bool _esEdicion = false;
        private ServicioMedicamento _servicio = new ServicioMedicamento();
        private frmMedicamentos frm;
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                if (medicamento == null)
                {
                    medicamento = new Medicamento();
                }

                medicamento.NombreComercial = txtNombre.Text;
                medicamento.PrecioVenta = double.Parse(txtPrecioVenta.Text);
                medicamento.UnidadesEnStok = int.Parse(txtUnidadesEnStok.Text);
                medicamento.NivelDeReposicion = int.Parse(txtNivelDeReposicion.Text);
                medicamento.CantidadesPorUnidad = txtCantidadesPorUnidad.Text;
                medicamento.Suspendido = chbSuspendido.Checked;
                medicamento.Droga = (Droga)cmbDroga.SelectedItem;
                medicamento.TipoDeMedicamento = (TipoDeMedicamento)cmbTipoDeMedicamento.SelectedItem;
                medicamento.FormaFarmaceutica = (FormaFarmaceutica)cmbFormaFarmaceutica.SelectedItem;
                medicamento.Laboratorio = (Laboratorio)cmbLaboratorio.SelectedItem;


                if (ValidarObjeto())
                {

                    if (!_esEdicion)
                    {
                        try
                        {
                            _servicio.Guardar(medicamento);
                            if (frm != null)
                            {
                                frm.AgregarFila(medicamento);

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
            txtPrecioVenta.Clear();
            txtUnidadesEnStok.Clear();
            txtNivelDeReposicion.Clear();
            txtCantidadesPorUnidad.Clear();
            chbSuspendido.Checked = false; 
            cmbDroga.SelectedIndex = 0;
            cmbTipoDeMedicamento.SelectedIndex = 0;
            cmbFormaFarmaceutica.SelectedIndex = 0;
            cmbLaboratorio.SelectedIndex = 0;
            txtNombre.Focus();
            medicamento = null;

        }

        private bool ValidarObjeto()
        {
            var valido = true;
            errorProvider1.Clear();
            if (_servicio.Existe(medicamento))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "Medicamento repetido");
            }

            return valido;
        }


    }
}
