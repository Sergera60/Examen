using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Ouvrier
    {
        public int OuvrierId { get; set; }
        public string Nom { get; set; }
        public int Experience { get; set; }

        public bool Qualifie { get; set; }

        public virtual List<Intervention> Interventions { get; set; }

    }
}
