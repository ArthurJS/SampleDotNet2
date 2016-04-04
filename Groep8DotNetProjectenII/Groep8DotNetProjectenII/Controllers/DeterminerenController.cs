using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DeterminerenTest.Models.Domein;
using Groep8DotNetProjectenII.Models.DAL;
using Groep8DotNetProjectenII.Models.Domain;
using Groep8DotNetProjectenII.ViewModels;

namespace Groep8DotNetProjectenII.Controllers
{
    public class DeterminerenController : Controller
    {
        private ILocatieRepository locatieRepository;
        private IGradenRepository gradenRepository;

        public DeterminerenController(ILocatieRepository locatieRepository, IGradenRepository gradenRepository)
        {
            this.locatieRepository = locatieRepository;
            this.gradenRepository = gradenRepository;
        }

        public ActionResult Index(Leerjaar leerjaar, int klimatogramId)
        {
            Locatie l = locatieRepository.FindById(klimatogramId);
            Graad graad = gradenRepository.FindByGraadNummer(leerjaar.LeerjaarNaarGraad());
            VragenLijst vl = graad.VragenLijst;

            DeterminerenIndexViewModel divm = new DeterminerenIndexViewModel(graad.DeterminatieTabel, l.Klimatogram, vl);
            return View(divm);
        }

        public ActionResult ControleerKlimaatType(Leerjaar leerjaar, string klimaat, int KlimatogramId)
        {
            Graad g = gradenRepository.FindByGraadNummer(leerjaar.LeerjaarNaarGraad());
            DeterminatieTabel dt = g.DeterminatieTabel;
            Klimatogram klimatogram = locatieRepository.FindById(KlimatogramId).Klimatogram;
            IDictionary<string, string> mogelijke = dt.GeefKlimaatEnVegetatieTypes();

            string[] determinatie = dt.Determineer(klimatogram);

            ControleerViewModel cvm = new ControleerViewModel(1 + (int)leerjaar, determinatie, klimaat, mogelijke, KlimatogramId);

            return PartialView("ControleerKlimaatType", cvm);
        }

        public ActionResult ControleerVegetatieType(Leerjaar leerjaar, string geselecteerdeVegetatie, int KlimatogramId)
        {
            bool correct =
                geselecteerdeVegetatie.Equals(Regex.Replace(
                    gradenRepository.FindByGraadNummer(leerjaar.LeerjaarNaarGraad())
                        .DeterminatieTabel.Determineer(locatieRepository.FindById(KlimatogramId).Klimatogram)[1].ToLower(), @"\s+", ""));
            return PartialView("ControleerVegetatieType", new ControleerVegetatieViewModel(correct, (int)leerjaar + 1, KlimatogramId));
        }

        public ActionResult HaalFotoOp(Leerjaar leerjaar, int KlimatogramId)
        {
            string foto = Regex.Replace(
                    gradenRepository.FindByGraadNummer(leerjaar.LeerjaarNaarGraad())
                        .DeterminatieTabel.Determineer(locatieRepository.FindById(KlimatogramId).Klimatogram)[1].ToLower(), @"\s+", "");
            return PartialView("Foto", foto);
        }
    }
}