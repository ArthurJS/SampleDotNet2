using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groep8DotNetProjectenII.Controllers;
using Groep8DotNetProjectenII.Models.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using Groep8DotNetProjectenII.ViewModels;

namespace Groep8DotNetProjectenII.Tests.Controllers
{
    [TestClass]
    public class KlimatogrammenControllerTest
    {
        private Mock<IContinentRepository> continentenRepository;
        private Mock<ILandRepository> landenRepository;
        private Mock<IKlimatogramRepository> klimatogramRepository;
        private Mock<ILocatieRepository> locatieRepository;
        private KlimatogrammenController klimatogrammenController;
        private DummyKlimatogramContext context = new DummyKlimatogramContext();

        public KlimatogrammenControllerTest()
        {
            continentenRepository = new Mock<IContinentRepository>();
            landenRepository = new Mock<ILandRepository>();
            klimatogramRepository = new Mock<IKlimatogramRepository>();
            locatieRepository = new Mock<ILocatieRepository>();


            continentenRepository.Setup(c => c.FindAll()).Returns(context.Continenten);
            continentenRepository.Setup(c => c.PerJaar(Leerjaar.Vijfde)).Returns(context.Continenten);
            landenRepository.Setup(c => c.FindAll()).Returns(context.Landen);
            klimatogramRepository.Setup(c => c.FindAll()).Returns(context.Klimatogrammen);
            locatieRepository.Setup(c => c.FindAll()).Returns(context.Locatie);

            continentenRepository.Setup(c => c.PerJaar(Leerjaar.Eerste)).Returns(new Continent[] { context.Europa }.AsQueryable());
            continentenRepository.Setup(c => c.FindById(1)).Returns(context.Europa);
            continentenRepository.Setup(c => c.FindById(2)).Returns(context.Afrika);

            landenRepository.Setup(l => l.FindById(1)).Returns(context.België);
            landenRepository.Setup(l => l.FindById(2)).Returns(context.Togo);
            landenRepository.Setup(l => l.FindById(3)).Returns(context.Frankrijk);

            klimatogramRepository.Setup(k => k.FindById(1)).Returns(context.ukkelK);
            klimatogramRepository.Setup(k => k.FindById(2)).Returns(context.Lomek);

            locatieRepository.Setup(l => l.FindById(1)).Returns(context.Ukkel);
            locatieRepository.Setup(l => l.FindById(2)).Returns(context.Lome);

            klimatogrammenController = new KlimatogrammenController(continentenRepository.Object,
                landenRepository.Object, klimatogramRepository.Object, locatieRepository.Object);


        }

        [TestMethod]
        public void IndexGeeftKlimatogrammenIndexViewModelDoorAanView()
        {
            ViewResult vr = (ViewResult)klimatogrammenController.Index(Leerjaar.Vijfde);
            KlimatogrammenIndexViewModel kivm = vr.Model as KlimatogrammenIndexViewModel;
            Assert.AreEqual(context.Continenten.ElementAt(0), kivm.Continenten.ElementAt(0));
            Assert.AreEqual(context.Continenten.ElementAt(1), kivm.Continenten.ElementAt(1));
        }

        [TestMethod]
        public void IndexGeeftAlleenEuropaDoorBijEersteGraad()
        {
            ViewResult vr = (ViewResult)klimatogrammenController.Index(Leerjaar.Eerste);
            KlimatogrammenIndexViewModel kivm = vr.Model as KlimatogrammenIndexViewModel;
            Assert.AreEqual(1, kivm.Continenten.Count());
            Assert.AreEqual("Europa", kivm.Continenten.ElementAt(0).Naam);
        }

        [TestMethod]
        public void RetourneertNaarIndexOefeningenBijModelStateError()
        {
            klimatogrammenController.ModelState.AddModelError("", "someError");
            RedirectToRouteResult result = klimatogrammenController.Index(Leerjaar.Eerste) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Oefeningen", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void SelecteerLandGeeftListVanLandenDoorPartialView()
        {
            KlimatogrammenIndexViewModel kivm = new KlimatogrammenIndexViewModel() { ContinentId = 1 };
            PartialViewResult vr = (PartialViewResult)klimatogrammenController.SelecteerLand(kivm);
            KlimatogrammenIndexViewModel kivm2 = vr.Model as KlimatogrammenIndexViewModel;
            continentenRepository.Verify(l => l.FindById(1), Times.Once);
            Assert.AreEqual(context.België, kivm2.Landen.ElementAt(0));
        }

        [TestMethod]
        public void SelecteerWeerstationGeenKlimatogramGeeftMessageDoorAanView()
        {
            KlimatogrammenIndexViewModel kivm = new KlimatogrammenIndexViewModel() { LandId = 3 };
            var result = klimatogrammenController.SelecteerWeerstation(kivm);
            Assert.AreEqual(klimatogrammenController.TempData["Message"], "Het land heeft geen klimatogrammen");

        }
        [TestMethod]
        public void SelecteerWeerstationGeeftListVanWeerstationsDoorPartialView()
        {
            KlimatogrammenIndexViewModel kivm = new KlimatogrammenIndexViewModel() { LandId = 1 };
            PartialViewResult vr = (PartialViewResult)klimatogrammenController.SelecteerWeerstation(kivm);
            KlimatogrammenIndexViewModel kivm2 = vr.Model as KlimatogrammenIndexViewModel;
            landenRepository.Verify(l => l.FindById(1), Times.Once);
            Assert.AreEqual(context.Ukkel, kivm2.Weerstations.ElementAt(0));
        }

        [TestMethod]
        public void MaakKlimatogramGeeftKlimatogramTonenViewModelDoorAanPartialView()
        {
            KlimatogramTonenViewModel klimatogramTonenViewModelCorrect = new KlimatogramTonenViewModel(context.Ukkel);
            PartialViewResult pvr = (PartialViewResult)klimatogrammenController.MaakKlimatogram(klimatogramTonenViewModelCorrect);
            KlimatogramTonenViewModel klimatogramTonenViewModel = (KlimatogramTonenViewModel)pvr.Model;
            Assert.AreEqual(klimatogramTonenViewModel.WeerstationId, klimatogramTonenViewModelCorrect.WeerstationId);
            Assert.AreEqual(klimatogramTonenViewModel.BeginJaar, klimatogramTonenViewModelCorrect.BeginJaar);
            Assert.AreEqual(klimatogramTonenViewModel.EindJaar, klimatogramTonenViewModelCorrect.EindJaar);
            Assert.AreEqual(klimatogramTonenViewModel.SomJaarNeerslag, klimatogramTonenViewModelCorrect.SomJaarNeerslag);
            Assert.AreEqual(klimatogramTonenViewModel.GemiddeldeJaarTemperatuur, klimatogramTonenViewModelCorrect.GemiddeldeJaarTemperatuur);

        }
    }
}
