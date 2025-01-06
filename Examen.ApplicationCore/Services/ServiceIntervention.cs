using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceIntervention : Service<Intervention>, IServiceIntervention
    {
        public ServiceIntervention(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        
        }

        public double getCoutMoyenDesIntervensionParHeure()
        {

            var coutMoyen = GetMany()
           .Where(p => p.DateFin > p.DateDebut && p.Ouvrier.Qualifie) 
           .Select(p => new
           {
               DurationInHours = (p.DateFin - p.DateDebut).TotalHours, 
               p.Cout 
           })
           .Where(p => p.DurationInHours > 0) 
           .Average(p => p.Cout / p.DurationInHours); 

            return coutMoyen;

        }

        public string getNomMarqueWithHightIntervention()
        {
            //get nom de marque qui a le plus grand nombre d'intervention et de type Reparation other methode
            var nom = GetMany().Where(p => p.Type == TypeIntervention.Reparation)
                .GroupBy(i => i.Pneu.marque.Nom)
                .OrderByDescending(p => p.Count()).
                FirstOrDefault();
           

            return nom.ToString();




        }
    }
}
