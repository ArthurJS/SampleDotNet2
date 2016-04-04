using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeterminerenTest.Models.Domein;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.ViewModels
{

    public class VragenViewModel
    {
        public KlimatogramTonenViewModel Ktvm { get; set; }
        public IList<ParameterViewModel> Pvm { get; set; }
        public int KlimatogramId { get; set; }

        public VragenViewModel(IList<ParameterViewModel> pvm, KlimatogramTonenViewModel ktvmn, int klimatogramId)
        {
            Pvm = pvm;
            Ktvm = ktvmn;
            Ktvm.Chart.SetPlotOptions(new PlotOptions
            {
                Column = new PlotOptionsColumn {Animation = new Animation(false)},
                Line = new PlotOptionsLine{Animation = new Animation(false)}
            });
            KlimatogramId = klimatogramId;
        }
    }

    public class ParameterViewModel
    {
       
        public string Vraag { get; set; }
        public SelectList MogelijkeAntwoorden { get; set; }

        public string Antwoord { get; set; }

        public bool Correct { get; set; }
        public ParameterViewModel(Parameter parameter, Klimatogram k)
        {

            Vraag = parameter.Beschrijving;
            MogelijkeAntwoorden = new SelectList(from KeyValuePair<double,string> p in parameter.MogelijkeAntwoorden(k) select new { ID = p.Key, Name = p.Value }, "ID", "Name");
        }

        public ParameterViewModel()
        {
            
        }


    }

}