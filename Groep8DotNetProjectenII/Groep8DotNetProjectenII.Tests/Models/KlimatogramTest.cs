using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep8DotNetProjectenII.Models.Domain;
using System.Collections.Generic;

namespace Groep8DotNetProjectenII.Tests.Models
{
    [TestClass]
    public class KlimatogramTest
    {
        //Klimatogram(ICollection<Maand> maanden, int beginDatum, int eindDatum)
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EindDatumMagNietKleinerZijnDanBeginDatum()
        {
            ICollection<Maand> maanden = new List<Maand>();
            Klimatogram klimatogram = new Klimatogram(maanden, 2000, 1995);
        }

        [TestMethod]
        public void AddMaandVoegtNieuweMaandToe()
        {
            ICollection<Maand> maanden = new List<Maand>();
            Klimatogram klimatogram = new Klimatogram(maanden, 1995, 2000);

            int aantalVoor = klimatogram.Maanden.Count;
            Maand maand = new Maand(1, 20, 21);
            klimatogram.AddMaand(maand);
            Assert.AreEqual(aantalVoor + 1, klimatogram.Maanden.Count);
            Assert.AreEqual(1, maand.MaandNummer);
        }

        [TestMethod]
        public void GemiddeldeJaarTemperatuurCorrect()
        {
            ICollection<Maand> maanden = new List<Maand>()
            {
                new Maand(0, 10,10),
                new Maand(1, 10,10),
                new Maand(2, 10,10),
                new Maand(3, 10,10),
                new Maand(4, 10,10),
                new Maand(5, 10,10),
                new Maand(6, 10,10),
                new Maand(7, 10,10),
                new Maand(8, 10,10),
                new Maand(9, 10,10),
                new Maand(10, 10,10),
                new Maand(11, 10,10)
            };
            Klimatogram klimatogram = new Klimatogram(maanden, 1995, 2000);
            Assert.AreEqual(10, klimatogram.GemmideldeJaarTemperatuur);
        }

        [TestMethod]
        public void TotaleJaarneerslagCorrect()
        {
            ICollection<Maand> maanden = new List<Maand>()
            {
                new Maand(0, 10,10),
                new Maand(1, 10,10),
                new Maand(2, 10,10),
                new Maand(3, 10,10),
                new Maand(4, 10,10),
                new Maand(5, 10,10),
                new Maand(6, 10,10),
                new Maand(7, 10,10),
                new Maand(8, 10,10),
                new Maand(9, 10,10),
                new Maand(10, 10,10),
                new Maand(11, 10,10)
            };
            Klimatogram klimatogram = new Klimatogram(maanden, 1995, 2000);
            Assert.AreEqual(120, klimatogram.SomJaarNeerslag);
        }
    }
}
