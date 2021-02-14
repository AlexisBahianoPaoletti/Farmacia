using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades.Entidades
{
    public class Compra
    {
        public int CompraId { get; set; }

        public Proveedor Proveedor { get; set; }

        public DateTime Fecha { get; set; }

        public List<ComprasMedicamentos> ComprasMedicamentos { get; set; } = new List<ComprasMedicamentos>();
 

    }
}
