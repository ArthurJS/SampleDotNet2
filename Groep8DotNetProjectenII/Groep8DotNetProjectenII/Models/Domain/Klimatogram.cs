using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Ajax.Utilities;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class Klimatogram
    {
        private int eindDatum;
        public int KlimatogramId { get; set; }
        public ICollection<Maand> Maanden { get; set; }
        public int BeginDatum { get; set; }
        public int EindDatum
        {
            get
            {
                return eindDatum;
            }
            set
            {
                if (BeginDatum>value)
                    throw new ArgumentException("eind-datum moet later zijn dan begin-datum!");
                eindDatum = value;
            }
        }
        public double GemmideldeJaarTemperatuur {
            get { return Math.Round(Maanden.Select(m => m.GemTmp).Average(), 1, MidpointRounding.AwayFromZero); }
        }
        public int SomJaarNeerslag { 
            get { return Maanden.Select(m => m.GemNslg).Sum(); } 
        }

        public Locatie Locatie { get; set; }
       
        public Klimatogram(ICollection<Maand> maanden, int beginDatum, int eindDatum)
        {
            Maanden = maanden;
            BeginDatum = beginDatum;
            EindDatum = eindDatum;
        }
        [ExcludeFromCodeCoverage]
        public Klimatogram()
        {
            
        }
        public void AddMaand(Maand maand)
        {
            Maanden.Add(maand);
        }
    }
}