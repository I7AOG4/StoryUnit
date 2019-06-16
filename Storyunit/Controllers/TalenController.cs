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
    public class TalenController : Controller
    {
        private dbStoryunitEntities db = new dbStoryunitEntities();

        // GET: Talen
        public ActionResult Index()
        {
            return View(db.Taal.ToList());
        }

        // GET: Talen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taal taal = db.Taal.Find(id);
            if (taal == null)
            {
                return HttpNotFound();
            }
            return View(taal);
        }

        // GET: Talen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaalID,Taal1")] Taal taal)
        {
            if (ModelState.IsValid)
            {
                db.Taal.Add(taal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taal);
        }

        // GET: Talen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taal taal = db.Taal.Find(id);
            if (taal == null)
            {
                return HttpNotFound();
            }
            return View(taal);
        }

        // POST: Talen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaalID,Taal1")] Taal taal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taal);
        }

        // GET: Talen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taal taal = db.Taal.Find(id);
            if (taal == null)
            {
                return HttpNotFound();
            }
            return View(taal);
        }

        // POST: Talen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Taal taal = db.Taal.Find(id);
            db.Taal.Remove(taal);
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
