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
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            Helper.CargarComboProveedor(ref cbmProveedor);
            Helper.CargarComboMedicamentos(ref cbmMedicamento);
            lista.Clear();
            btnComprar.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                ComprasMedicamentos comprasMedicamentos = new ComprasMedicamentos();
                comprasMedicamentos.Cantidad = int.Parse(txtCantidad.Text);
                comprasMedicamentos.Medicamento = (Medicamento)cbmMedicamento.SelectedItem;
                comprasMedicamentos.Precio = comprasMedicamentos.Medicamento.PrecioVenta * comprasMedicamentos.Cantidad;



                AgregarFila(comprasMedicamentos);
                lista.Add(comprasMedicamentos);
                cbmProveedor.Enabled = false;
                ActualizarTotal();
                btnComprar.Enabled = true;
            }
        }
        private void MostrarEnGrilla()
        {
            dgbDatos.Rows.Clear();
            foreach (var comprasMedicamentos in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, comprasMedicamentos);
                AñadirFila(r);
            }
        }

        private List<ComprasMedicamentos> lista = new List<ComprasMedicamentos>();


        private void AñadirFila(DataGridViewRow r)
        {
            dgbDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ComprasMedicamentos comprasMedicamentos)
        {
            r.Cells[clmProveedor.Index].Value =((Proveedor)cbmProveedor.SelectedItem).RazonSocial;
            r.Cells[clmMedicamento.Index].Value = comprasMedicamentos.Medicamento.NombreComercial;
            r.Cells[clmCantidad.Index].Value =comprasMedicamentos.Cantidad;
            r.Cells[clmTotal.Index].Value = comprasMedicamentos.Precio;

            r.Tag = comprasMedicamentos;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgbDatos);
            return r;
        }

        public void AgregarFila(ComprasMedicamentos comprasMedicamentos)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, comprasMedicamentos);
            AñadirFila(r);

        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool verdadero = true;
            if (cbmProveedor.SelectedIndex==0)
            {
                verdadero = false;
                errorProvider1.SetError(cbmProveedor, "Seleccione un dato");
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
            if (!int.TryParse(txtCantidad.Text, out Cantidad ))
            {
                verdadero = false;
                errorProvider1.SetError(txtCantidad, "Ingrese una cantidad valida");
            }
            if (Cantidad<=0)
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
            return verdadero;
        }

        private void dgbDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                var r =  dgbDatos.SelectedRows[0];
                dgbDatos.Rows.RemoveAt(e.RowIndex);
                ComprasMedicamentos comprasMedicamentos = (ComprasMedicamentos)r.Tag;
                lista.Remove(comprasMedicamentos);
                ActualizarTotal();
                if (lista.Count==0)
                {
                    cbmProveedor.Enabled = true;
                    btnComprar.Enabled = false;
                }
                else
                {
                    btnComprar.Enabled = true;
                }
            }
        }

        private void ActualizarTotal()
        {
            double total = 0;
            foreach (var cm in lista)
            {
                total += cm.Precio;
            }
            txtTotal.Text = "$ " + total.ToString();
        }
        private ServicioCompra servicioCompra = new ServicioCompra();
        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                Compra compra = new Compra();
                compra.ComprasMedicamentos = lista;
                compra.Fecha = DateTime.Now;
                compra.Proveedor = (Proveedor)cbmProveedor.SelectedItem;
                servicioCompra.Guardar(compra);

                MessageBox.Show("Compra realizada con éxito", "Comprado", MessageBoxButtons.OK);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
