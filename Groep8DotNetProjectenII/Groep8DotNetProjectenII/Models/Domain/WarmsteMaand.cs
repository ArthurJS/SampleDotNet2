using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DeterminerenTest.Models.Domein;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class WarmsteMaand : Parameter
    {
        public override double GetWaarde(Klimatogram klimatogram)
        {
            Maand warmste = klimatogram.Maanden.FirstOrDefault(ma => ma.GemTmp == klimatogram.Maanden.Max(g => g.GemTmp));
            return warmste.MaandNummer;
        }

        public WarmsteMaand() : base("Wm", "Warmste maand")
        {
            
        }

        public override Dictionary<double, string> MogelijkeAntwoorden(Klimatogram klimatogram)
        {
            var maanden = klimatogram.Maanden.ToDictionary(par => (double)((Maanden)par.MaandNummer), par => ((Maanden)par.MaandNummer).ToString());
            return maanden;

        }
    }
}
