using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Tests.Models
{
    [TestClass]
    public class MaandTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MaandNummerMoetTussen1En12Liggen()
        {
            Maand maand = new Maand(13, 9, 10);
        }
    }
}
