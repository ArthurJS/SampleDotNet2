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
    public class GraadMapper : EntityTypeConfiguration<Graad>
    {
        public GraadMapper()
        {
            HasKey(g => g.GraadNummer);
            Property(g => g.GraadNummer).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}