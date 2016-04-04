using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class Land
    {
        private String naam;

        public int LandId { get; set; }
        public string Naam
        {
            get { return naam; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Land vereist een naam.");
                naam = value;
            }
        }

        public ICollection<Locatie> Locaties { get; set; }

        public Land(string naam)
        {
            Locaties = new List<Locatie>();
            Naam = naam;
        }

        [ExcludeFromCodeCoverage]
        public Land()
        {
            
        }

        public void AddLocatie(Locatie locatie)
        {
            Locaties.Add(locatie);
        }
    }
}