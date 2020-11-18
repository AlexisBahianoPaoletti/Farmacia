using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades.Entidades
{
    public class Lote
    {
        public int LoteId { get; set; }
        public Medicamento Medicamento { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public string Vencimiento { get; set; }
        public int Cantidad { get; set; }
    }
}
