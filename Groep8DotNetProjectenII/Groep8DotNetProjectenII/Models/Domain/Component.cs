using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using Groep8DotNetProjectenII.Models.Domain;

namespace DeterminerenTest.Models.Domein
{
    public class Component : DeterminatieComponent
    {

        public virtual Vraag Vraag { get; set; }
        public virtual DeterminatieComponent YesComponent { get; set; }
        public virtual DeterminatieComponent NoComponent { get; set; }

        override 
        public void Add(DeterminatieComponent c, bool b)
        {
            if (b)
            {
                YesComponent = c;
            }
            else
            {
                NoComponent = c;
            }
        }

        override
        public string[] Determineer(Klimatogram klimatogram)
        {
            return Vraag.Antwoord(klimatogram)
                ? YesComponent.Determineer(klimatogram)
                : NoComponent.Determineer(klimatogram);
        }

        public override IDictionary<string, string> GeefKlimaatEnVegetatieTypes(IDictionary<string, string> map)
        {
            map = YesComponent.GeefKlimaatEnVegetatieTypes(map);
            map = NoComponent.GeefKlimaatEnVegetatieTypes(map);
            return map;
        }

        [ExcludeFromCodeCoverage]
        public Component()
        {
            
        }
    }
}