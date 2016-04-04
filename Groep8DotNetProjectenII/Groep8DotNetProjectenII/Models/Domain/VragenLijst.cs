﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
﻿using System.Web.Mvc;
﻿using DeterminerenTest.Models.Domein;
﻿using ModelState = System.Web.ModelBinding.ModelState;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class VragenLijst
    {
        public int VragenLijstId { get; set; }
        public virtual List<Parameter> Vragen { get; set; }

        public VragenLijst()
        {
            Vragen = new List<Parameter>();
        }

        public VragenLijst(List<Parameter> vragen)
        {
            Vragen = vragen;
        }

        public void AddVraag(Parameter parameter)
        {
            Vragen.Add(parameter);
        }

        public IDictionary<string, string> GeefAntwoordenTabel(Klimatogram k)
        {
            return Vragen.ToDictionary(par => par.Beschrijving, par => par.MogelijkeAntwoorden(k).FirstOrDefault(item => item.Key == par.GetWaarde(k)).Value);
        }

        public List<bool> controleerAntwoorden(List<string> antwoorden, Klimatogram k)
        {
            var isJuist = new List<bool>();
            for(int i=0; i<antwoorden.Count; i++)
            {
                isJuist.Add(Vragen[i].GetWaarde(k).Equals(Double.Parse(antwoorden[i])));
            }
            return isJuist;
        } 
        
    }
}