using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Intervention
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public double Cout { get; set; }
        public TypeIntervention Type { get; set; }

        public virtual Ouvrier Ouvrier { get; set; }
        [ForeignKey("Ouvrier")]
        public int OuvrierKey { get; set; }
        public virtual Pneu Pneu { get; set; }
        [ForeignKey("Pneu")]
        public int PneuKey { get; set; }



    }

    public enum TypeIntervention
    {
        Verification,
        Reparation,
        Changement
    }
}
