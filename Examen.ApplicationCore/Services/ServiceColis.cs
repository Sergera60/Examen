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
    public class ServiceColis : Service<Colis>, IServiceColis
    {
        public ServiceColis(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
        public IEnumerable<Colis> GetColisByLivreurGroupByClient(string idLivreur)
        {
            return GetMany().Where(c => c.LivreurFK == idLivreur).GroupBy(c => c.ClientFK).SelectMany(c => c);
        }

       

        public double GetPoidsTotalColisALivrer(string idLivreur)
        {
            double poidsTotal = 0;
            DateTime date = DateTime.Now;
            for (int i = 0; i < 7; i++)
            {
                date = date.AddDays(i);
                poidsTotal += GetMany().Where(c => c.LivreurFK == idLivreur && c.DateLivraison == date).Sum(c => c.Poids);
            }
            return poidsTotal;
        }

     


        public IEnumerable<Vehicule> GetVehiculesPourLivreur(string idLivreur)
        {
            double poidsTotal = GetPoidsTotalColisALivrer(idLivreur);
            if (poidsTotal < 50)
            {
                return GetMany().Where(c => c.LivreurFK == idLivreur).Select(c => c.Livreur.Vehicules).Where(v => v is Voiture).Cast<Voiture>(); ;
            }
            else
            {
                return GetMany()
            .Where(c => c.LivreurFK == idLivreur) 
            .SelectMany(c => c.Livreur.Vehicules)
            .Where(v => v is Camion) 
            .OrderBy(v => Math.Abs(((Camion)v).Capacite - poidsTotal)) 
            .Take(5);
            }
        }

    }
}   
