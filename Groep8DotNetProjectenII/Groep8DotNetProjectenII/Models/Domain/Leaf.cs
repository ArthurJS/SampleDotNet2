using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DeterminerenTest.Models.Domein;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class Leaf : DeterminatieComponent
    {

        public string Klimaat { get; set; }
        public string Vegetatie { get; set; }

        override 
        public string[] Determineer(Klimatogram klimatogram)
        {
            return new string[]{Klimaat, Vegetatie};
        }

        public Leaf(string klimaat, string vegetatie)
        {
            this.Klimaat = klimaat;
            this.Vegetatie = vegetatie;
        }

        public override IDictionary<string, string> GeefKlimaatEnVegetatieTypes(IDictionary<string, string> map)
        {
            map.Add(Klimaat, Vegetatie);
            return map;
        }

        [ExcludeFromCodeCoverage]
        public Leaf()
        {
            
        }
    }
}