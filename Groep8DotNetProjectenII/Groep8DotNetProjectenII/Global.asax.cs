using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Groep8DotNetProjectenII.Infrastructure;
using Groep8DotNetProjectenII.Models.DAL;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII
{
    [ExcludeFromCodeCoverage]
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(Leerjaar), new LeerjaarModelBinder());
            new KlimatogramContext().Database.Initialize(true);
        }
    }
}
