using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Fournisseur
    {
        public int FournisseurId { get; set; }
        [Required(ErrorMessage ="Addresse fournisseur obligatoire")]
        public string Adresse { get; set; }
        public virtual List<Marque> Marques { get; set; }
    }
}
