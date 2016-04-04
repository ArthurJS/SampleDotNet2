using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Groep8DotNetProjectenII.Models.Domain;

namespace Groep8DotNetProjectenII.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class LeerjaarModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            if (controllerContext.HttpContext.Session[LeerjaarMethods.SESSIONNAAM] == null)
            {
                bindingContext.ModelState.AddModelError("","Gelieve eerst uw leerjaar te selecteren");
                return Leerjaar.Eerste;
            }
                
            else
            {
                return (Leerjaar)controllerContext.HttpContext.Session[LeerjaarMethods.SESSIONNAAM];
            }


        }
    }
}