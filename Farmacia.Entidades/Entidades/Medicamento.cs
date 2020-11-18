using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia.Entidades.Entidades
{
    public class Medicamento
    {
        public int MedicamentoId { get; set; }
        public string NombreComercial { get; set; }
        public Droga Droga { get; set; }
        public TipoDeMedicamento TipoDeMedicamento { get; set; }
        public FormaFarmaceutica FormaFarmaceutica { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public double PrecioVenta { get; set; }
        public int UnidadesEnStok { get; set; }
        public int NivelDeReposicion { get; set; }
        public string CantidadesPorUnidad { get; set; }
        public bool Suspendido { get; set; }

    }
}
