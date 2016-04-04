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
    public class LandRepository : ILandRepository
    {
        private KlimatogramContext context;
        private DbSet<Land> landen;

        public LandRepository(KlimatogramContext context)
        {
            this.context = context;
            this.landen = context.Landen;
        }

        public IQueryable<Land> FindAll()
        {
            return landen.OrderBy(l=>l.Naam);
        }

        public Land FindById(int id)
        {
            return landen.Include(l => l.Locaties).SingleOrDefault(s => s.LandId == id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}