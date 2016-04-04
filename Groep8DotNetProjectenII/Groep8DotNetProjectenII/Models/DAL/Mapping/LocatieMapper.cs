using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Models.DAL.Mapping
{
    [ExcludeFromCodeCoverage]
    public class LocatieMapper:EntityTypeConfiguration<Locatie>
    {
        public LocatieMapper()
        {
            HasKey(l => l.WeerstationNummer);
            this.Property(l => l.WeerstationNummer).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            HasRequired(l => l.Klimatogram).WithRequiredDependent(k => k.Locatie).Map(k => k.MapKey("KlimatogramId"));
            HasOptional(l => l.Land).WithMany(m => m.Locaties).Map(map => map.MapKey("LandId"));
        }
    }
}