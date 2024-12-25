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
    public class ServiceLivreur : Service<Livreur>, IServiceLivreur
    {
        public ServiceLivreur(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        //Retourner pour un livreur donné le poids total des colis qu’il doit transporter pendant 
        // les 7 jours suivants.(2 pts)

  



    }
}
