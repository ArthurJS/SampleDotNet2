using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Models.DAL.Mapping
{
    [ExcludeFromCodeCoverage]
    public class KlimatogramMapper:EntityTypeConfiguration<Klimatogram>
    {
        public KlimatogramMapper()
        {
            HasKey(l => l.KlimatogramId);

            Ignore(k => k.SomJaarNeerslag);
            Ignore(k => k.GemmideldeJaarTemperatuur);

            HasMany(k => k.Maanden).WithRequired().Map(m => m.MapKey("KlimatogramId"));
           
        }
    }
}