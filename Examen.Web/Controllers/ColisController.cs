using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class ColisController : Controller
    {

        IServiceColis serviceColis;
        IServiceClient serviceClient;
        IServiceLivreur serviceLivreur;
        public ColisController(IServiceColis serviceColis,IServiceClient serviceClient, IServiceLivreur serviceLivreur)
        {
            this.serviceColis = serviceColis;
            this.serviceClient = serviceClient;
            this.serviceLivreur = serviceLivreur;
        }

        // GET: ColisController
        public ActionResult Index()
        {
            return View(serviceColis.GetMany());
        }

        // GET: ColisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColisController/Create
        public ActionResult Create()

        {
            //                                             "on recupere par "  "je veux ca"  
            ViewBag.LivreurFK = new SelectList(serviceLivreur.GetMany(), "CIN", "CIN");
           
            ViewBag.ClientFK = new SelectList(serviceClient.GetMany(), "Id", "Nom");

            return View();
        }

        // POST: ColisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Colis collection)
        {
            try
            {
                serviceColis.Add(collection);
                serviceColis.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ColisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
