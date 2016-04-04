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
    public class ContinentRepository : IContinentRepository
    {

        private KlimatogramContext context;
        private DbSet<Continent> continenten;

        public ContinentRepository(KlimatogramContext context)
        {
            this.context = context;
            this.continenten = context.Continenten;
        }

        public IQueryable<Continent> FindAll()
        {
            return continenten;
        }

        public Continent FindById(int id)
        {
            return continenten.Include(l=>l.Landen).SingleOrDefault(s=>s.ContinentId==id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public IQueryable<Continent> PerJaar(Leerjaar leerjaar)
        {
            return  leerjaar.LeerjaarNaarGraad() == 1
                    ? continenten.Where(c => c.Naam == "Europa").OrderBy(o=>o.Naam)
                    : continenten.OrderBy(o => o.Naam);
        }
    }
}