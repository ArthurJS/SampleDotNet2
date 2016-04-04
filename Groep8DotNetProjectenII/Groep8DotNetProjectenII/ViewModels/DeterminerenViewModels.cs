using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DeterminerenTest.Models.Domein;
using Groep8DotNetProjectenII.Models.Domain;
using Newtonsoft.Json;

namespace Groep8DotNetProjectenII.ViewModels
{
    public class DeterminerenIndexViewModel
    {
        public DeterminatieTabelViewModel DeterminatieTabelViewModel { get; set; }

        public KlimatogramTonenViewModel KlimatogramTonenViewModel { get; set; }
        public int KlimatogramId { get; set; }
        public IDictionary<string, string> Antwoorden { get; set; }

        public DeterminerenIndexViewModel(DeterminatieTabel determinatieTabel, Klimatogram k, VragenLijst vl)
        {
            if (vl != null)
                Antwoorden = vl.GeefAntwoordenTabel(k);
            DeterminatieTabelViewModel = new DeterminatieTabelViewModel(determinatieTabel, k);
            KlimatogramTonenViewModel = new KlimatogramTonenViewModel(k.Locatie, false);
        }
    }

    public class DeterminatieTabelViewModel
    {
        private DeterminatieComponentViewModel dcvmFirstNode;
        private Klimatogram klimatogram;
        public string JSON { get; set; }
        public DeterminatieTabelViewModel(DeterminatieTabel determinatieTabel, Klimatogram k)
        {
            dcvmFirstNode = new DeterminatieComponentViewModel(determinatieTabel.FirstNode);
            this.klimatogram = k;
            setCorrectPath();
            JSON = JsonConvert.SerializeObject(dcvmFirstNode);
        }

        public void setCorrectPath()
        {

            DeterminatieComponentViewModel current = dcvmFirstNode.Vraag.Antwoord(klimatogram) ? dcvmFirstNode.children[0] : dcvmFirstNode.children[1];
            current.Correct = true;
            while (current.children != null)//current.GetType() == typeof (Component))
            {
                current = current.Vraag.Antwoord(klimatogram) ? current.children[0] : current.children[1];
                current.Correct = true;
            }
        }
    }

    public class DeterminatieComponentViewModel
    {
        public string name { get; set; }
        public DeterminatieComponentViewModel Parent { get; set; }
        public DeterminatieComponentViewModel[] children { get; set; }
        public bool Yes { get; set; }

        public bool Correct { get; set; }
        [JsonIgnore]
        public Vraag Vraag { get; set; }

        public DeterminatieComponentViewModel(DeterminatieComponent determinatieComponent)
        {
            if (determinatieComponent.GetType() == typeof(Leaf))
            {
                Leaf l = (Leaf)determinatieComponent;
                name = l.Klimaat;
            }
            else
            {
                Component c = ((Component)determinatieComponent);
                name = c.Vraag.ToString();
                DeterminatieComponentViewModel dy = new DeterminatieComponentViewModel(c.YesComponent);
                //dy.Parent = this;
                dy.Yes = true;
                DeterminatieComponentViewModel dn = new DeterminatieComponentViewModel(c.NoComponent);
                //dn.Parent = this;
                dn.Yes = false;
                children = new[] { dy, dn };
                Vraag = c.Vraag;
            }
        }
    }

    public class ControleerViewModel
    {
        public string Vegetatie { get; set; }
        public bool Correct { get; set; }
        public SelectList MogelijkeAntwoorden { get; set; }
        public int Leerjaar { get; set; }
        public int Jaar { get; set; }
        public int KlimatogramId { get; set; }

        public ControleerViewModel(int jaar, string[] determinatie, string antwoord, IDictionary<string, string> mogelijkeAntwoorden, int klimatogramId)
        {
            KlimatogramId = klimatogramId;
            Jaar = jaar;
            List<SelectListItem> items = mogelijkeAntwoorden.Select(m => new SelectListItem() { Text = Regex.Replace(m.Value.ToLower(), @"\s+", ""), Value = m.Value }).ToList();
            MogelijkeAntwoorden = new SelectList(items, "Text", "Value");
            Vegetatie = Regex.Replace(determinatie[1].ToLower(), @"\s+", "");
            Correct = Regex.Replace(determinatie[0].ToLower(), @"\s+", "") == Regex.Replace(antwoord.ToLower(), @"\s+", "");
        }
    }

    public class ControleerVegetatieViewModel
    {
        public bool Correct { get; set; }
        public int Jaar { get; set; }
        public int KlimatogramId { get; set; }
        public ControleerVegetatieViewModel(bool correct, int jaar, int klimatogramId)
        {
            Correct = correct;
            Jaar = jaar;
            KlimatogramId = klimatogramId;
        }
    }
}