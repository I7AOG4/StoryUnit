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
    public class UitgeversController : Controller
    {
        private dbStoryunitEntities db = new dbStoryunitEntities();

        // GET: Uitgevers
        public ActionResult Index()
        {
            return View(db.Uitgever.ToList());
        }

        // GET: Uitgevers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uitgever uitgever = db.Uitgever.Find(id);
            if (uitgever == null)
            {
                return HttpNotFound();
            }
            return View(uitgever);
        }

        // GET: Uitgevers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uitgevers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UitgeverID,UitgeverNaam")] Uitgever uitgever)
        {
            if (ModelState.IsValid)
            {
                db.Uitgever.Add(uitgever);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uitgever);
        }

        // GET: Uitgevers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uitgever uitgever = db.Uitgever.Find(id);
            if (uitgever == null)
            {
                return HttpNotFound();
            }
            return View(uitgever);
        }

        // POST: Uitgevers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UitgeverID,UitgeverNaam")] Uitgever uitgever)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uitgever).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uitgever);
        }

        // GET: Uitgevers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uitgever uitgever = db.Uitgever.Find(id);
            if (uitgever == null)
            {
                return HttpNotFound();
            }
            return View(uitgever);
        }

        // POST: Uitgevers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uitgever uitgever = db.Uitgever.Find(id);
            db.Uitgever.Remove(uitgever);
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
