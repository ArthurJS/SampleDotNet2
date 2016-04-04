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
    public class KlimatogramRepository : IKlimatogramRepository
    {
        private KlimatogramContext context;
        private DbSet<Klimatogram> klimatogrammen;

        public KlimatogramRepository(KlimatogramContext context)
        {
            this.context = context;
            this.klimatogrammen = context.Klimatogrammen;
        }
        public IQueryable<Klimatogram> FindAll()
        {
            return klimatogrammen;
        }

        public Klimatogram FindById(int id)
        {
            return klimatogrammen.Include(k=>k.Maanden).SingleOrDefault(s=>s.KlimatogramId==id);
        }

        public void AddKlimatogram(Klimatogram klimatogram)
        {
            klimatogrammen.Add(klimatogram);
        }

        public void RemoveKlimatogram(int id)
        {
            klimatogrammen.Remove(FindById(id));
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}