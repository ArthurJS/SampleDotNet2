using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Tests.Models
{
    [TestClass]
    public class LocatieTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LocatieNaamMagNietNullZijn()
        {
            Locatie locatie = new Locatie(null, 10, 10, 12345, new Klimatogram());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LocatieNaamMagNietLeegZijn()
        {
            Locatie locatie = new Locatie("", 10, 10, 12345, new Klimatogram());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LocatieNaamMagNietUitLegeKarakterBestaan()
        {
            Locatie locatie = new Locatie(" \t  \n \r  ", 10, 10, 12345, new Klimatogram());
        }
    }
}
