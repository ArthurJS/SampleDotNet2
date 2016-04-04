using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public interface IGradenRepository
    {
        Graad FindByGraadNummer(int graad);
        IQueryable<Graad> FindAll();
        void SaveChanges();
    }
}