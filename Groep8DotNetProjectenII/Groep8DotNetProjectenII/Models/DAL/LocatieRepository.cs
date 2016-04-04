using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Models.DAL
{
    [ExcludeFromCodeCoverage]
    public class LocatieRepository  : ILocatieRepository
    {
        private KlimatogramContext context;
        private DbSet<Locatie> locaties;

        public LocatieRepository(KlimatogramContext context)
        {
            this.context = context;
            this.locaties = context.Locatie;
        }

        public IQueryable<Locatie> FindAll()
        {
            return locaties;
        }

        public Locatie FindById(int weerstationNummer)
        {
            return locaties.Include(l => l.Klimatogram).Include(l=>l.Klimatogram.Maanden).Include(i=>i.Land).SingleOrDefault(s => s.WeerstationNummer == weerstationNummer);
        }

        public void AddKlimatogram(Locatie locatie)
        {
            locaties.Add(locatie);
        }

        public void RemoveKlimatogram(int weerstationNummer)
        {
            locaties.Remove(FindById(weerstationNummer));
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}