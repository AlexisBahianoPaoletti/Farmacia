using Farmacia.Entidades.Entidades;
using Farmacia.Servicio.Servicios;
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

namespace Farmacia.Windows.Formularios
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            Helper.CargarComboCliente(ref cbmCliente);
            Helper.CargarComboMedicamentos(ref cbmMedicamento);
            lista.Clear();
            btnVender.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                VentasMedicamentos ventasMedicamentos = new VentasMedicamentos();
                ventasMedicamentos.Cantidad = int.Parse(txtCantidad.Text);
                ventasMedicamentos.medicamento = (Medicamento)cbmMedicamento.SelectedItem;
                ventasMedicamentos.Precio = (ventasMedicamentos.medicamento.PrecioVenta * 1.3 ) * ventasMedicamentos.Cantidad;



                AgregarFila(ventasMedicamentos);
                lista.Add(ventasMedicamentos);
                cbmCliente.Enabled = false;
                ActualizarTotal();
                btnVender.Enabled = true;
            }
        }
        private void MostrarEnGrilla()
        {
            dgbDatos.Rows.Clear();
            foreach (var ventasMedicamentos in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, ventasMedicamentos);
                AñadirFila(r);
            }
        }

        private List<VentasMedicamentos> lista = new List<VentasMedicamentos>();


        private void AñadirFila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, VentasMedicamentos ventasMedicamentos)
        {
            r.Cells[clmCliente.Index].Value = ((Cliente)cbmCliente.SelectedItem).Nombre;
            r.Cells[clmMedicamento.Index].Value = ventasMedicamentos.medicamento.NombreComercial;
            r.Cells[clmCantidad.Index].Value = ventasMedicamentos.Cantidad;
            r.Cells[clmTotal.Index].Value = ventasMedicamentos.Precio;

            r.Tag = ventasMedicamentos;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }

        public void AgregarFila(VentasMedicamentos ventasMedicamentos)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, ventasMedicamentos);
            AñadirFila(r);

        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool verdadero = true;
            if (cbmCliente.SelectedIndex == 0)
            {
                verdadero = false;
                errorProvider1.SetError(cbmCliente, "Seleccione un dato");
            }
            if (cbmMedicamento.SelectedIndex == 0)
            {
                verdadero = false;
                errorProvider1.SetError(cbmMedicamento, "Seleccione un dato");
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) && string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                verdadero = false;
                errorProvider1.SetError(txtCantidad, "Ingrese una cantidad");
            }
            int Cantidad = 0;
            if (!int.TryParse(txtCantidad.Text, out Cantidad))
            {
                verdadero = false;
                errorProvider1.SetError(txtCantidad, "Ingrese una cantidad valida");
            }
            if (Cantidad <= 0)
            {
                verdadero = false;
                errorProvider1.SetError(txtCantidad, "Ingrese una cantidad mayor que 0");

            }
            Medicamento medicamento = (Medicamento)cbmMedicamento.SelectedItem;
            if (medicamento.Suspendido)
            {
                verdadero = false;
                errorProvider1.SetError(cbmMedicamento, "Medicamento suspendido");
            }
            int stok = 0;
            foreach (var cm in lista)
            {
                stok += cm.Cantidad;

            }
            stok += Cantidad;

            if (medicamento.UnidadesEnStok<stok)
            {
                verdadero = false;
                errorProvider1.SetError(txtCantidad, "Ingrese una cifra menor a vender... No contamos con tanto Stok");
            }
            
            return verdadero;
        }

        private void dgbDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var r = dgbDatos.SelectedRows[0];
                dgbDatos.Rows.RemoveAt(e.RowIndex);
                VentasMedicamentos ventasMedicamentos = (VentasMedicamentos)r.Tag;
                lista.Remove(ventasMedicamentos);
                ActualizarTotal();
                if (lista.Count == 0)
                {
                    cbmCliente.Enabled = true;
                    btnVender.Enabled = false;
                }
                else
                {
                    btnVender.Enabled = true;
                }
            }
        }
        private ServicioCliente servicioCliente = new ServicioCliente();
        double total = 0;

        private void ActualizarTotal()
        {
            try
            {
                double subtotal = 0;
                double descuento = 0;
                foreach (var cm in lista)
                {
                    subtotal += cm.Precio;
                }
                txtSubtotal.Text = subtotal.ToString();
                Cliente cliente = (Cliente)cbmCliente.SelectedItem;
                if (servicioCliente.VerificarObraSocial(cliente))
                {
                    double Mayor = 0;
                    foreach (var co in cliente.ClientesObrasSociales)
                    {
                        if (Mayor < co.obraSocial.PorcentajeDeDescuento)
                        {
                            Mayor = co.obraSocial.PorcentajeDeDescuento;
                        }
                    }
                    descuento = Mayor;
                }
                double descuentoCuentaMatematica = (subtotal * descuento) / 100;
                txtDescuento.Text = descuento.ToString() + "%";
                total = subtotal - descuentoCuentaMatematica;
                txtTotal.Text = "$ " + total.ToString();
            }
            catch ( Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private ServicioVenta servicioVenta = new ServicioVenta();
        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                Venta venta = new Venta();
                venta.ventasMedicamentos = lista;
                venta.Fecha = DateTime.Now;
                venta.Cliente = (Cliente)cbmCliente.SelectedItem;
                venta.PrecioTotal = total;

                servicioVenta.Guardar(venta);


                MessageBox.Show("Venta realizada con éxito", "Vendido", MessageBoxButtons.OK);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
