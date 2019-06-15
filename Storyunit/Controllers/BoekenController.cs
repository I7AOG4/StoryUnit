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
    public class BoekenController : Controller
    {
        private dbStoryunitEntities db = new dbStoryunitEntities();

        // GET: Boeken
        public ActionResult Index()
        {
            var boek = db.Boek.Include(b => b.Auteur).Include(b => b.Boek1).Include(b => b.Boek2).Include(b => b.Taal).Include(b => b.Uitgever);
            return View(boek.ToList());
        }

        // GET: Boeken/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boek boek = db.Boek.Find(id);
            if (boek == null)
            {
                return HttpNotFound();
            }
            return View(boek);
        }

        // GET: Boeken/Create
        public ActionResult Create()
        {
            ViewBag.AuteurID = new SelectList(db.Auteur, "AuteurID", "AuteurVoornaam");
            ViewBag.BoekID = new SelectList(db.Boek, "BoekID", "Titel");
            ViewBag.BoekID = new SelectList(db.Boek, "BoekID", "Titel");
            ViewBag.TaalID = new SelectList(db.Taal, "TaalID", "Taal1");
            ViewBag.UitgeverID = new SelectList(db.Uitgever, "UitgeverID", "UitgeverNaam");
            return View();
        }

        // POST: Boeken/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoekID,AuteurID,UitgeverID,TaalID,Titel,Afmeting,Gewicht,Druk,ISBN,Fotolink")] Boek boek)
        {
            if (ModelState.IsValid)
            {
                db.Boek.Add(boek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuteurID = new SelectList(db.Auteur, "AuteurID", "AuteurVoornaam", boek.AuteurID);
            ViewBag.BoekID = new SelectList(db.Boek, "BoekID", "Titel", boek.BoekID);
            ViewBag.BoekID = new SelectList(db.Boek, "BoekID", "Titel", boek.BoekID);
            ViewBag.TaalID = new SelectList(db.Taal, "TaalID", "Taal1", boek.TaalID);
            ViewBag.UitgeverID = new SelectList(db.Uitgever, "UitgeverID", "UitgeverNaam", boek.UitgeverID);
            return View(boek);
        }

        // GET: Boeken/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boek boek = db.Boek.Find(id);
            if (boek == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuteurID = new SelectList(db.Auteur, "AuteurID", "AuteurVoornaam", boek.AuteurID);
            ViewBag.BoekID = new SelectList(db.Boek, "BoekID", "Titel", boek.BoekID);
            ViewBag.BoekID = new SelectList(db.Boek, "BoekID", "Titel", boek.BoekID);
            ViewBag.TaalID = new SelectList(db.Taal, "TaalID", "Taal1", boek.TaalID);
            ViewBag.UitgeverID = new SelectList(db.Uitgever, "UitgeverID", "UitgeverNaam", boek.UitgeverID);
            return View(boek);
        }

        // POST: Boeken/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoekID,AuteurID,UitgeverID,TaalID,Titel,Afmeting,Gewicht,Druk,ISBN,Fotolink")] Boek boek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuteurID = new SelectList(db.Auteur, "AuteurID", "AuteurVoornaam", boek.AuteurID);
            ViewBag.BoekID = new SelectList(db.Boek, "BoekID", "Titel", boek.BoekID);
            ViewBag.BoekID = new SelectList(db.Boek, "BoekID", "Titel", boek.BoekID);
            ViewBag.TaalID = new SelectList(db.Taal, "TaalID", "Taal1", boek.TaalID);
            ViewBag.UitgeverID = new SelectList(db.Uitgever, "UitgeverID", "UitgeverNaam", boek.UitgeverID);
            return View(boek);
        }

        // GET: Boeken/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boek boek = db.Boek.Find(id);
            if (boek == null)
            {
                return HttpNotFound();
            }
            return View(boek);
        }

        // POST: Boeken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boek boek = db.Boek.Find(id);
            db.Boek.Remove(boek);
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
