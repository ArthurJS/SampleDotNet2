using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groep8DotNetProjectenII.Models.Domain
{
    public interface ILandRepository
    {
        IQueryable<Land> FindAll();
        Land FindById(int id);
        void SaveChanges();
    }
}
