using System.ComponentModel.DataAnnotations;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.ViewModels
{
    public class OefeningenIndexViewModel
    {
        [Display(Name = "Selecteer leerjaar")]
        public Leerjaar Leerjaar { get; set; }

        public OefeningenIndexViewModel()
        {
            
        }
    }

    public class OefeningenOefeningViewModel
    {
        public int Graad { get; set; }
        public int Jaar { get; set; }

        public OefeningenOefeningViewModel(int graad, int jaar)
        {
            Graad = graad;
            Jaar = jaar;
        }

        public OefeningenOefeningViewModel()
        {
            
        }
    }
}