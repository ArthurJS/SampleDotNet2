using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DeterminerenTest.Models.Domein;
using Groep8DotNetProjectenII.Models.Domain;
using Groep8DotNetProjectenII.ViewModels;
using WebGrease.Css.Extensions;

namespace Groep8DotNetProjectenII.Controllers
{
    public class VragenController : Controller
    {
        private IGradenRepository gradenRepository;
        private ILocatieRepository locatieRepository;

        public VragenController(IGradenRepository gradenRepository, ILocatieRepository locatieRepository)
        {
            this.gradenRepository = gradenRepository;
            this.locatieRepository = locatieRepository;
        }

        public VragenController()
        {
            
        }

        public ActionResult Index(Leerjaar leerjaar, int klimatogramId = -1)
        {
            if (ModelState.IsValid && klimatogramId != -1)
            {
                int graad = leerjaar.LeerjaarNaarGraad();
                VragenLijst vragenlijst = gradenRepository.FindByGraadNummer(graad).VragenLijst;
                if (vragenlijst == null)
                {
                    return RedirectToAction("Index", "Determineren", new {klimatogramId = klimatogramId});
                }
                Locatie l = locatieRepository.FindById(klimatogramId);

                List<ParameterViewModel> parameterViewModels =
                    vragenlijst.Vragen.Select(p => new ParameterViewModel(p, l.Klimatogram)).ToList();
                VragenViewModel vvm = new VragenViewModel(parameterViewModels, new KlimatogramTonenViewModel(l, false), l.Klimatogram.KlimatogramId);

                return View(vvm);
            }
            TempData["Error"] = "Gelieve eerst een leerjaar te selecteren";
            return RedirectToAction("Index", "Oefeningen");
        }

        [HttpPost, ActionName("Controleer")]
        public ActionResult Index(Leerjaar leerjaar, [Bind(Prefix = "Pvm")]List<ParameterViewModel> antwoord, int klimatogramId)
        {
            Locatie l = locatieRepository.FindById(klimatogramId);
            if (ModelState.IsValid)
            {
                try
                {
                    VragenLijst vr = gradenRepository.FindByGraadNummer(leerjaar.LeerjaarNaarGraad()).VragenLijst;
                   
                    var isJuist = vr.controleerAntwoorden(antwoord.Select(a => a.Antwoord).ToList(),l.Klimatogram);
                    int positie=0;
                    
                    for (int i = 0; i < antwoord.Count; i++)
                    {
                        antwoord[i] = new ParameterViewModel(vr.Vragen.FirstOrDefault(p => p.Beschrijving == antwoord[i].Vraag), l.Klimatogram);
                        antwoord[i].Correct = isJuist[i];
                    }

                    if(antwoord.Count(a => !a.Correct)>0)
                        throw new Exception("Gelieve volgende vragen opnieuw te beantwoorden");

                    TempData["Message"] = "U heeft de vragen correct beantwoord";
                    return RedirectToAction("Index", "Determineren", new { klimatogramId = klimatogramId });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View("Index", new VragenViewModel(antwoord,new KlimatogramTonenViewModel(l, false), l.Klimatogram.KlimatogramId ));
        }
    }
}