using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DeterminerenTest.Models.Domein;
using WebGrease.Css.Extensions;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class TempKoudsteMaand : Parameter
    {

        public TempKoudsteMaand() : base("Tk", "Temperatuur koudste maand")
        {
            
        }

        public override double GetWaarde(Klimatogram klimatogram)
        {
            return klimatogram.Maanden.Min(m => m.GemTmp);
        }

        public override Dictionary<double, string> MogelijkeAntwoorden(Klimatogram klimatogram)
        {
            Dictionary<double, string> dic = new Dictionary<double, string>();
            klimatogram.Maanden.ForEach(par =>
            {
                if (!dic.ContainsKey(par.GemTmp))
                    dic.Add(par.GemTmp, par.GemTmp.ToString());
            });
            //var temps = klimatogram.Maanden.ToDictionary(par => (double) par.GemTmp, par => par.GemTmp.ToString());
            return dic;
        }
    }
}