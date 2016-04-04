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
    public class DeterminatieTabelRepository : IDeterminatieTabelRepository
    {
        private KlimatogramContext context;
        private DbSet<DeterminatieTabel> determinatieTabellen;

        public DeterminatieTabelRepository(KlimatogramContext context)
        {
            this.context = context;
            determinatieTabellen = context.DeterminatieTabelen;
        }

        public IQueryable<DeterminatieTabel> FindAll()
        {
            return determinatieTabellen;
        }

        public DeterminatieTabel FindById(int id)
        {
            return determinatieTabellen.FirstOrDefault( d => d.DeterminatieTabelId == id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}