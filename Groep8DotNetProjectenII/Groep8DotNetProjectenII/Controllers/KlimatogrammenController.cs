using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep8DotNetProjectenII.Models.Domain;
using Groep8DotNetProjectenII.ViewModels;
using WebGrease.Css.Extensions;

namespace Groep8DotNetProjectenII.Controllers
{
    public class KlimatogrammenController : Controller
    {
        private IContinentRepository continentenRepository;
        private ILandRepository landenRepository;
        private IKlimatogramRepository klimatogramRepository;
        private ILocatieRepository locatieRepository;

        public KlimatogrammenController(IContinentRepository continentenRepository, ILandRepository landenRepository, IKlimatogramRepository klimatogramRepository, ILocatieRepository locatieRepository)
        {
            this.continentenRepository = continentenRepository;
            this.landenRepository = landenRepository;
            this.klimatogramRepository = klimatogramRepository;
            this.locatieRepository = locatieRepository;
        }

        public ActionResult Index(Leerjaar leerjaar)
        {
            if (ModelState.IsValid)
            {
                    List<Continent> continenten = continentenRepository.PerJaar(leerjaar).ToList();
                    KlimatogrammenIndexViewModel kivm = new KlimatogrammenIndexViewModel(continenten);

                    return View(kivm);   
            }
            else
            {
                TempData["Error"] = "Gelieve eerst een leerjaar te selecteren";
                return RedirectToAction("Index", "Oefeningen");
            }
            
            
        }

        [HttpPost]
        public ActionResult SelecteerLand(KlimatogrammenIndexViewModel kivm)
        {

            Continent c = continentenRepository.FindById(kivm.ContinentId);
            if (c!= null )
                kivm.Landen = c.Landen.OrderBy(l=>l.Naam).ToList();
            return PartialView("_LandSelecteren", kivm);
        }

        [HttpPost]
        public ActionResult SelecteerWeerstation(KlimatogrammenIndexViewModel kivm)
        {

            Land l = landenRepository.FindById(kivm.LandId);
            if (l!=null && l.Locaties.Count == 0)
            {
                TempData["Message"] = "Het land heeft geen klimatogrammen";

            }
            kivm.Weerstations = l.Locaties.OrderBy(w => w.Naam).ToList();

            return PartialView("_WeerstationSelecteren", kivm);
        }

        [HttpPost]
        public ActionResult MaakKlimatogram(KlimatogramTonenViewModel ktvm)
        {
           
            Locatie l = locatieRepository.FindById(ktvm.WeerstationId);
            if (l != null)                
                ktvm = new KlimatogramTonenViewModel(l);

            return PartialView("_KlimatogramTonen", ktvm);
        }

        public ActionResult VerwijderSessie(Leerjaar jaar)
        {
            jaar.Verwijder();
            return RedirectToAction("Index", "Oefeningen");
        }

    }

}