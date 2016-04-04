using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Groep8DotNetProjectenII.Models.Domain;
using Groep8DotNetProjectenII.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep8DotNetProjectenII.Tests.Models
{
    [TestClass]
    public class LeerjaarTest
    {
        [TestMethod]
        public void LeerlingEersteJaarZitInGraad1Jaar1()
        {
            Assert.AreEqual(1, Leerjaar.Eerste.LeerjaarNaarGraad());
            Assert.AreEqual(1, Leerjaar.Eerste.JaarGraad());
        }

        [TestMethod]
        public void LeerlingTweedeJaarZitInGraad1Jaar2()
        {
            Assert.AreEqual(1, Leerjaar.Tweede.LeerjaarNaarGraad());
            Assert.AreEqual(2, Leerjaar.Tweede.JaarGraad());
        }

        [TestMethod]
        public void LeerlingDerdeJaarZitInGraad2Jaar1()
        {
            Assert.AreEqual(2, Leerjaar.Derde.LeerjaarNaarGraad());
            Assert.AreEqual(1, Leerjaar.Derde.JaarGraad());
        }

        [TestMethod]
        public void LeerlingVierdeJaarZitInGraad2Jaar2()
        {
            Assert.AreEqual(2, Leerjaar.Vierde.LeerjaarNaarGraad());
            Assert.AreEqual(2, Leerjaar.Vierde.JaarGraad());
        }

        [TestMethod]
        public void LeerlingVijfdeJaarZitInGraad3Jaar1()
        {
            Assert.AreEqual(3, Leerjaar.Vijfde.LeerjaarNaarGraad());
            Assert.AreEqual(1, Leerjaar.Vijfde.JaarGraad());
        }

        [TestMethod]
        public void LeerlingZesdeJaarZitInGraad3Jaar2()
        {

            Assert.AreEqual(3, Leerjaar.Zesde.LeerjaarNaarGraad());
            Assert.AreEqual(2, Leerjaar.Zesde.JaarGraad());
        }
    }
}
