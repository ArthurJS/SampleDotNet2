using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public interface IKlimatogramRepository
    {
        IQueryable<Klimatogram> FindAll();
        Klimatogram FindById(int id);
        void AddKlimatogram(Klimatogram klimatogram);
        void RemoveKlimatogram(int id);
        void SaveChanges();
    }
}
