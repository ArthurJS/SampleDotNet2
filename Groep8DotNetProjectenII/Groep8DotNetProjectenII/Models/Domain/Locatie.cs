using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class Locatie
    {
        private String naam;
        public int WeerstationNummer { get; set; }
        public string Naam {
            get { return naam; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Locatie vereist een naam.");
                naam = value;
            }
        }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Klimatogram Klimatogram { get; set; }

        public Land Land { get; set; }

        public Locatie(string naam, double longitude, double latitude, int weerstationNummer, Klimatogram klimatogram)
        {
            Naam = naam;
            Longitude = longitude;
            Latitude = latitude;
            WeerstationNummer = weerstationNummer;
            Klimatogram = klimatogram;
        }

        [ExcludeFromCodeCoverage]
        public Locatie()
        {
            
        }

        public int[] GeeLongitudeGradenMinutenSeconden()
        {
            int graden = (int)Longitude;
            string minuten = Longitude.ToString().Substring(Longitude.ToString().IndexOf(',') + 1);
            if (minuten.ToCharArray().Count() == 1) minuten += 0;	
            return new int[]{graden,int.Parse(minuten)};	
        }

        public int[] GeefLatitudeGradenMinutenSeconden()
        {
            int graden = (int)Latitude;
            string minuten = Latitude.ToString().Substring(Latitude.ToString().IndexOf(',')+1);
            if (minuten.ToCharArray().Count() == 1) minuten += 0;
            return new int[] { graden, int.Parse(minuten) };
        }
    }
}
