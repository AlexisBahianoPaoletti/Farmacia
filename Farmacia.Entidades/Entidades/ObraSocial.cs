using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades.Entidades
{
    public class ObraSocial
    {
        public int ObraSocialId { get; set; }

        public string NombreObraSocial { get; set; }

        public double PorcentajeDeDescuento { get; set; }
        public List<ClientesObrasSociales> ClientesObrasSociales { get; set; } = new List<ClientesObrasSociales>();
    }
}
