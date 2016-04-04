using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Groep8DotNetProjectenII.Models.Domain;

namespace DeterminerenTest.Models.Domein
{
    public class GemTempJaar : Parameter
    {
        public GemTempJaar() : base("Tj", "De gemiddelde jaartemperatuur in °C")
        {
        }

        public override double GetWaarde(Klimatogram klimatogram)
        {
            return klimatogram.Maanden.Average(m => m.GemTmp);
        }
    }
}