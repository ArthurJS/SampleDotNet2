using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public interface ILocatieRepository
    {
        IQueryable<Locatie> FindAll();
        Locatie FindById(int weerstationNummer);
        void AddKlimatogram(Locatie locatie);
        void RemoveKlimatogram(int weerstationNummer);
        void SaveChanges();
    }
}
