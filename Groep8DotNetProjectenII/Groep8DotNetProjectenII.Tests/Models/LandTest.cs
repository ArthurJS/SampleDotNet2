using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep8DotNetProjectenII.Models.Domain;
using System.Collections.Generic;

namespace Groep8DotNetProjectenII.Tests.Models
{
    [TestClass]
    public class LandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LandNaamMagNietNullZijn()
        {
            Land land = new Land(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LandNaamMagNietLeegZijn()
        {
            Land land = new Land("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LandNaamMagNietUitLegeKarakterBestaan()
        {
            Land land = new Land(" \t  \n \r  ");
        }

        [TestMethod]
        public void AddLocatieVoegtLocatieToe()
        {

            Land land = new Land("België");

            int aantalVoor = land.Locaties.Count;
            Locatie location = new Locatie("Dendermonde", 10, 10, 12345, new Klimatogram());
            land.AddLocatie(location);
            Assert.AreEqual(aantalVoor + 1, land.Locaties.Count);
            Assert.AreEqual("België", land.Naam);
        }
    }

}
