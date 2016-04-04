using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using DeterminerenTest.Models.Domein;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Models.DAL
{
    [ExcludeFromCodeCoverage]
    public class KlimatogramInitializer : DropCreateDatabaseAlways<KlimatogramContext>
    {
        protected override void Seed(KlimatogramContext context)
        {
            Continent europa = new Continent("Europa");
            Land land = new Land("België");
            ICollection<Maand> maanden = new List<Maand>()
            {
              new Maand((int)Maanden.Januari, 2.5, 67),
              new Maand((int)Maanden.Februari,3.2,54),
              new Maand((int)Maanden.Maart, 5.7, 73),
              new Maand((int)Maanden.April, 8.7, 57),
              new Maand((int)Maanden.Mei, 12.2, 70),
              new Maand((int)Maanden.Juni, 15.5, 78),
              new Maand((int)Maanden.Juli, 17.2, 75),
              new Maand((int)Maanden.Augustus, 17.0, 63),
              new Maand((int)Maanden.September, 14.0, 59),
              new Maand((int)Maanden.Oktober, 10.4, 71),
              new Maand((int)Maanden.November, 6.0, 78),
              new Maand((int)Maanden.December, 3.4, 76)
            };
            Klimatogram ukkelKlimatogram = new Klimatogram(maanden, 1960, 1991);
            Locatie ukkel = new Locatie("Ukkel", 4.21, 50.48, 6447, ukkelKlimatogram);
            ukkelKlimatogram.Locatie = ukkel;
            europa.AddLand(land);
            land.AddLocatie(ukkel);

            context.Continenten.Add(europa);
            context.Landen.Add(land);
            context.Klimatogrammen.Add(ukkelKlimatogram);
            context.Locatie.Add(ukkel);
            context.Maanden.AddRange(maanden);

            Continent noordCentraalamerika = new Continent("Noord en Centraal-Amerika");

            Land VerenigdeStaten = new Land("Verenigde Staten");
            ICollection<Maand> maandenMiami = new List<Maand>()
            {
              new Maand((int)Maanden.Januari, 19.6, 51),
              new Maand((int)Maanden.Februari,20.3,53),
              new Maand((int)Maanden.Maart, 22.1, 61),
              new Maand((int)Maanden.April, 24.0, 72),
              new Maand((int)Maanden.Mei, 25.9, 158),
              new Maand((int)Maanden.Juni, 27.4, 237),
              new Maand((int)Maanden.Juli, 28.1, 145),
              new Maand((int)Maanden.Augustus, 28.2, 193),
              new Maand((int)Maanden.September, 27.7, 194),
              new Maand((int)Maanden.Oktober, 25.7, 143),
              new Maand((int)Maanden.November, 23.1, 68),
              new Maand((int)Maanden.December, 20.6, 47)
            };
            Klimatogram miamiKlimatogram = new Klimatogram(maandenMiami, 1961, 1990);
            Locatie miami = new Locatie("Miami", 80.18, 25.48, 72202, miamiKlimatogram);
            miamiKlimatogram.Locatie = miami;
            noordCentraalamerika.AddLand(VerenigdeStaten);
            VerenigdeStaten.AddLocatie(miami);


            Land Canada = new Land("Canada");
            ICollection<Maand> maandenAlert = new List<Maand>()
            {
              new Maand((int)Maanden.Januari, -32.2, 8),
              new Maand((int)Maanden.Februari,-33.5,5),
              new Maand((int)Maanden.Maart, -33.2, 7),
              new Maand((int)Maanden.April, -25.4, 9),
              new Maand((int)Maanden.Mei, -11.8, 10),
              new Maand((int)Maanden.Juni, -1.2, 13),
              new Maand((int)Maanden.Juli, 3.2, 25),
              new Maand((int)Maanden.Augustus, 1.0, 24),
              new Maand((int)Maanden.September, -9.5, 24),
              new Maand((int)Maanden.Oktober, -19.0, 13),
              new Maand((int)Maanden.November, -26.6, 9),
              new Maand((int)Maanden.December, -29.5, 7)
            };
            Klimatogram alertKlimatogram = new Klimatogram(maandenAlert, 1954, 1991);
            Locatie alert = new Locatie("Alert", 62.20, 82.30, 71082, alertKlimatogram);
            alertKlimatogram.Locatie = alert;
            noordCentraalamerika.AddLand(Canada);
            Canada.AddLocatie(alert);

            Land Mexico = new Land("Mexico");
            noordCentraalamerika.AddLand(Mexico);

            Continent Afrika = new Continent("Afrika");
            Land Togo = new Land("Togo");
            ICollection<Maand> maandenTogo = new List<Maand>()
            {
              new Maand((int)Maanden.Januari, 27.1, 9),
              new Maand((int)Maanden.Februari,28.2, 23),
              new Maand((int)Maanden.Maart, 28.5, 53),
              new Maand((int)Maanden.April, 28.2, 96),
              new Maand((int)Maanden.Mei, 27.4, 153),
              new Maand((int)Maanden.Juni, 26.2, 252),
              new Maand((int)Maanden.Juli, 25.3, 91),
              new Maand((int)Maanden.Augustus, 25.2, 33),
              new Maand((int)Maanden.September, 25.8, 65),
              new Maand((int)Maanden.Oktober, 26.6, 75),
              new Maand((int)Maanden.November, 27.3, 20),
              new Maand((int)Maanden.December, 27.1, 8)
            };
            Klimatogram togoKlimatogram = new Klimatogram(maandenTogo, 1961, 1990);
            Locatie lome = new Locatie("Lome", 1.15, 6.10, 65387, togoKlimatogram);
            togoKlimatogram.Locatie = lome;
            Afrika.AddLand(Togo);
            Togo.AddLocatie(lome);

            Continent azie = new Continent("Azië");
            Land afghanistan = new Land("Afghanistan");
            ICollection<Maand> maandenJalalabad = new List<Maand>()
            {
              new Maand((int)Maanden.Januari, 8.5, 18),
              new Maand((int)Maanden.Februari,10.9, 24),
              new Maand((int)Maanden.Maart, 16.3, 39),
              new Maand((int)Maanden.April, 21.9, 36),
              new Maand((int)Maanden.Mei, 27.7, 16),
              new Maand((int)Maanden.Juni, 32.7, 1),
              new Maand((int)Maanden.Juli, 32.8, 7),
              new Maand((int)Maanden.Augustus, 31.9, 8),
              new Maand((int)Maanden.September, 28.1, 8),
              new Maand((int)Maanden.Oktober, 22.2, 3),
              new Maand((int)Maanden.November, 14.9, 8),
              new Maand((int)Maanden.December, 9.5, 12)
            };
            Klimatogram afghanistanKlimatogram = new Klimatogram(maandenJalalabad, 1959, 1983);
            Locatie jalalabad = new Locatie("Jalalabad", 70.28, 34.26, 40954, afghanistanKlimatogram);
            afghanistanKlimatogram.Locatie = jalalabad;
            azie.AddLand(afghanistan);
            afghanistan.AddLocatie(jalalabad);

            Continent Oceanie = new Continent("Oceanië");
            Land australie = new Land("Australië");
            ICollection<Maand> maandenSydney = new List<Maand>()
            {
              new Maand((int)Maanden.Januari, 22.5, 116),
              new Maand((int)Maanden.Februari,22.6, 113),
              new Maand((int)Maanden.Maart, 21.2, 148),
              new Maand((int)Maanden.April, 18.5, 121),
              new Maand((int)Maanden.Mei, 15.3, 88),
              new Maand((int)Maanden.Juni, 12.7, 128),
              new Maand((int)Maanden.Juli, 11.7, 54),
              new Maand((int)Maanden.Augustus, 12.9, 90),
              new Maand((int)Maanden.September, 15.2, 60),
              new Maand((int)Maanden.Oktober, 17.7, 79),
              new Maand((int)Maanden.November, 19.6, 101),
              new Maand((int)Maanden.December, 21.7, 81)
            };
            Klimatogram australieKlimatogram = new Klimatogram(maandenSydney, 1959, 1983);
            Locatie sydney = new Locatie("Sydney", 151.10, 33.56, 94767, australieKlimatogram);
            australieKlimatogram.Locatie = sydney;
            Oceanie.AddLand(australie);
            australie.AddLocatie(sydney);

            Continent zuidAmerika = new Continent("Zuid Amerika");
            Land chili = new Land("Chili");
            ICollection<Maand> maandenIquique = new List<Maand>()
            {
              new Maand((int)Maanden.Januari, 21.1, 0),
              new Maand((int)Maanden.Februari,21.1, 0),
              new Maand((int)Maanden.Maart, 20.1, 0),
              new Maand((int)Maanden.April, 18.3, 0),
              new Maand((int)Maanden.Mei, 16.9, 0),
              new Maand((int)Maanden.Juni, 15.9, 0),
              new Maand((int)Maanden.Juli, 15.2, 0),
              new Maand((int)Maanden.Augustus, 15.3, 0),
              new Maand((int)Maanden.September, 15.9, 0),
              new Maand((int)Maanden.Oktober, 16.9, 0),
              new Maand((int)Maanden.November, 18.4, 0),
              new Maand((int)Maanden.December, 20.0, 0)
            };
            Klimatogram chiliKlimatogram = new Klimatogram(maandenIquique, 1961, 1990);
            Locatie iquique = new Locatie("Iquique", -70.11, -20.32, 85418, chiliKlimatogram);
            chiliKlimatogram.Locatie = iquique;
            zuidAmerika.AddLand(chili);
            chili.AddLocatie(iquique);


            #region CONSTRUCTOR DETERMINATIETABEL TWEEDE EN DERDE GRAAD
            //Alle parameters
            Parameter warmsteMaand = new WarmsteMaand();
            Parameter tempWarmsteMaand = new TempWarmsteMaand();
            Parameter gemTempJaar = new GemTempJaar();
            Parameter totNeerslagJaar = new TotNeerslagJaar();
            Parameter koudsteMaand = new KoudsteMaand();
            Parameter tempKoudsteMaand = new TempKoudsteMaand();
            Parameter aantalDroog = new AantalDroog();
            Parameter neerslagZomer = new NeerslagZomer();
            Parameter neerslagWinter = new NeerslagWinter();
            Parameter aantalGroterdan10 = new AantalGroterDan10();

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

            DeterminatieTabel determinatieTabel = new DeterminatieTabel(firstNode, "Determinatietabel", 2);

            #endregion

            #region CONSTRUCTOR DETERMINATIETABEL EERSTE GRAAD

            Component g1firstNode = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThan, 10) };
            Component g1Component1 = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThan, 0) };
            Component g1Component2 = new Component() { Vraag = new Vraag(aantalGroterdan10, VraagOperator.LessThan, 4) };
            Component g1Component3 = new Component() { Vraag = new Vraag(tempKoudsteMaand, VraagOperator.LessThan, 18) };
            Component g1Component4 = new Component() { Vraag = new Vraag(totNeerslagJaar, VraagOperator.GreaterThan, 400) };
            Component g1Component5 = new Component() { Vraag = new Vraag(tempKoudsteMaand, VraagOperator.LessThan, -3) };
            Component g1Component6 = new Component() { Vraag = new Vraag(tempWarmsteMaand, VraagOperator.LessThan, 22) };

            Leaf g1Leaf1 = new Leaf() { Klimaat = "Koud zonder dooiseizoen", Vegetatie = "ijswoestijn" };
            Leaf g1Leaf2 = new Leaf() { Klimaat = "Koud met dooiseizoen", Vegetatie = "toendra" };
            Leaf g1Leaf3 = new Leaf() { Klimaat = "Koud gematigd", Vegetatie = "taiga" };
            Leaf g1Leaf4 = new Leaf() { Klimaat = "Koel gematigd met strenge winter", Vegetatie = "gemengd woud" };
            Leaf g1Leaf5 = new Leaf() { Klimaat = "Koel gematigd met zachte winter", Vegetatie = "loofbos" };
            Leaf g1Leaf6 = new Leaf() { Klimaat = "Warm gematigd met natte winter", Vegetatie = "hardbladige vegetatie van de subtropen" };
            Leaf g1Leaf7 = new Leaf() { Klimaat = "Gematigd en droog", Vegetatie = "woestijn van de middelbreedten" };
            Leaf g1Leaf8 = new Leaf() { Klimaat = "Warm", Vegetatie = "woestijn van de tropen" };
           

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

            DeterminatieTabel determinatieTabelG1 = new DeterminatieTabel(g1firstNode, "Determinatietabel 1", 1);


            #endregion
            Graad graad1 = new Graad(1);
            graad1.DeterminatieTabel = determinatieTabelG1;

            Graad graad2 = new Graad(2);
            graad2.DeterminatieTabel = determinatieTabel;

            Graad graad3 = new Graad(3);
            graad3.DeterminatieTabel = determinatieTabel;


            VragenLijst vragen = new VragenLijst(
                  new List<Parameter>()
                {
                    warmsteMaand,
                    tempWarmsteMaand,
                    koudsteMaand,
                    tempKoudsteMaand,
                    aantalDroog,
                    neerslagZomer,
                    neerslagWinter
                }
            );

            graad1.VragenLijst = vragen;

            context.Continenten.Add(noordCentraalamerika);
            context.Continenten.Add(Afrika);
            context.Continenten.Add(Oceanie);
            context.Continenten.Add(zuidAmerika);
            context.Continenten.Add(azie);
            context.Landen.Add(Canada);
            context.Landen.Add(VerenigdeStaten);
            context.Landen.Add(Togo);
            context.Landen.Add(Mexico);
            context.Landen.Add(afghanistan);
            context.Landen.Add(australie);
            context.Landen.Add(chili);
            context.Klimatogrammen.Add(alertKlimatogram);
            context.Klimatogrammen.Add(miamiKlimatogram);
            context.Klimatogrammen.Add(togoKlimatogram);
            context.Klimatogrammen.Add(afghanistanKlimatogram);
            context.Klimatogrammen.Add(australieKlimatogram);
            context.Klimatogrammen.Add(chiliKlimatogram);
            context.Locatie.Add(alert);
            context.Locatie.Add(miami);
            context.Locatie.Add(lome);
            context.Locatie.Add(sydney);
            context.Locatie.Add(iquique);
            context.Locatie.Add(jalalabad);
            context.Maanden.AddRange(maandenAlert);
            context.Maanden.AddRange(maandenMiami);
            context.Maanden.AddRange(maandenTogo);
            context.Maanden.AddRange(maandenIquique);
            context.Maanden.AddRange(maandenSydney);
            context.Maanden.AddRange(maandenJalalabad);
            context.DeterminatieTabelen.Add(determinatieTabel);
            context.DeterminatieTabelen.Add(determinatieTabelG1);
            context.DeterminatieComponenten.AddRange(new List<DeterminatieComponent> {firstNode, component1, component2, component3, component4, component5, component6, component7, component8, component9, 
                                                                                      leaf1, leaf2, leaf3, leaf4, leaf5, leaf6, leaf7, leaf7, leaf8, leaf9, leaf10, leaf11, leaf12, leaf13, leaf14, leaf15});
            context.DeterminatieComponenten.AddRange(new List<DeterminatieComponent>
            {
                g1firstNode,
                g1Component1,
                g1Component2,
                g1Component3,
                g1Component4,
                g1Component5,
                g1Component6,
                g1Leaf1,
                g1Leaf2,
                g1Leaf3,
                g1Leaf4,
                g1Leaf5,
                g1Leaf6,
                g1Leaf7,
                g1Leaf8
            });

            context.VragenLijsten.Add(vragen);
            context.Graden.Add(graad1);
            context.Graden.Add(graad2);
            context.Graden.Add(graad3);
            context.DeterminatieTabelen.Add(determinatieTabel);
            context.SaveChanges();
        }

    }
}