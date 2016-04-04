using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Groep8DotNetProjectenII.Controllers;
using Groep8DotNetProjectenII.Models.Domain;
using Groep8DotNetProjectenII.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Groep8DotNetProjectenII.Tests.Controllers
{
    [TestClass]
    public class VragenControllerTest
    {

        private Mock<IGradenRepository> gradenRepository;
        private Mock<ILocatieRepository> locatieRepository;
        private VragenController vragenController;
        private DummyKlimatogramContext context = new DummyKlimatogramContext();

        public VragenControllerTest()
        {
            gradenRepository = new Mock<IGradenRepository>();
            locatieRepository = new Mock<ILocatieRepository>();

            gradenRepository.Setup(g => g.FindByGraadNummer(Leerjaar.Eerste.LeerjaarNaarGraad())).Returns(context.Graad1);
            gradenRepository.Setup(g => g.FindByGraadNummer(Leerjaar.Tweede.LeerjaarNaarGraad())).Returns(context.Graad1);
            gradenRepository.Setup(g => g.FindByGraadNummer(Leerjaar.Derde.LeerjaarNaarGraad())).Returns(context.Graad2);
            gradenRepository.Setup(g => g.FindByGraadNummer(Leerjaar.Vierde.LeerjaarNaarGraad())).Returns(context.Graad2);
            gradenRepository.Setup(g => g.FindByGraadNummer(Leerjaar.Vijfde.LeerjaarNaarGraad())).Returns(context.Graad3);
            gradenRepository.Setup(g => g.FindByGraadNummer(Leerjaar.Zesde.LeerjaarNaarGraad())).Returns(context.Graad3);

            locatieRepository.Setup(l => l.FindById(context.Ukkel.WeerstationNummer)).Returns(context.Ukkel);
            locatieRepository.Setup(l => l.FindById(context.Lome.WeerstationNummer)).Returns(context.Lome);

            vragenController = new VragenController(gradenRepository.Object, locatieRepository.Object);
        }

        [TestMethod]
        public void LeerlingDerdeLeerjaarTweedeGraadRedirectNaarDetermineren()
        {
            vragenController.Index(Leerjaar.Derde, context.ukkelK.KlimatogramId);
            RedirectToRouteResult result = (RedirectToRouteResult)vragenController.Index(Leerjaar.Derde, context.ukkelK.KlimatogramId);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Determineren", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void LeerlingVierdeLeerjaarTweedeGraadRedirectNaarDetermineren()
        {
            vragenController.Index(Leerjaar.Vierde, context.ukkelK.KlimatogramId);
            RedirectToRouteResult result = (RedirectToRouteResult)vragenController.Index(Leerjaar.Vierde, context.ukkelK.KlimatogramId);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Determineren", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void LeerlingVijfdeLeerjaarDerdeGraadRedirectNaarDetermineren()
        {
            vragenController.Index(Leerjaar.Vijfde, context.ukkelK.KlimatogramId);
            RedirectToRouteResult result = (RedirectToRouteResult)vragenController.Index(Leerjaar.Vijfde, context.ukkelK.KlimatogramId);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Determineren", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void LeerlingZesdeLeerjaarDerdeGraadRedirectNaarDetermineren()
        {
            vragenController.Index(Leerjaar.Zesde, context.ukkelK.KlimatogramId);
            RedirectToRouteResult result = (RedirectToRouteResult)vragenController.Index(Leerjaar.Zesde, context.ukkelK.KlimatogramId);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Determineren", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void GeenLeerjaarGeselecteerdRedirectNaarLeerjaarSelecteren()
        {
            vragenController.ModelState.AddModelError("", "Gelieve het leerjaar te selecteren");
            RedirectToRouteResult result = (RedirectToRouteResult)vragenController.Index(Leerjaar.Eerste, context.ukkelK.KlimatogramId);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Oefeningen", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void IndexGeeftVragenViewModelDoorMetLijstVanParameterViewModelsEnKlimatogramTonenViewModelEnKlimatogramId()
        {
            ViewResult vr = (ViewResult)vragenController.Index(Leerjaar.Eerste, context.Ukkel.WeerstationNummer);
            VragenViewModel vragenViewModel = (VragenViewModel)vr.Model;
            VragenViewModel vragenViewModelCorrect = new VragenViewModel(context.Graad1.VragenLijst.Vragen.Select(v => new ParameterViewModel(v, context.ukkelK)).ToList(), new KlimatogramTonenViewModel(context.Ukkel, false), context.ukkelK.KlimatogramId);
            Assert.AreEqual(vragenViewModel.KlimatogramId, vragenViewModelCorrect.KlimatogramId);
            Assert.AreEqual(vragenViewModel.Ktvm.BeginJaar, vragenViewModelCorrect.Ktvm.BeginJaar);
            Assert.AreEqual(vragenViewModel.Ktvm.EindJaar, vragenViewModelCorrect.Ktvm.EindJaar);
            Assert.AreEqual(vragenViewModel.Ktvm.WeerstationId, vragenViewModelCorrect.Ktvm.WeerstationId);
            for (int i = 0; i < vragenViewModel.Pvm.Count; i++)
            {
                Assert.AreEqual(vragenViewModel.Pvm[i].Vraag, vragenViewModelCorrect.Pvm[i].Vraag);
                for (int i2 = 0; i2 < vragenViewModel.Pvm[i].MogelijkeAntwoorden.ToList().Count; i2++)
                {
                    Assert.AreEqual(vragenViewModel.Pvm[i].MogelijkeAntwoorden.ToList()[i].Value, vragenViewModelCorrect.Pvm[i].MogelijkeAntwoorden.ToList()[i].Value);
                }
            }
        }

        [TestMethod]
        public void ControleerAlleAntwoordenCorrectRedirectNaarDeterminerenIndex()
        {
            List<ParameterViewModel> pvm = context.Graad1.VragenLijst.Vragen.Select(v => new ParameterViewModel(v, context.ukkelK) { Antwoord = v.GetWaarde(context.ukkelK).ToString() }).ToList();
            RedirectToRouteResult result = (RedirectToRouteResult)vragenController.Index(Leerjaar.Eerste, pvm, context.Ukkel.WeerstationNummer);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Determineren", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void ControleerAntwoordenNietCorrectGeeftViewIndexDoorMetVragenViewModelMetParameterViewModelKlimatogramTonenViewModelEnKlimatogramId()
        {
            List<ParameterViewModel> pvm = context.Graad1.VragenLijst.Vragen.Select(v => new ParameterViewModel(v, context.ukkelK) { Antwoord = "fout" }).ToList();
            ViewResult vr = (ViewResult)vragenController.Index(Leerjaar.Eerste, pvm, context.Ukkel.WeerstationNummer);
            VragenViewModel vragenViewModel = (VragenViewModel)vr.Model;
            VragenViewModel vragenViewModelCorrect = new VragenViewModel(context.Graad1.VragenLijst.Vragen.Select(v => new ParameterViewModel(v, context.ukkelK)).ToList(), new KlimatogramTonenViewModel(context.Ukkel, false), context.ukkelK.KlimatogramId);
            Assert.AreEqual(vragenViewModel.KlimatogramId, vragenViewModelCorrect.KlimatogramId);
            Assert.AreEqual(vragenViewModel.Ktvm.BeginJaar, vragenViewModelCorrect.Ktvm.BeginJaar);
            Assert.AreEqual(vragenViewModel.Ktvm.EindJaar, vragenViewModelCorrect.Ktvm.EindJaar);
            Assert.AreEqual(vragenViewModel.Ktvm.WeerstationId, vragenViewModelCorrect.Ktvm.WeerstationId);
            for (int i = 0; i < vragenViewModel.Pvm.Count; i++)
            {
                Assert.AreEqual(vragenViewModel.Pvm[i].Vraag, vragenViewModelCorrect.Pvm[i].Vraag);
                for (int i2 = 0; i2 < vragenViewModel.Pvm[i].MogelijkeAntwoorden.ToList().Count; i2++)
                {
                    Assert.AreEqual(vragenViewModel.Pvm[i].MogelijkeAntwoorden.ToList()[i].Value, vragenViewModelCorrect.Pvm[i].MogelijkeAntwoorden.ToList()[i].Value);
                }
            }
        }

    }
}
