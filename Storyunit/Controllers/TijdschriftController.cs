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
        public ActionResult Index(String value)
        {
            if (value != null)
            {

                var tijdschriften = db.Tijdschrift.Include(b => b.Auteur).Include(b => b.Taal).Include(b => b.Uitgever).Where(a => a.Taal.Taal1 == value);
                return View(tijdschriften.ToList());
            }
            else
            {
                var tijdschrift = db.Tijdschrift.Include(b => b.Auteur).Include(b => b.Taal).Include(b => b.Uitgever).Where(a => a.Taal.Taal1 == value);
                return View(tijdschrift.ToList());
                /*
                var boek = db.Boek.Include(b => b.Auteur).Include(b => b.Taal).Include(b => b.Uitgever);
                return View(boek.ToList());
                */
            }
        }
    }
}