using Farmacia.Entidades.Entidades;
using Farmacia.Servicio.Servicios;
using Farmacia.Windows.FormulariosAE;
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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }


        private List<Cliente> lista;
        private ServicioCliente _servicio;

        private void MostrarEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var cliente in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, cliente);
                AñadirFila(r);
            }
        }



        private void AñadirFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Cliente cliente)
        {
            r.Cells[clmNombre.Index].Value = cliente.Nombre;
            r.Cells[clmApellido.Index].Value = cliente.Apellido;
            r.Cells[clmTipoDeDocumento.Index].Value = cliente.TipoDeDocumento.Descripcion;
            r.Cells[clmNroDocumento.Index].Value = cliente.NroDocumento;
            r.Cells[clmDireccion.Index].Value = cliente.Direccion;
            r.Cells[clmLocalidad.Index].Value = cliente.Localidad.NombreLocalidad;
            r.Cells[clmProvincia.Index].Value = cliente.Provincia.NombreProvincia;
            r.Cells[clmTelefonoFijo.Index].Value = cliente.TelefonoFijo;
            r.Cells[clmTelefonoMovil.Index].Value = cliente.TelefonoMovil;
            r.Cells[clmCorreoElectronico.Index].Value = cliente.CorreoElectronico;

            r.Tag = cliente;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        public void AgregarFila(Cliente cliente)
        {
            DataGridViewRow r = ConstruirFila();
            SetearFila(r, cliente);
            AñadirFila(r);

        }
        private void tslCerrar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmClientes_Load(object sender, System.EventArgs e)
        {
            try
            {
                _servicio = new ServicioCliente();
                lista = _servicio.GetLista();
                MostrarEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tslAgregar_Click(object sender, EventArgs e)
        {
            frmClientesAE frm = new frmClientesAE(this);
            frm.Text = "Nuevo Cliente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Cliente cliente = frm.GetCliente();
                    if (!_servicio.Existe(cliente))
                    {
                        _servicio.Guardar(cliente);
                        DataGridViewRow r = ConstruirFila();
                        SetearFila(r, cliente);
                        AñadirFila(r);
                        MessageBox.Show("Registro Agregado");
                    }
                    else
                    {
                        MessageBox.Show("Cliente repetido");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }

        private void tslBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Cliente cliente = (Cliente)r.Tag;

                DialogResult dr = MessageBox.Show(this, $"¿Desea dar de baja el cliente {cliente.Nombre}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        _servicio.Borrar(cliente.ClienteId);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro borrado");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);

                    }
                }
            }
        }


        private void tslEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Cliente cliente = (Cliente)r.Tag;
                cliente = _servicio.GetClientePorId(cliente.ClienteId);
                frmClientesAE frm = new frmClientesAE();
                frm.Text = "Editar Cliente";
                frm.SetCliente(cliente);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        cliente = frm.GetCliente();
                        if (!_servicio.Existe(cliente))
                        {
                            _servicio.Guardar(cliente);
                            SetearFila(r, cliente);
                            MessageBox.Show("Registro Editado");
                        }
                        else
                        {
                            MessageBox.Show("Cliente Repetido");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

    }
}
