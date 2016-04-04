using System;
using System.Linq;
using Groep8DotNetProjectenII.Models.Domain;
using Groep8DotNetProjectenII.Tests.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep8DotNetProjectenII.Tests.Models
{
    [TestClass]
    public class DeterminatieTabelTest
    {
        private DummyKlimatogramContext context = new DummyKlimatogramContext();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeterminatieTabelDeterminatieComponentNietNull()
        {
            new DeterminatieTabel(null, "een naam", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeterminatieTabelNaamIsNietNull()
        {
            new DeterminatieTabel(context.DeterminatieComponenten.ToList()[0], null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeterminatieTabelNaamMagNietLeegZijn()
        {
            new DeterminatieTabel(context.DeterminatieComponenten.ToList()[0], "", 1);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeterminatieTabelNaamMagGeenTabs()
        {
            new DeterminatieTabel(context.DeterminatieComponenten.ToList()[0], "\r\n\t ", 1);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeterminatieTabelLeerjaarNegatief()
        {
            new DeterminatieTabel(context.DeterminatieComponenten.ToList()[0], "naam", -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeterminatieTabelLeerjaarGroterDanVijf()
        {
            new DeterminatieTabel(context.DeterminatieComponenten.ToList()[0], "naam", 6);
        }

        [TestMethod]
        public void DetermineerGraad1GeeftCorrectAntwoord()
        {
            DeterminatieTabel determinatieTabel = context.Graad1.DeterminatieTabel;
            var resultaat = determinatieTabel.Determineer(context.ukkelK);
            Assert.AreEqual(resultaat[0], "Koel gematigd met zachte winter");
            Assert.AreEqual(resultaat[1], "Gematigd");
        }

        [TestMethod]
        public void DetermineerGraad23GeeftCorrectAntwoord()
        {
            DeterminatieTabel determinatieTabel = context.Graad2.DeterminatieTabel;
            var resultaat = determinatieTabel.Determineer(context.Lomek);
            Assert.AreEqual(resultaat[0], "Warm klimaat met nat seizoen");
            Assert.AreEqual(resultaat[1], "Tropische savanne");
        }

        /*[TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeterminatieTabelDetermineerNietNull()
        {
            DeterminatieTabel d = new DeterminatieTabel();
            d.Determineer(null);
        }



        */


    }
}
