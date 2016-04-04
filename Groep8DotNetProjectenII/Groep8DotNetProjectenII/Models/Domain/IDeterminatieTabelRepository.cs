using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Models.DAL
{
    public interface IDeterminatieTabelRepository
    {
        IQueryable<DeterminatieTabel> FindAll();
        DeterminatieTabel FindById(int id);
        void SaveChanges();
    }
}