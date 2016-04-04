using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public class Maand
    {
        #region fields

        private int maandNummer;

        #endregion

        #region properties

        public int MaandId { get; set; }
        public int GemNslg { get; set; }
        public double GemTmp { get; set; }
        public int MaandNummer {
            get { return maandNummer; }
            set
            {
                if (value < (int)Maanden.Januari || value > (int)Maanden.December)
                {
                    throw new InvalidOperationException("Een maand moet zich tussen 1 en 12 bevinden.");
                }
                maandNummer = value;
            }
        }
        
        #endregion


        public Maand(int maandNummer, double gemTmp, int gemNslg)
        {
            MaandNummer = maandNummer;
            GemTmp = gemTmp;
            GemNslg = gemNslg;
        }

        [ExcludeFromCodeCoverage]
        public Maand()
        {
            
        }

        

    }
}
