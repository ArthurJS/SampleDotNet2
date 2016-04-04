using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Groep8DotNetProjectenII.Models.Domain;
using Groep8DotNetProjectenII.ViewModels;

namespace Groep8DotNetProjectenII.Controllers
{
    public class OefeningenController : Controller
    {

        public ActionResult Index()
        {
            return View(new OefeningenIndexViewModel());
        
        }

        [HttpGet]
        public ActionResult Oefening(int leerjaar)
        {
            try
            {
                ((Leerjaar)leerjaar).Selecteer();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Oefeningen");
            }

            return RedirectToAction("Index", "Klimatogrammen");
        }

    }
}