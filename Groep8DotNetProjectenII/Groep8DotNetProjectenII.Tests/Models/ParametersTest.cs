using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using DeterminerenTest.Models.Domein;
using Groep8DotNetProjectenII.Models.Domain;
using Groep8DotNetProjectenII.Tests.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep8DotNetProjectenII.Tests.Models
{

    [TestClass]
    public class ParametersTest
    {

        private DummyKlimatogramContext dummy;
        private Parameter p;

        [TestInitialize]
        public void init()
        {
            dummy = new DummyKlimatogramContext();
        }


        [TestMethod]
        public void AantalDrogeMaanden()
        {
            p = new AantalDroog();
            Assert.AreEqual(0, p.GetWaarde(dummy.ukkelK));
            Assert.AreEqual(6, p.GetWaarde(dummy.Lomek));
        }
        [TestMethod]
        public void AantalDrogeMaandenMogelijkeAntwoorden()
        {
            p = new AantalDroog();
            Dictionary<double, string> mogelijkeAntwoorden = p.MogelijkeAntwoorden(dummy.ukkelK);
            Dictionary<double, string> antwoordenCorrect = new Dictionary<double, string>(){
                {0,"0"}, {1,"1"},{2,"2"},{3,"3"},{4,"4"},{5,"5"},
                {6,"6"}, {7,"7"},{8,"8"},{9,"9"},{10,"10"},{11,"11"}, {12,"12"}
            };
            for (int i = 0; i < mogelijkeAntwoorden.Count; i++)
            {
                Assert.AreEqual(antwoordenCorrect.Keys.ToList()[i], mogelijkeAntwoorden.Keys.ToList()[i]);
                Assert.AreEqual(antwoordenCorrect.Values.ToList()[i], mogelijkeAntwoorden.Values.ToList()[i]);
            }
        }
        [TestMethod]
        public void AantalGroterDan10()
        {
            p = new AantalGroterDan10();
            Assert.AreEqual(6, p.GetWaarde(dummy.ukkelK));
            Assert.AreEqual(12, p.GetWaarde(dummy.Lomek));
        }

        [TestMethod]
        public void GemTempJaar()
        {
            p = new GemTempJaar();
            Assert.AreEqual(9.65, p.GetWaarde(dummy.ukkelK), 0.01);
            Assert.AreEqual(26.90, p.GetWaarde(dummy.Lomek), 0.01);
        }


        [TestMethod]
        public void KoudsteMaand()
        {
            p = new KoudsteMaand();
            Assert.AreEqual((int)Maanden.Januari, (int)p.GetWaarde(dummy.ukkelK));
            Assert.AreEqual((int)Maanden.Augustus, (int)p.GetWaarde(dummy.Lomek));
        }

        [TestMethod]
        public void KoudsteMaandMogelijkeAntwoorden()
        {
            p = new KoudsteMaand();
            Dictionary<double, string> mogelijkeAntwoorden = p.MogelijkeAntwoorden(dummy.ukkelK);
            Dictionary<double, string> antwoordenCorrect = dummy.Ukkel.Klimatogram.Maanden.ToDictionary(m => (double)m.MaandNummer, m => ((Maanden)m.MaandNummer).ToString());
            for (int i = 0; i < mogelijkeAntwoorden.Count; i++)
            {
                Assert.AreEqual(antwoordenCorrect.Keys.ToList()[i], mogelijkeAntwoorden.Keys.ToList()[i]);
                Assert.AreEqual(antwoordenCorrect.Values.ToList()[i], mogelijkeAntwoorden.Values.ToList()[i]);
            }
        }

        [TestMethod]
        public void WarmsteMaand()
        {
            p = new WarmsteMaand();
            Assert.AreEqual((int)Maanden.Juli, (int)p.GetWaarde(dummy.ukkelK));
            Assert.AreEqual((int)Maanden.Maart, (int)p.GetWaarde(dummy.Lomek));
        }

        [TestMethod]
        public void WarmsteMaandMogelijkeAntwoorden()
        {
            p = new WarmsteMaand();
            Dictionary<double, string> mogelijkeAntwoorden = p.MogelijkeAntwoorden(dummy.ukkelK);
            Dictionary<double, string> antwoordenCorrect = dummy.Ukkel.Klimatogram.Maanden.ToDictionary(m=>(double)m.MaandNummer, m=>  ((Maanden)m.MaandNummer).ToString());
            for (int i = 0; i < mogelijkeAntwoorden.Count; i++)
            {
                Assert.AreEqual(antwoordenCorrect.Keys.ToList()[i], mogelijkeAntwoorden.Keys.ToList()[i]);
                Assert.AreEqual(antwoordenCorrect.Values.ToList()[i], mogelijkeAntwoorden.Values.ToList()[i]);
            }
        }

        [TestMethod]
        public void NeerslagWinter()
        {
            p = new NeerslagWinter();
            Assert.AreEqual(419, p.GetWaarde(dummy.ukkelK));
            Assert.AreEqual(188, p.GetWaarde(dummy.Lomek));
            Assert.AreEqual(0, p.GetWaarde(dummy.IquiqueK));
        }

        [TestMethod]
        public void NeerslagWinterMogelijkeAntwoorden()
        {
            p = new NeerslagWinter();
            Dictionary<double, string> mogelijkeAntwoorden = p.MogelijkeAntwoorden(dummy.ukkelK);
            Dictionary<double, string> antwoordenCorrect = new Dictionary<double, string>()
            {
                {419.0, "419"},
                {402.0, "402"}
            };
            for (int i = 0; i < mogelijkeAntwoorden.Count; i++)
            {
                Assert.AreEqual(antwoordenCorrect.Keys.ToList()[i], mogelijkeAntwoorden.Keys.ToList()[i]);
                Assert.AreEqual(antwoordenCorrect.Values.ToList()[i], mogelijkeAntwoorden.Values.ToList()[i]);
            }
        }

        [TestMethod]
        public void NeerslagZomer()
        {
            p = new NeerslagZomer();
            Assert.AreEqual(402, p.GetWaarde(dummy.ukkelK));
            Assert.AreEqual(690, p.GetWaarde(dummy.Lomek));
            Assert.AreEqual(0, p.GetWaarde(dummy.IquiqueK));
        }

        [TestMethod]
        public void NeerslagZomerMogelijkeAntwoorden()
        {
            p = new NeerslagZomer();
            Dictionary<double, string> mogelijkeAntwoorden = p.MogelijkeAntwoorden(dummy.ukkelK);
            Dictionary<double, string> antwoordenCorrect = new Dictionary<double, string>()
            {
                {402.0, "402"},
                {419.0, "419"}
            }; 
            for (int i = 0; i < mogelijkeAntwoorden.Count; i++)
            {
                Assert.AreEqual(antwoordenCorrect.Keys.ToList()[i], mogelijkeAntwoorden.Keys.ToList()[i]);
                Assert.AreEqual(antwoordenCorrect.Values.ToList()[i], mogelijkeAntwoorden.Values.ToList()[i]);
            }
        }

        [TestMethod]
        public void TempKoudsteMaand()
        {
            p = new TempKoudsteMaand();
            Assert.AreEqual(2.5, p.GetWaarde(dummy.ukkelK), 0.01);
            Assert.AreEqual(25.2, p.GetWaarde(dummy.Lomek), 0.01);
        }

        [TestMethod]
        public void TempKoudsteMaandMogelijkeAntwoorden()
        {
            p = new TempKoudsteMaand();
            Dictionary<double, string> mogelijkeAntwoorden = p.MogelijkeAntwoorden(dummy.ukkelK);
            Dictionary<double, string> antwoordenCorrect = dummy.Ukkel.Klimatogram.Maanden.ToDictionary(m => m.GemTmp, m => m.GemTmp.ToString());
            for (int i = 0; i < mogelijkeAntwoorden.Count; i++)
            {
                Assert.AreEqual(antwoordenCorrect.Keys.ToList()[i], mogelijkeAntwoorden.Keys.ToList()[i]);
                Assert.AreEqual(antwoordenCorrect.Values.ToList()[i], mogelijkeAntwoorden.Values.ToList()[i]);
            }
        }

        [TestMethod]
        public void TempWarmsteMaand()
        {
            p = new TempWarmsteMaand();
            Assert.AreEqual(17.2, p.GetWaarde(dummy.ukkelK), 0.01);
            Assert.AreEqual(28.5, p.GetWaarde(dummy.Lomek), 0.01);
        }

        [TestMethod]
        public void TempWarmsteMaandMogelijkeAntwoorden()
        {
            p = new TempWarmsteMaand();
            Dictionary<double, string> mogelijkeAntwoorden = p.MogelijkeAntwoorden(dummy.ukkelK);
            Dictionary<double, string> antwoordenCorrect = dummy.Ukkel.Klimatogram.Maanden.ToDictionary(m => m.GemTmp, m => m.GemTmp.ToString());
            for (int i = 0; i < mogelijkeAntwoorden.Count; i++)
            {
                Assert.AreEqual(antwoordenCorrect.Keys.ToList()[i], mogelijkeAntwoorden.Keys.ToList()[i]);
                Assert.AreEqual(antwoordenCorrect.Values.ToList()[i], mogelijkeAntwoorden.Values.ToList()[i]);
            }
        }

        [TestMethod]
        public void TotNeerslagJaar()
        {
            p = new TotNeerslagJaar();
            Assert.AreEqual(821, p.GetWaarde(dummy.ukkelK));
            Assert.AreEqual(878, p.GetWaarde(dummy.Lomek));
        }

        // Null Tests.

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AantalDroogGetWaardeKlimatogramNietNull()
        {
            new AantalDroog().GetWaarde(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AantalDroogMogelijkeAntwoordenKlimatogramNietNull()
        {
            new AantalDroog().MogelijkeAntwoorden(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AantalGroterDan10GetWaardeNietNull()
        {
            new AantalGroterDan10().GetWaarde(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GemTempJaarGetWaardeNietNull()
        {
            new GemTempJaar().GetWaarde(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KoudsteMaandGetWaardeKlimatogramNietNull()
        {
            new KoudsteMaand().GetWaarde(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KoudsteMaandMogelijkeAntwoordenKlimatogramNietNull()
        {
            new KoudsteMaand().MogelijkeAntwoorden(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TempKoudsteMaandGetWaardeKlimatogramNietNull()
        {
            new TempKoudsteMaand().GetWaarde(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TempKoudsteMaandMogelijkeAntwoordenKlimatogramNietNull()
        {
            new TempKoudsteMaand().MogelijkeAntwoorden(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TempWarmsteMaandGetWaardeKlimatogramNietNull()
        {
            new TempWarmsteMaand().GetWaarde(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TempWarmsteMaandMogelijkeAntwoordenKlimatogramNietNull()
        {
            new TempWarmsteMaand().MogelijkeAntwoorden(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TotNeerslagJaarGetWaardeKlimatogramNietNull()
        {
            new TotNeerslagJaar().GetWaarde(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WarmsteMaandGetWaardeKlimatogramNietNull()
        {
            new WarmsteMaand().GetWaarde(null);
        }

    }
}
