using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep8DotNetProjectenII.Models.Domain;
using System.Collections.Generic;

namespace Groep8DotNetProjectenII.Tests
{
    [TestClass]
    public class ContinentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContinentNaamMagNietNullZijn()
        {
            Continent continent = new Continent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContinentNaamMagNietLeegZijn()
        {
            Continent continent = new Continent("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContinentNaamMagNietUitLegeKarakterBestaan()
        {
            Continent continent = new Continent(" \t  \n \r  ");
        }

        [TestMethod]
        public void AddLandVoegtNieuwLandToe()
        {
            Continent continent = new Continent("Europa");

            int aantalVoor = continent.Landen.Count;
            Land land = new Land("België");
            continent.AddLand(land);
            Assert.AreEqual(aantalVoor + 1, continent.Landen.Count);
            Assert.AreEqual("België", land.Naam);
        }
    }
}
