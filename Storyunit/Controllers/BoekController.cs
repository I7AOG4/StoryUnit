using Storyunit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storyunit.Controllers
{
    public class BoekController : Controller
    {
		private dbStoryunitEntities db = new dbStoryunitEntities();

		// GET: Boek
		public ActionResult Index()
        {
			var data = db.spAllboeken();
            return View(data.ToList());
        }
    }
}