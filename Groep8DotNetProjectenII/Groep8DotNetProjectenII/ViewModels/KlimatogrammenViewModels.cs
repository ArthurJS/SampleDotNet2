using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.ViewModels
{
    public class KlimatogrammenIndexViewModel
    {
        public IList<Continent> Continenten { get; set; }

        [Display(Name = "Selecteer werelddeel")]
        public int ContinentId { get; set; }

        public IList<Land> Landen { get; set; }
        [Display(Name = "Selecteer land")]
        public int LandId { get; set; }
        public IList<Locatie> Weerstations { get; set; }
        [Display(Name = "Selecteer weerstation")]
        public int WeerstationId { get; set; }

        public KlimatogrammenIndexViewModel(IList<Continent> continenten)
        {
            this.Continenten = continenten;

        }

        public KlimatogrammenIndexViewModel()
        {

        }
    }

    public class KlimatogramTonenViewModel
    {
        public int WeerstationId { get; set; }
        public Highcharts Chart { get; set; }
        public ICollection<int> Neerslagen { get; set; }
        public ICollection<double> Temperaturen { get; set; }
        public int BeginJaar { get; set; }
        public int EindJaar { get; set; }
        public double GemiddeldeJaarTemperatuur { get; set; }
        public int SomJaarNeerslag { get; set; }
        public bool Selecteren { get; set; }

        public KlimatogramTonenViewModel(Locatie l, bool selecteren = true)
        {
            Selecteren = selecteren;
            Neerslagen      = new List<int>();
            Temperaturen    = new List<double>();
            
            WeerstationId   = l.WeerstationNummer;
            EindJaar        = l.Klimatogram.EindDatum;
            BeginJaar       = l.Klimatogram.BeginDatum;
            
            GemiddeldeJaarTemperatuur = l.Klimatogram.GemmideldeJaarTemperatuur;
            SomJaarNeerslag = l.Klimatogram.SomJaarNeerslag;

            for (int i = 0; i < Enum.GetValues(typeof(Maanden)).Length; i++)
            {
                double ctmp = l.Klimatogram.Maanden.ElementAt(i).GemTmp;
                int cnrslg = l.Klimatogram.Maanden.ElementAt(i).GemNslg;
                Neerslagen.Add(cnrslg);
                Temperaturen.Add(ctmp);
            }


            double maxTmp = Temperaturen.Max(t => t);
            double minTmp = Temperaturen.Min(t => t);
            double maxNsl = Neerslagen.Max(t => t);

            int maxTmpAfg = (int) (maxTmp + (10 - maxTmp%10));
            int minTmpAfg = (int) (minTmp - (10 + minTmp%10));
            int maxNslAfg = (int) (maxNsl + (10 - maxNsl%10));

            YAxis neerslagAxis = new YAxis
            {
                Max = maxNsl / 2 > maxTmp ? maxNslAfg : 2 * maxTmpAfg,
                Min = minTmp > 0 ? 0 : minTmpAfg * 2,
                TickInterval = 10,
                Labels = new YAxisLabels
                {
                    Formatter = "function() { return this.value >= 0 ? this.value : ''; }",
                    
                    Style = "color: '#89A54E'"
                },
                Title = new YAxisTitle
                {
                    Text = "Neerslag (mm)",
                    Style = "color: '#89A54E'"
                }
            };

            YAxis tempAxis = new YAxis()
            {

                Max = maxNsl / 2> maxTmp ? maxNslAfg / 2 : maxTmpAfg,
                Min = minTmp > 0 ? 0 : minTmpAfg,
                TickInterval = 5,
                Labels = new YAxisLabels
                {
                    Formatter = "function() { return this.value ; }",
                    Style = "color: '#4572A7'"
                },
                Title = new YAxisTitle
                {
                    Text = "Temperatuur (°C)",
                    Style = "color: '#4572A7'"
                },
                Opposite = true
            };

            //tempAxis.TickInterval = neerslagAxis.TickInterval / 2;
            int[] longitude = l.GeeLongitudeGradenMinutenSeconden();
            int[] latitude = l.GeefLatitudeGradenMinutenSeconden();

            var chart = new Highcharts("chart")
                    .SetTitle(new Title() { Text = String.Format("{0} ({1}) - {2}", l.Naam, l.Land.Naam, WeerstationId)})
                    .SetSubtitle(
                        new Subtitle() { 
                            Text = String.Format("Latitude: {0}° {1}&apos; N Longitude: {2}° {3}&apos; W",
                            latitude[0], latitude[1], longitude[0], longitude[1]), UseHTML = true
                        }
                    )
                    .SetXAxis(new XAxis
                    {
                        Categories =
                            new[] { "J", "F", "M", "A", "M", "J", "J", "A", "S", "O", "N", "D" }
                    })
                    .SetYAxis(new[]
                {
                    neerslagAxis,tempAxis
                   
                })
                    .SetSeries(new[]
                {
                    new Series
                    {
                        Name    = "Neerslag (mm)",
                        Type    = ChartTypes.Column,
                        Color   = ColorTranslator.FromHtml("#0141B0"),
                        Data    = new Data(Neerslagen.Cast<object>().ToArray())
                    },
                    new Series
                    {
                        Name    = "Temperatuur (°C)",
                        Type    = ChartTypes.Line,
                        YAxis   = "1",
                        Color   = ColorTranslator.FromHtml("#FF0303"),
                        Data    = new Data(Temperaturen.Cast<object>().ToArray())
                    }
                });
            
            Chart = chart;
        }

        public KlimatogramTonenViewModel()
        {
            
        }


    }

}