﻿using Storyunit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Storyunit.Controllers
{
    public class AuteurController : Controller
    {
        private dbStoryunitEntities db = new dbStoryunitEntities();

        // GET: Auteur
        public ActionResult Index(string auteur)
        {
            var data = db.spAllboekenAuteur(auteur);
            return View(data.ToList());
        }
    }
}