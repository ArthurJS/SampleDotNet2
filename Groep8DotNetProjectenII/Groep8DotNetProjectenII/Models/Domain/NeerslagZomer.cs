using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DeterminerenTest.Models.Domein;
using WebGrease.Css.Extensions;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class NeerslagZomer : Parameter
    {
        private Maanden[] zomerNoordelijk = { Maanden.April, Maanden.Mei, Maanden.Juni, Maanden.Juli, Maanden.Augustus, Maanden.September };
        private Maanden[] zomerZuidelijk = { Maanden.Oktober, Maanden.November, Maanden.December, Maanden.Januari, Maanden.Februari, Maanden.Maart };
        public NeerslagZomer()
            : base("NZ", "Hoeveelheid neerslag in de zomer")
        {
        }



        public override double GetWaarde(Klimatogram klimatogram)
        {

            return klimatogram.Locatie.Latitude > 0 ? geefNeerslagNoordelijk(klimatogram) : geefNeerslagZuidelijk(klimatogram);
        }

        public override Dictionary<double, string> MogelijkeAntwoorden(Klimatogram klimatogram)
        {
            Dictionary<double, string> neerslagen;
            if (geefNeerslagNoordelijk(klimatogram) != geefNeerslagZuidelijk(klimatogram))
            {
                neerslagen = new Dictionary<double, string>()
                {
                    {geefNeerslagNoordelijk(klimatogram), geefNeerslagNoordelijk(klimatogram).ToString()},
                    {geefNeerslagZuidelijk(klimatogram), geefNeerslagZuidelijk(klimatogram).ToString()}
                };
            }
            else
            {
                neerslagen = new Dictionary<double, string>()
                {
                    {geefNeerslagNoordelijk(klimatogram), geefNeerslagNoordelijk(klimatogram).ToString()}
                };
            }


            return neerslagen;
        }

        private double geefNeerslagNoordelijk(Klimatogram klimatogram)
        {
            return klimatogram.Maanden.Where(m => zomerNoordelijk.Contains((Maanden)m.MaandNummer)).Sum(m => m.GemNslg);
        }

        private double geefNeerslagZuidelijk(Klimatogram klimatogram)
        {
            return klimatogram.Maanden.Where(m => zomerZuidelijk.Contains((Maanden)m.MaandNummer)).Sum(m => m.GemNslg);
        }

    }
}