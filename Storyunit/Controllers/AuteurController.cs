using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storyunit.Controllers
{
    public class AuteurController : Controller
    {
        // GET: Auteur
        public ActionResult Index(string auteur)
        {
            var data = Models.spAllboekenAuteur_Result(auteur);
            return View(data.Tolist());
        }
    }
}