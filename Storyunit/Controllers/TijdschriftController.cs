using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Storyunit.Models;

namespace Storyunit.Controllers
{
    public class TijdschriftController : Controller
	{
		private dbStoryunitEntities db = new dbStoryunitEntities();

		// GET: Tijdschrift
		public ActionResult Index()
        {
			var tijdschrift = db.Tijdschrift.Include(t => t.Auteur).Include(t => t.Taal).Include(t => t.Uitgever);
			return View(tijdschrift.ToList());
		}
    }
}