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
    public class GradenRepository : IGradenRepository
    {

        private KlimatogramContext context;
        private DbSet<Graad> graden;

        public GradenRepository(KlimatogramContext context)
        {
            context = context;
            graden = context.Graden;
        }
        public Graad FindByGraadNummer(int graad)
        {
            return graden.FirstOrDefault(g => g.GraadNummer == graad);
        }

        public IQueryable<Graad> FindAll()
        {
            return graden;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}