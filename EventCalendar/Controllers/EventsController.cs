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
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index()
        {
            //var events = db.Events.Include(@ => @.Mjesto).Include(@ => @.User).Include(@ => @.Vrsta);
     
            return View(db.Events.ToList());

        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.MjestoId = new SelectList(db.Mjesta, "Id", "Naziv");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.VrstaId = new SelectList(db.Vrste, "Id", "Naziv");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VrstaId,Datum,Napomena,MjestoId,Cijena,ApplicationUserId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MjestoId = new SelectList(db.Mjesta, "Id", "Naziv", @event.MjestoId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", @event.ApplicationUserId);
            ViewBag.VrstaId = new SelectList(db.Vrste, "Id", "Naziv", @event.VrstaId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.MjestoId = new SelectList(db.Mjesta, "Id", "Naziv", @event.MjestoId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", @event.ApplicationUserId);
            ViewBag.VrstaId = new SelectList(db.Vrste, "Id", "Naziv", @event.VrstaId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VrstaId,Datum,Napomena,MjestoId,Cijena,ApplicationUserId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MjestoId = new SelectList(db.Mjesta, "Id", "Naziv", @event.MjestoId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", @event.ApplicationUserId);
            ViewBag.VrstaId = new SelectList(db.Vrste, "Id", "Naziv", @event.VrstaId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
