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
    public class ContinentMapper:EntityTypeConfiguration<Continent>
    {
        public ContinentMapper()
        {
            HasKey(c => c.ContinentId);
            HasMany(c => c.Landen).WithRequired().Map(m=>m.MapKey("ContinentId")).WillCascadeOnDelete(true);
        }
    }
}