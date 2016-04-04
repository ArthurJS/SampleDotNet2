using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep8DotNetProjectenII.Models.Domain;

namespace DeterminerenTest.Models.Domein
{
    public abstract class Parameter
    {
        public int ParameterId { get; set; }
        public string Code { get; set; }

        public string Beschrijving { get; set; }

        protected Parameter(string code, string bes)
        {
            this.Code = code;
            this.Beschrijving = bes;
        }

        [ExcludeFromCodeCoverage]
        public Parameter()
        {
            
        }

        public abstract double GetWaarde(Klimatogram klimatogram);

        public virtual Dictionary<double, string> MogelijkeAntwoorden(Klimatogram klimatogram)
        {
            return new Dictionary<double, string>();
        }

        public bool ControleerAntwoord(double d, Klimatogram k)
        {
            return d.Equals(GetWaarde(k));
        }
    }
}