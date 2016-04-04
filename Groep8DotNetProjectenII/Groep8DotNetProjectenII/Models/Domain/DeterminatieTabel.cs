using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DeterminerenTest.Models.Domein;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class DeterminatieTabel
    {
        public int DeterminatieTabelId { get; set; }
        public virtual DeterminatieComponent FirstNode { get; set; }
        public string Naam { get; set; }
        public int Leerjaar { get; set; }

        public string[] Determineer(Klimatogram klimatogram)
        {
            return FirstNode.Determineer(klimatogram);
        }

        public IDictionary<string, string> GeefKlimaatEnVegetatieTypes()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            return FirstNode.GeefKlimaatEnVegetatieTypes(dic);
        }

        public DeterminatieTabel(DeterminatieComponent firstNode, string naam, int leerjaar)
        {
            FirstNode = firstNode;
            Naam = naam;
            Leerjaar = leerjaar;
        }

        [ExcludeFromCodeCoverage]
        public DeterminatieTabel()
        {
            
        }
    }
}