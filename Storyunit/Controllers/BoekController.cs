using Storyunit.Models;
using System;
using System.Data;
using System.Data.Entity;
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
        public ActionResult Index(String value)
        {
            if (value != null)
            {

                var Taal = db.Boek.Include(b => b.Auteur).Include(b => b.Taal).Include(b => b.Uitgever).Where(a => a.Taal.Taal1 == value);
                return View(Taal.ToList());
            }
            else
            {

                var boek = db.Boek.Include(b => b.Auteur).Include(b => b.Taal).Include(b => b.Uitgever);
                return View(boek.ToList());
            }
        }
    }
}