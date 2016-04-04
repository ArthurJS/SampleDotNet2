using System.Linq;
using DeterminerenTest.Models.Domein;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class TotNeerslagJaar : Parameter
    {
        public TotNeerslagJaar() : base("Nj", "Gemiddelde totale jaarneerslag")
        {
        }

        public override double GetWaarde(Klimatogram klimatogram)
        {
            return klimatogram.Maanden.Sum(m => m.GemNslg);
        }
    }
}