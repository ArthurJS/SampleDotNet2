using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep8DotNetProjectenII.Controllers;
using Groep8DotNetProjectenII.Infrastructure;
using Groep8DotNetProjectenII.Models.Domain;
using Groep8DotNetProjectenII.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Groep8DotNetProjectenII.Tests.Controllers
{
    [TestClass]
    public class OefeningControllerTest
    {
        private OefeningenController oefeningenController;


        [TestInitialize]
        public void Initialize()
        {
            oefeningenController = new OefeningenController();
        }



        [TestMethod]
        public void IndexGeeftNieuwOefeningenIndexViewModeDoorAanView()
        {
            ViewResult vr = (ViewResult)oefeningenController.Index();

            OefeningenIndexViewModel oefeningenIndexViewModel = vr.Model as OefeningenIndexViewModel;
            //Default waarde van een enum attribuut is 0
            Assert.AreEqual(0, (int)oefeningenIndexViewModel.Leerjaar);
        }

        [TestMethod]
        public void HttpGetLeerjaarNegatiefRedirectNaarIndex()
        {
            int leerjaar = -1;
            RedirectToRouteResult result = (RedirectToRouteResult)oefeningenController.Oefening(leerjaar);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Oefeningen", result.RouteValues["controller"]);
        }
        [TestMethod]
        public void HttpGetLeerjaarGroterDanVijfRedirectNaarIndex()
        {
            int leerjaar = 6;
            RedirectToRouteResult result = (RedirectToRouteResult)oefeningenController.Oefening(leerjaar);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Oefeningen", result.RouteValues["controller"]);
        }

    }
}
