using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventCalendar.Models;

namespace EventCalendar.Controllers
{
    public class VrstaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vrsta
        public ActionResult Index()
        {
            return View(db.Vrste.ToList());
        }

        // GET: Vrsta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vrsta vrsta = db.Vrste.Find(id);
            if (vrsta == null)
            {
                return HttpNotFound();
            }
            return View(vrsta);
        }

        // GET: Vrsta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vrsta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv")] Vrsta vrsta)
        {
            if (ModelState.IsValid)
            {
                db.Vrste.Add(vrsta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vrsta);
        }

        // GET: Vrsta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vrsta vrsta = db.Vrste.Find(id);
            if (vrsta == null)
            {
                return HttpNotFound();
            }
            return View(vrsta);
        }

        // POST: Vrsta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv")] Vrsta vrsta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vrsta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vrsta);
        }

        // GET: Vrsta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vrsta vrsta = db.Vrste.Find(id);
            if (vrsta == null)
            {
                return HttpNotFound();
            }
            return View(vrsta);
        }

        // POST: Vrsta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vrsta vrsta = db.Vrste.Find(id);
            db.Vrste.Remove(vrsta);
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
