using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class Graad
    {
        private int graadNummer;
        public int GraadNummer {
            get { return graadNummer; }
            set
            {
                if(value < 1 || value > 3)
                    throw new ArgumentException("De graad moet zich tussen 1 en 3 bevinden.");
                graadNummer = value;
            }
        }

        public virtual DeterminatieTabel DeterminatieTabel { get; set; }
        public virtual VragenLijst VragenLijst { get; set; }

        public Graad(int graadNummer)
        {
            this.GraadNummer = graadNummer;
        }
        [ExcludeFromCodeCoverage]
        public Graad()
        {
            
        }
    }
}