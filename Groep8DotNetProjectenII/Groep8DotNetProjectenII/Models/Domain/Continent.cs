using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class Continent
    {
        private string naam;

        public string Naam
        {
            get { return naam; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Continent vereist een naam.");
                naam = value;
            }
        }
        public ICollection<Land> Landen { get; set; }

        public int ContinentId { get; set; }

        public Continent(string naam)
        {
            Naam = naam;
            Landen = new List<Land>();
        }
        [ExcludeFromCodeCoverage]
        public Continent()
        {
            
        }

        public void AddLand(Land land)
        {
            Landen.Add(land);
        }
    }
}