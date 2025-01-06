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
    public class ServicePneu : Service<Pneu> , IServicePneu
    {
        public ServicePneu(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public int nbPneus()
        {
      
            //Retourner le nb total des pneu dont la date de fabrication est inconnue
            return GetMany(p => p.Fabrication == null).Count(); 
        }
    }
}
