using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Storyunit.Models;

namespace Storyunit.Controllers
{
    public class AuteursController : Controller
    {
        private dbStoryunitEntities db = new dbStoryunitEntities();

        // GET: Auteurs
        public ActionResult Index()
        {
            return View(db.Auteur.ToList());
        }

        // GET: Auteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // GET: Auteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuteurID,AuteurVoornaam,AuteurAchternaam")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.Auteur.Add(auteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auteur);
        }

        // GET: Auteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuteurID,AuteurVoornaam,AuteurAchternaam")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auteur);
        }

        // GET: Auteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auteur auteur = db.Auteur.Find(id);
            db.Auteur.Remove(auteur);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
