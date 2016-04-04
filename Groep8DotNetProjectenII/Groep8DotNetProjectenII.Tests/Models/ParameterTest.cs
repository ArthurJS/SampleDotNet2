using System;
using DeterminerenTest.Models.Domein;
using Groep8DotNetProjectenII.Models.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Groep8DotNetProjectenII.Tests.Models
{
    [TestClass]
    public class ParameterTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CodeMagNietNullZijn()
        {
            new ParameterExtensionTest(null, "beschrijving.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CodeMagNietLeegZijn()
        {
            new ParameterExtensionTest("", "beschrijving.");
            new ParameterExtensionTest("\r\n\t ", "beschrijving.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CodeMagGeenVreemdeKaraktersBevatten()
        {
            new ParameterExtensionTest("`µ£sqd2^5^¨", "beschrijving.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BeschrijvingMagNietNullZijn()
        {
            new ParameterExtensionTest("1000", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BeschrijvingMagNietLeegZijn()
        {
            new ParameterExtensionTest("1000", "");
            new ParameterExtensionTest("1000", "\r\n\t ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BeschrijvingMagGeenVreemdeKaraktersBevatten()
        {
            new ParameterExtensionTest("1000", "`µ£sqd2^5^¨");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KlimatogramMagnietNullZijn()
        {
            new ParameterExtensionTest("1000", "beschrijving").GetWaarde(null);
        }

        private class ParameterExtensionTest : Parameter
        {

            public ParameterExtensionTest(string code, string beschrijving)
                : base(code, beschrijving)
            { }



            public override double GetWaarde(Klimatogram klimatogram)
            {
                return 0.0;
            }

        }

    }
}
