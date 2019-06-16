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
    public class TijdschriftenController : Controller
    {
        private dbStoryunitEntities db = new dbStoryunitEntities();

        // GET: Tijdschriften
        public ActionResult Index()
        {
            var tijdschrift = db.Tijdschrift.Include(t => t.Auteur).Include(t => t.Taal).Include(t => t.Uitgever);
            return View(tijdschrift.ToList());
        }

        // GET: Tijdschriften/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tijdschrift tijdschrift = db.Tijdschrift.Find(id);
            if (tijdschrift == null)
            {
                return HttpNotFound();
            }
            return View(tijdschrift);
        }

        // GET: Tijdschriften/Create
        public ActionResult Create()
        {
            ViewBag.AuteurID = new SelectList(db.Auteur, "AuteurID", "AuteurVoornaam");
            ViewBag.TaalID = new SelectList(db.Taal, "TaalID", "Taal1");
            ViewBag.UitgeverID = new SelectList(db.Uitgever, "UitgeverID", "UitgeverNaam");
            return View();
        }

        // POST: Tijdschriften/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TijdschriftID,AuteurID,UitgeverID,TaalID,Titel,Uitgifte,Afmeting,ISSN,Fotolink")] Tijdschrift tijdschrift)
        {
            if (ModelState.IsValid)
            {
                db.Tijdschrift.Add(tijdschrift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuteurID = new SelectList(db.Auteur, "AuteurID", "AuteurVoornaam", tijdschrift.AuteurID);
            ViewBag.TaalID = new SelectList(db.Taal, "TaalID", "Taal1", tijdschrift.TaalID);
            ViewBag.UitgeverID = new SelectList(db.Uitgever, "UitgeverID", "UitgeverNaam", tijdschrift.UitgeverID);
            return View(tijdschrift);
        }

        // GET: Tijdschriften/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tijdschrift tijdschrift = db.Tijdschrift.Find(id);
            if (tijdschrift == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuteurID = new SelectList(db.Auteur, "AuteurID", "AuteurVoornaam", tijdschrift.AuteurID);
            ViewBag.TaalID = new SelectList(db.Taal, "TaalID", "Taal1", tijdschrift.TaalID);
            ViewBag.UitgeverID = new SelectList(db.Uitgever, "UitgeverID", "UitgeverNaam", tijdschrift.UitgeverID);
            return View(tijdschrift);
        }

        // POST: Tijdschriften/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TijdschriftID,AuteurID,UitgeverID,TaalID,Titel,Uitgifte,Afmeting,ISSN,Fotolink")] Tijdschrift tijdschrift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tijdschrift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuteurID = new SelectList(db.Auteur, "AuteurID", "AuteurVoornaam", tijdschrift.AuteurID);
            ViewBag.TaalID = new SelectList(db.Taal, "TaalID", "Taal1", tijdschrift.TaalID);
            ViewBag.UitgeverID = new SelectList(db.Uitgever, "UitgeverID", "UitgeverNaam", tijdschrift.UitgeverID);
            return View(tijdschrift);
        }

        // GET: Tijdschriften/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tijdschrift tijdschrift = db.Tijdschrift.Find(id);
            if (tijdschrift == null)
            {
                return HttpNotFound();
            }
            return View(tijdschrift);
        }

        // POST: Tijdschriften/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tijdschrift tijdschrift = db.Tijdschrift.Find(id);
            db.Tijdschrift.Remove(tijdschrift);
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
