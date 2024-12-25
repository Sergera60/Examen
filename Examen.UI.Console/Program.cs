

using AM.ApplicationCore.Interfaces;
using AM.Infrastructure;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Services;
using Examen.Infrastructure;

ExamContext context = new ExamContext();


// create 2 livreur and 2 client 
/*   public string CIN { get; set; }
        public string CodePostal { get; set; }
        public string RaisonSocial { get; set; }
        public string Ville { get; set; }*/

Livreur l1 = new Livreur { CIN = "123", CodePostal = "123", RaisonSocial = "123", Ville = "123" };
Livreur l2 = new Livreur { CIN = "456", CodePostal = "456", RaisonSocial = "456", Ville = "456" };

//update it in database using ExamContext

context.Livreurs.Add(l1);
context.Livreurs.Add(l2);
context.SaveChanges();

//create 2 client


Client c1 = new Client { CodePostal = "12345",  Nom = "yeeeey", Prenom = "yoyoyo", Ville = "Sussah" };

Client c2 = new Client { CodePostal = "84456456", Nom = "aaadsa", Prenom = "vafaba", Ville = "Tunis" };

context.Clients.Add(c1);
context.Clients.Add(c2);
context.SaveChanges();







