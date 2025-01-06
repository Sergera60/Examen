using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Pneu
    {
        public int Id { get; set; }
        public float Diametre { get; set; }
        public string Description { get; set; }

        public DateTime? Fabrication { get; set; } = new DateTime(2022,12,2);

        public virtual Marque marque { get; set; }

        public virtual List<Intervention> Interventions { get; set; }
    }
}
