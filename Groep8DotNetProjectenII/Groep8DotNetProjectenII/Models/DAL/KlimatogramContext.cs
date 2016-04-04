using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Web;
using DeterminerenTest.Models.Domein;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Models.DAL
{
    [ExcludeFromCodeCoverage]
    public class KlimatogramContext:DbContext
    {
        public DbSet<Continent> Continenten { get; set; }
        public DbSet<Land> Landen { get; set; }
        public DbSet<Klimatogram> Klimatogrammen { get; set; }
        public DbSet<Locatie> Locatie { get; set; }
        public DbSet<Maand> Maanden { get; set; }
        public DbSet<DeterminatieTabel> DeterminatieTabelen { get; set; }
        public DbSet<DeterminatieComponent> DeterminatieComponenten { get; set; }
        public DbSet<Vraag> Vragen { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Graad> Graden { get; set; }
        public DbSet<VragenLijst> VragenLijsten { get; set; }

        public KlimatogramContext() : base("Klimatogram")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}