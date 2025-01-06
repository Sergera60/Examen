using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Marque
    {
        [Key]
        public string Nom { get; set; }

        public int Reputation { get; set; }

        public virtual List<Fournisseur> Fournisseurs { get; set; }

        public virtual List<Pneu> Pneus { get; set; }
    }
}
