using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DeterminerenTest.Models.Domein;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class NeerslagWinter : Parameter
    {
        private Maanden[] winterZuidelijk = { Maanden.April, Maanden.Mei, Maanden.Juni, Maanden.Juli, Maanden.Augustus, Maanden.September };
        private Maanden[] winterNoordelijk = { Maanden.Oktober, Maanden.November, Maanden.December, Maanden.Januari, Maanden.Februari, Maanden.Maart };
        public NeerslagWinter()
            : base("NW", "Hoeveelheid neerslag in de winter")
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
            return klimatogram.Maanden.Where(m => winterNoordelijk.Contains((Maanden)m.MaandNummer)).Sum(m => m.GemNslg);
        }

        private double geefNeerslagZuidelijk(Klimatogram klimatogram)
        {
            return klimatogram.Maanden.Where(m => winterZuidelijk.Contains((Maanden)m.MaandNummer)).Sum(m => m.GemNslg);
        }
    }
}