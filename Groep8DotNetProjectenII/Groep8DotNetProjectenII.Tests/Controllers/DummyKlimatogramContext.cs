using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeterminerenTest.Models.Domein;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Tests.Controllers
{
    class DummyKlimatogramContext
    {
        public IQueryable<Continent> Continenten { get; set; }
        public IQueryable<Land> Landen { get; set; }
        public IQueryable<Klimatogram> Klimatogrammen { get; set; }
        public IQueryable<Locatie> Locatie { get; set; }
        public IQueryable<Maand> Maanden { get; set; }
        public IQueryable<DeterminatieTabel> DeterminatieTabellen { get; set; }
        public IQueryable<DeterminatieComponent> DeterminatieComponenten { get; set; }
        public IQueryable<Vraag> Vragen { get; set; }
        public IQueryable<Parameter> Parameters { get; set; }
        public IQueryable<Graad> Graden { get; set; }
        public IQueryable<VragenLijst> VragenLijsten { get; set; }

        public Continent Afrika { get; set; }
        public Continent Europa { get; set; }
        public Continent ZuidAmerika { get; set; }
        public Land Togo { get; set; }
        public Land België { get; set; }
        public Land Frankrijk { get; set; }
        public Land Chili { get; set; }
        public List<Maand> maand { get; set; }
        public List<Maand> maand2 { get; set; }
        public List<Maand> Maand3 { get; set; }
        public Klimatogram ukkelK { get; set; }
        public Klimatogram Lomek { get; set; }
        public Klimatogram IquiqueK { get; set; }
        public Locatie Lome { get; set; }
        public Locatie Ukkel { get; set; }
        public Locatie Iquique { get; set; }
        public DeterminatieTabel DeterminatieTabel { get; set; }
        public DeterminatieTabel DeterminatieTabelGraad1 { get; set; }
        public Graad Graad1 { get; set; }
        public Graad Graad2 { get; set; }
        public Graad Graad3 { get; set; }

        public DummyKlimatogramContext()
        {
            Afrika = new Continent("Afrika");
            Europa = new Continent("Europa");
            ZuidAmerika = new Continent("Zuid-Amerika");

            Togo = new Land("Togo");
            België = new Land("Belgie");
            Frankrijk = new Land("Frankrijk");
            Chili = new Land("Chili");

            maand = new List<Maand>()
            {
              new Maand(1, 2.5, 67),
              new Maand(2,3.2,54),
              new Maand(3, 5.7, 73),
              new Maand(4, 8.7, 57),
              new Maand(5, 12.2, 70),
              new Maand(6, 15.5, 78),
              new Maand(7, 17.2, 75),
              new Maand(8, 17.0, 63),
              new Maand(9, 14.0, 59),
              new Maand(10, 10.4, 71),
              new Maand(11, 6.0, 78),
              new Maand(12, 3.4, 76)
            };

            maand2 = new List<Maand>()
            {
              new Maand(1, 27.1, 9),
              new Maand(2,28.2, 23),
              new Maand(3, 28.5, 53),
              new Maand(4, 28.2, 96),
              new Maand(5, 27.4, 153),
              new Maand(6, 26.2, 252),
              new Maand(7, 25.3, 91),
              new Maand(8, 25.2, 33),
              new Maand(9, 25.8, 65),
              new Maand(10, 26.6, 75),
              new Maand(11, 27.3, 20),
              new Maand(12, 27.1, 8)
            };

                Maand3 = new List<Maand>()
            {
                new Maand(1, 21.1, 0),
                new Maand(2,21.1, 0),
                new Maand(3, 20.1, 0),
                new Maand(4, 18.3, 0),
                new Maand(5, 16.9, 0),
                new Maand(6, 15.9, 0),
                new Maand(7, 15.2, 0),
                new Maand(8, 15.3, 0),
                new Maand(9, 15.9, 0),
                new Maand(10, 16.9, 0),
                new Maand(11, 18.4, 0),
                new Maand(12, 20.0, 0)
            };
            IquiqueK = new Klimatogram(Maand3, 1961, 1990);
            Iquique = new Locatie("Iquique", -70.11, -20.32, 85418, IquiqueK);
            IquiqueK.Locatie = Iquique;
            ZuidAmerika.AddLand(Chili);
            Chili.AddLocatie(Iquique);

            ukkelK = new Klimatogram(maand, 1961, 1990) { KlimatogramId = 0 };
            Lomek = new Klimatogram(maand2, 1961, 1990) { KlimatogramId = 1 };

            Lome = new Locatie("Lome", 50.5310, 3, 1414, Lomek);
            Lome.Land = Togo;
            Ukkel = new Locatie("Ukkel", 4.3333, 50.8000, 6447, ukkelK);
            Ukkel.Land = België;

            ukkelK.Locatie = Ukkel;
            Lomek.Locatie = Lome;


            Togo.AddLocatie(Lome);
            België.AddLocatie(Ukkel);

            Afrika.AddLand(Togo);
            Europa.AddLand(België);
            Europa.AddLand(Frankrijk);

            #region CONSTRUCTOR DETERMINATIETABEL TWEEDE EN DERDE GRAAD
            //Alle parameters
            Parameter warmsteMaand = new WarmsteMaand() { ParameterId = 0 };
            Parameter tempWarmsteMaand = new TempWarmsteMaand() { ParameterId = 1 };
            Parameter gemTempJaar = new GemTempJaar() { ParameterId = 2 };
            Parameter totNeerslagJaar = new TotNeerslagJaar() { ParameterId = 3 };
            Parameter koudsteMaand = new KoudsteMaand() { ParameterId = 4 };
            Parameter tempKoudsteMaand = new TempKoudsteMaand() { ParameterId = 5 };
            Parameter aantalDroog = new AantalDroog() { ParameterId = 6 };
            Parameter neerslagZomer = new NeerslagZomer() { ParameterId = 7 };
            Parameter neerslagWinter = new NeerslagWinter() { ParameterId = 8 };
            Parameter aantalGroterdan10 = new AantalGroterDan10() { ParameterId = 9 };

            //Alle componenten
            Component firstNode = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThanOrEqual, 10) };
            Component component1 = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThanOrEqual, 0) };
            Component component2 = new Component() { Vraag = new Vraag(gemTempJaar, VraagOperator.LessThanOrEqual, 0) };
            Component component3 = new Component() { Vraag = new Vraag(totNeerslagJaar, VraagOperator.LessThanOrEqual, 200) };
            Component component4 = new Component() { Vraag = new Vraag(tempKoudsteMaand, VraagOperator.LessThanOrEqual, 15) };
            Component component5 = new Component() { Vraag = new Vraag(tempKoudsteMaand, VraagOperator.LessThanOrEqual, 18) };
            Component component6 = new Component() { Vraag = new Vraag(totNeerslagJaar, VraagOperator.LessThanOrEqual, 400) };
            Component component7 = new Component() { Vraag = new Vraag(tempKoudsteMaand, VraagOperator.LessThanOrEqual, -10) };
            Component component8 = new Component() { Vraag = new Vraag(aantalDroog, VraagOperator.LessThanOrEqual, 1) };
            Component component9 = new Component() { Vraag = new Vraag(tempKoudsteMaand, VraagOperator.LessThanOrEqual, -3) };
            Component component10 = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThanOrEqual, 22) };
            Component component11 = new Component() { Vraag = new Vraag(neerslagZomer, VraagOperator.LessThanOrEqual, neerslagWinter) };
            Component component12 = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThanOrEqual, 22) };
            Component component13 = new Component() { Vraag = new Vraag(aantalDroog, VraagOperator.LessThanOrEqual, 1) };

            //Alle leafnodes
            Leaf leaf1 = new Leaf("Koud klimaat zonder dooiseizoen", "ijswoestijn");
            Leaf leaf2 = new Leaf("Koud klimaat met dooiseizoen", "Toendra");
            Leaf leaf3 = new Leaf("Koudgematigd klimaat met strenge winter", "Taiga");
            Leaf leaf4 = new Leaf("Gematigd altijd droog klimaat", "Woestijn van de middelbreedten");
            Leaf leaf5 = new Leaf("Warm altijd droog klimaat", "Woestijn van de tropen");
            Leaf leaf6 = new Leaf("Gematigd, droog kimaat", "Steppe");
            Leaf leaf7 = new Leaf("Koudgematid klimaat met strenge winter", "Taiga");
            Leaf leaf8 = new Leaf("Koelgematigd klimaat met koude winter", "Gemengd woud");
            Leaf leaf9 = new Leaf("Koelgematigd klimaat met zachte winter", "Loofbos");
            Leaf leaf10 = new Leaf("Warmgematigd altijd nat klimaat", "Subtropisch regenwoud");
            Leaf leaf11 = new Leaf("Koelgematigd klimaat met natte winter", "Hardbladige vegetatie van de centrale middelbreedten");
            Leaf leaf12 = new Leaf("Warmgematigd klimaat met natte winter", "Hardbladige vegetatie van de subtropen");
            Leaf leaf13 = new Leaf("Warmgematigd klimaat met natte zomer", "Subtropische savanne");
            Leaf leaf14 = new Leaf("Warm klimaat met nat seizoen", "Tropische savanne");
            Leaf leaf15 = new Leaf("Warm altijd nat klimaat", "Tropisch regenwoud");


            //Nodes aan elkaar hangen
            firstNode.YesComponent = component1;
            firstNode.NoComponent = component2;

            component1.YesComponent = leaf1;
            component1.NoComponent = leaf2;

            component2.YesComponent = leaf3;
            component2.NoComponent = component3;

            component3.YesComponent = component4;
            component3.NoComponent = component5;

            component4.YesComponent = leaf4;
            component4.NoComponent = leaf5;

            component5.YesComponent = component6;
            component5.NoComponent = component13;

            component6.YesComponent = leaf6;
            component6.NoComponent = component7;

            component7.YesComponent = leaf7;
            component7.NoComponent = component8;

            component8.YesComponent = component9;
            component8.NoComponent = component11;

            component9.YesComponent = leaf8;
            component9.NoComponent = component10;

            component10.YesComponent = leaf9;
            component10.NoComponent = leaf10;

            component11.YesComponent = component12;
            component11.NoComponent = leaf13;

            component12.YesComponent = leaf11;
            component12.NoComponent = leaf12;

            component13.YesComponent = leaf15;
            component13.NoComponent = leaf14;

            DeterminatieTabel = new DeterminatieTabel(firstNode, "Determinatietabel", 2);

            #endregion
            #region CONSTRUCTOR DETERMINATIETABEL EERSTE GRAAD

            Component g1firstNode = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThan, 10) };
            Component g1Component1 = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThan, 0) };
            Component g1Component2 = new Component() { Vraag = new Vraag(aantalGroterdan10, VraagOperator.LessThan, 4) };
            Component g1Component3 = new Component() { Vraag = new Vraag(tempKoudsteMaand, VraagOperator.LessThan, 18) };
            Component g1Component4 = new Component() { Vraag = new Vraag(totNeerslagJaar, VraagOperator.GreaterThan, 400) };
            Component g1Component5 = new Component() { Vraag = new Vraag(tempKoudsteMaand, VraagOperator.LessThan, -3) };
            Component g1Component6 = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThan, 22) };

            Leaf g1Leaf1 = new Leaf() { Klimaat = "Koud zonder dooiseizoen", Vegetatie = "Koud" };
            Leaf g1Leaf2 = new Leaf() { Klimaat = "Koud met dooiseizoen", Vegetatie = "Koud" };
            Leaf g1Leaf3 = new Leaf() { Klimaat = "Koud gematigd", Vegetatie = "Gematigd" };
            Leaf g1Leaf4 = new Leaf() { Klimaat = "Koel gematigd met strenge winter", Vegetatie = "Gematigd" };
            Leaf g1Leaf5 = new Leaf() { Klimaat = "Koel gematigd met zachte winter", Vegetatie = "Gematigd" };
            Leaf g1Leaf6 = new Leaf() { Klimaat = "Warm gematigd met natte winter", Vegetatie = "Gematigd" };
            Leaf g1Leaf7 = new Leaf() { Klimaat = "Gematigd en droog", Vegetatie = "Droog" };
            Leaf g1Leaf8 = new Leaf() { Klimaat = "Warm", Vegetatie = "Warm" };

            g1firstNode.YesComponent = g1Component1;
            g1firstNode.NoComponent = g1Component2;

            g1Component1.YesComponent = g1Leaf1;
            g1Component1.NoComponent = g1Leaf2;

            g1Component2.YesComponent = g1Leaf3;
            g1Component2.NoComponent = g1Component3;

            g1Component3.YesComponent = g1Component4;
            g1Component3.NoComponent = g1Leaf8;

            g1Component4.YesComponent = g1Component5;
            g1Component4.NoComponent = g1Leaf7;

            g1Component5.YesComponent = g1Leaf4;
            g1Component5.NoComponent = g1Component6;

            g1Component6.YesComponent = g1Leaf5;
            g1Component6.NoComponent = g1Leaf6;

            DeterminatieTabelGraad1 = new DeterminatieTabel(g1firstNode, "Determinatietabel 1", 1);


            #endregion

            Graad1 = new Graad(1);
            Graad1.DeterminatieTabel = DeterminatieTabelGraad1;//G1

            Graad2 = new Graad(2);
            Graad2.DeterminatieTabel = DeterminatieTabel;

            Graad3 = new Graad(3);
            Graad3.DeterminatieTabel = DeterminatieTabel;

            VragenLijst vragen = new VragenLijst(
                  new List<Parameter>()
                {
                    warmsteMaand,
                    tempWarmsteMaand,
                    koudsteMaand
                }
            );

            Graad1.VragenLijst = vragen;

            Continenten = new List<Continent>() { Afrika, Europa, ZuidAmerika }.AsQueryable();
            Landen = new List<Land>() { Togo, België, Frankrijk, Chili }.AsQueryable();
            Klimatogrammen = new List<Klimatogram>() { Lomek, ukkelK, IquiqueK }.AsQueryable();
            Locatie = new List<Locatie>() { Lome, Ukkel, Iquique }.AsQueryable();
            List<Maand> alleMaanden = new List<Maand>(maand);
            alleMaanden.AddRange(maand2);
            alleMaanden.AddRange(Maand3);
            Maanden = alleMaanden.AsQueryable();
            DeterminatieTabellen = new List<DeterminatieTabel>() { DeterminatieTabel, DeterminatieTabelGraad1 }.AsQueryable();
            DeterminatieComponenten = new List<DeterminatieComponent>(){firstNode, component1, component2, component3, component4, component5, component6, component7, component8, component9, 
                                                                        leaf1, leaf2, leaf3, leaf4, leaf5, leaf6, leaf7, leaf7, leaf8, leaf9, leaf10, leaf11, leaf12, leaf13, leaf14, leaf15}.AsQueryable();
            VragenLijsten = new List<VragenLijst>() { vragen }.AsQueryable();
            Graden = new List<Graad>() { Graad1, Graad2, Graad3 }.AsQueryable();
        }
    }
}
