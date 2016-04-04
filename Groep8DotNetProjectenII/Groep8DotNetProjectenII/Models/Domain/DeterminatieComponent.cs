using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Groep8DotNetProjectenII.Models.Domain
{
    [ExcludeFromCodeCoverage]
    public abstract class DeterminatieComponent
    {
        public int DeterminatieComponentId { get; set; }
        public virtual void Add(DeterminatieComponent c, bool b)
        {
            throw new NotSupportedException("Kan geen volgend component toevoegen");
        }

        public abstract string[] Determineer(Klimatogram klimatogram);

        public abstract IDictionary<string, string> GeefKlimaatEnVegetatieTypes(IDictionary<string, string> map);
    }
}
