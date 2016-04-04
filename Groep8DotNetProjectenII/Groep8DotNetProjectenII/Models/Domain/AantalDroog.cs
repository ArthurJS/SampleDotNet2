using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using DeterminerenTest.Models.Domein;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class AantalDroog : Parameter
    {
        public AantalDroog() : base("D", "Aantal droge maanden")
        {
        }

        public override double GetWaarde(Klimatogram klimatogram)
        {
            return klimatogram.Maanden.Count(m => m.GemTmp * 2 > m.GemNslg);
        }

        public override Dictionary<double, string> MogelijkeAntwoorden(Klimatogram klimatogram)
        {
            var aantal = new Dictionary<double, string>()
            {
                {0,"0"}, {1,"1"},{2,"2"},{3,"3"},{4,"4"},{5,"5"},
                {6,"6"}, {7,"7"},{8,"8"},{9,"9"},{10,"10"},{11,"11"}, {12,"12"}
            };
            return aantal;
        }
    }
}