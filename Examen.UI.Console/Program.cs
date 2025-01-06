// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Interfaces;
using AM.Infrastructure;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Services;
using Examen.Infrastructure;

Console.WriteLine("Hello, World!");


ExamContext context = new ExamContext();
IUnitOfWork uow = new UnitOfWork(context);
IServicePneu servicePneu = new ServicePneu(uow);
IServiceOuvrier serviceOuvrier = new ServiceOuvrier(uow);
IServiceIntervention serviceIntervention = new ServiceIntervention(uow);

servicePneu.Add(new Pneu
{
    Diametre = 15,
    Description = "yo",
    Fabrication = DateTime.Now,
    marque = new Marque
    {
        Nom = "mohamed",
        Reputation = 5
    }
});

serviceOuvrier.Add(new Ouvrier
{
    Nom = "Michelle",
    Experience = 5,
    Qualifie = true


});




context.SaveChanges();

/*     public int Id { get; set; }
        public float Diametre { get; set; }
        public string Description { get; set; }

        public DateTime? Fabrication { get; set; } = new DateTime(2022,12,2);

        public virtual Marque marque { get; set; }

        public virtual List<Intervention> Interventions { get; set; }*/