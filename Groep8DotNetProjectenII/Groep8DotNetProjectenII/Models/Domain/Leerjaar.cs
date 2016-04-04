using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public enum Leerjaar
    {
        [Display(Name="Eerste leerjaar")]
        Eerste = 0,
        [Display(Name = "Tweede leerjaar")]
        Tweede = 1,
        [Display(Name = "Derde leerjaar")]
        Derde = 2,
        [Display(Name = "Vierde leerjaar")]
        Vierde = 3,
        [Display(Name = "Vijfde leerjaar")]
        Vijfde = 4,
        [Display(Name = "Zesde leerjaar")]
        Zesde = 5,
    }

    public static class LeerjaarMethods
    {
        public const string SESSIONNAAM  = "leerjaar";

        public static int LeerjaarNaarGraad(this Leerjaar l)
        {
            return (int) l/2 + 1;
        }

        public static int JaarGraad(this Leerjaar l)
        {
            return (int)l % 2 + 1;
        }

        [ExcludeFromCodeCoverage]
        public static void Selecteer(this Leerjaar l)
        {
            HttpContext.Current.Session[SESSIONNAAM] = l;
        }

        [ExcludeFromCodeCoverage]
        public static void Verwijder(this Leerjaar l)
        {
            HttpContext.Current.Session.Remove(SESSIONNAAM);
        }
    }
}
