using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoDeDocumento TipoDeDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }
        public Localidad Localidad { get; set; }
        public Provincia Provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }

    }
}
