using Farmacia.Entidades;
using Farmacia.Entidades.Entidades;
using Farmacia.Servicio;
using Farmacia.Servicio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia.Windows.Helpers
{
    public class Helper
    {

        public static void CargarComboProvincias(ref ComboBox cbo)
        {
           ServicioProvincia servicioProvincia = new ServicioProvincia();
            cbo.DataSource = null;
            List<Provincia> lista = servicioProvincia.GetLista();
            var defaultProvincia = new Provincia { ProvinciaId = 0, NombreProvincia = "[Seleccione]" };
            lista.Insert(0, defaultProvincia);
            cbo.DataSource = lista;
            cbo.DisplayMember = "NombreProvincia";
            cbo.ValueMember = "ProvinciaId";
            cbo.SelectedIndex = 0;
        }

        internal static void CargarComboCliente(ref ComboBox cbm)
        {
            ServicioCliente servicioCliente = new ServicioCliente();
            cbm.DataSource = null;
            List<Cliente> lista = servicioCliente.GetLista();
            var defaultCliente = new Cliente { ClienteId = 0, Nombre = "[Seleccione]" };
            lista.Insert(0, defaultCliente);
            cbm.DataSource = lista;
            cbm.DisplayMember = "Nombre";
            cbm.ValueMember = "ClienteId";
            cbm.SelectedIndex = 0;
        }

        public static void CargarComboLocalidades(ref ComboBox cbo)
        {
            ServicioLocalidad servicioLocalidad = new ServicioLocalidad();
            cbo.DataSource = null;
            List<Localidad> lista = servicioLocalidad.GetLista();
            var defaultLocalidad = new Localidad { LocalidadId = 0, NombreLocalidad = "[Seleccione]" };
            lista.Insert(0, defaultLocalidad);
            cbo.DataSource = lista;
            cbo.DisplayMember = "NombreLocalidad";
            cbo.ValueMember = "LocalidadId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboTiposDeDocumentos(ref ComboBox cbo)
        {
            ServicioTipoDeDocumento servicioTipoDeDocumento = new ServicioTipoDeDocumento();
            cbo.DataSource = null;
            List<TipoDeDocumento> lista = servicioTipoDeDocumento.GetLista();
            var defaultTipoDeDocumento = new TipoDeDocumento { TipoDeDocumentoId = 0, Descripcion = "[Seleccione]" };
            lista.Insert(0, defaultTipoDeDocumento);
            cbo.DataSource = lista;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "TipoDeDocumentoId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboTiposDeIngredientes(ref ComboBox cbo)
        {
            ServicioTipoDeIngrediente servicioTipoDeIngrediente = new ServicioTipoDeIngrediente();
            cbo.DataSource = null;
            List<TipoDeIngrediente> lista = servicioTipoDeIngrediente.GetLista();
            var defaultTipoDeIngrediente = new TipoDeIngrediente { TipoDeIngredienteId = 0, TipoDeIngredientes = "[Seleccione]" };
            lista.Insert(0, defaultTipoDeIngrediente);
            cbo.DataSource = lista;
            cbo.DisplayMember = "TipoDeIngredientes";
            cbo.ValueMember = "TipoDeIngredienteId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboDrogas(ref ComboBox cbo)
        {
            ServicioDroga servicioDroga = new ServicioDroga();
            cbo.DataSource = null;
            List<Droga> lista = servicioDroga.GetLista();
            var defaultDroga = new Droga { DrogaId = 0, NombreDroga = "[Seleccione]" };
            lista.Insert(0, defaultDroga);
            cbo.DataSource = lista;
            cbo.DisplayMember = "NombreDroga";
            cbo.ValueMember = "DrogaId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboTiposDeMedicamentos(ref ComboBox cbo)
        {
            ServicioTipoDeMedicamento servicioTipoDeMedicamento = new ServicioTipoDeMedicamento();
            cbo.DataSource = null;
            List<TipoDeMedicamento> lista = servicioTipoDeMedicamento.GetLista();
            var defaultTipoDeMedicamento = new TipoDeMedicamento { TipoDeMedicamentoId = 0, Descripcion = "[Seleccione]" };
            lista.Insert(0, defaultTipoDeMedicamento);
            cbo.DataSource = lista;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "TipoDeMedicamentoId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboFormasFarmaceuticas(ref ComboBox cbo)
        {
            ServicioFormaFarmaceutica servicioFormaFarmaceutica = new ServicioFormaFarmaceutica();
            cbo.DataSource = null;
            List<FormaFarmaceutica> lista = servicioFormaFarmaceutica.GetLista();
            var defaultFormaFarmaceutica = new FormaFarmaceutica { FormaFarmaceuticaId = 0, Descripcion = "[Seleccione]" };
            lista.Insert(0, defaultFormaFarmaceutica);
            cbo.DataSource = lista;
            cbo.DisplayMember = "Descripcion";
            cbo.ValueMember = "FormaFarmaceuticaId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboLaboratorios(ref ComboBox cbo)
        {
            ServicioLaboratorio servicioLaboratorio = new ServicioLaboratorio();
            cbo.DataSource = null;
            List<Laboratorio> lista = servicioLaboratorio.GetLista();
            var defaultLaboratorio = new Laboratorio { LaboratorioId = 0, NombreLaboratorio = "[Seleccione]" };
            lista.Insert(0, defaultLaboratorio);
            cbo.DataSource = lista;
            cbo.DisplayMember = "NombreLaboratorio";
            cbo.ValueMember = "LaboratorioId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboMedicamentos(ref ComboBox cbo)
        {
            ServicioMedicamento servicioMedicamento = new ServicioMedicamento();
            cbo.DataSource = null;
            List<Medicamento> lista = servicioMedicamento.GetLista();
            var defaultMedicamento = new Medicamento { MedicamentoId = 0, NombreComercial = "[Seleccione]" };
            lista.Insert(0, defaultMedicamento);
            cbo.DataSource = lista;
            cbo.DisplayMember = "NombreComercial";
            cbo.ValueMember = "MedicamentoId";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboProveedor(ref ComboBox cbo)
        {
            ServicioProveedor servicioProveedor = new ServicioProveedor();
            cbo.DataSource = null;
            List<Proveedor> lista = servicioProveedor.GetLista();
            var defaultProveedor = new Proveedor { ProveedorId = 0, RazonSocial = "[Seleccione]" };
            lista.Insert(0, defaultProveedor);
            cbo.DataSource = lista;
            cbo.DisplayMember = "RazonSocial";
            cbo.ValueMember = "ProveedorId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboObraSocial(ref ComboBox cbo)
        {
            ServicioObraSocial servicioObraSocial = new ServicioObraSocial();
            cbo.DataSource = null;
            List<ObraSocial> lista = servicioObraSocial.GetLista();
            var defaultObraSocial = new ObraSocial { ObraSocialId = 0, NombreObraSocial = "[Seleccione]" };
            lista.Insert(0, defaultObraSocial);
            cbo.DataSource = lista;
            cbo.DisplayMember = "NombreObraSocial";
            cbo.ValueMember = "ObraSocialId";
            cbo.SelectedIndex = 0;
        }

    }
}
