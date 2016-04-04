using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeterminerenTest.Models.Domein;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class AantalGroterDan10 : Parameter
    {
        public AantalGroterDan10() : base("# Tm > 10°C", "aantal maanden waar temperatuur groter dan of gelijk is aan 10°C")
        {
            
        }
        public override double GetWaarde(Klimatogram klimatogram)
        {
            return klimatogram.Maanden.Count(m => m.GemTmp >= 10);
        }
    }
}