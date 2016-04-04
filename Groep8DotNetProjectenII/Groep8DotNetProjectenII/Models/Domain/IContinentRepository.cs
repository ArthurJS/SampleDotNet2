using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public interface IContinentRepository
    {
        IQueryable<Continent> FindAll();
        Continent FindById(int id);
        void SaveChanges();
        IQueryable<Continent> PerJaar(Leerjaar leerjaar);
    }
}
