
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Colis
    {
        public DateTime DateLivraison { get; set; }
        public double Montant { get; set; }
        public double Poids { get; set; }
        public double Volume { get; set; }
      public virtual Livreur Livreur { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Client")]
        public int ClientFK { get; set; }
        [ForeignKey("Livreur")]
        public string LivreurFK { get; set; }

    }
}
